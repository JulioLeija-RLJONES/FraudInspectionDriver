using OpenQA.Selenium;
using RLJones.FraudInspectionDriver.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RLJones.FraudInspectionDriver.Forms
{
    public partial class FrmMain : Form
    {
        private FraudInspectionDb Db = new FraudInspectionDb();
        private bool SnValidationScreenIsActive = false;
        private bool SnValidated = false;
        private bool FraudInspectionDone = false;

        private string SerialNumber = string.Empty;
        private IWebElement SerialNumberField = null;

        private string PartNumber = string.Empty;
        private IWebElement PartNumberField = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Db.Open();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width,
                                 workingArea.Bottom - Size.Height);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Db.Dispose();
            Application.Exit();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            HandleBlinker();
            VerifyFlexLinkIsAlive();

            var body = Tools.FlexLinkChrome.WaitForElementByTagName("body", 1); 
            
            if(body != null)
            {
                SerialNumberField =
                    Tools.FlexLinkChrome
                         .FindElementByXPath(body, "//*[@id='SerialNumber']");

                PartNumberField =
                    Tools.FlexLinkChrome
                         .FindElementByXPath(body, "//*[@id='PartNumber']");

                SnValidationScreenIsActive = SerialNumberField != null && PartNumberField == null;
                SnValidated = SerialNumberField != null && PartNumberField != null;

                if (SnValidationScreenIsActive)
                {
                    MainTimer.Enabled = false;
                    FraudInspectionDone = false;
                    LblStatus.Text = "Fraud inspection driver is ready...";
                    SerialNumber = SerialNumberField.GetAttribute("value").Trim();
                    MainTimer.Enabled = true;
                }
                else if (SnValidated && !FraudInspectionDone)
                {
                    DoFraudInspection();
                }
                else if(!FraudInspectionDone)
                    LblStatus.Text = "Go to 'Order Management > Screening && disposition' page...";
            }
        }

        private void HandleBlinker()
        {
            if (LblBlinker.BackColor == Color.Lime)
                LblBlinker.BackColor = Color.Black;
            else
                LblBlinker.BackColor = Color.Lime;
        }

        private void VerifyFlexLinkIsAlive()
        {
            if (!Tools.FlexLinkChrome.IsAlive())
            {
                MainTimer.Enabled = false;
                MessageBox.Show("Web browser was closed", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void DoFraudInspection()
        {
            MainTimer.Enabled = false;
            PartNumber = PartNumberField.GetAttribute("value").Trim();

            // check if this SN was already inspected by searching a tracker entry in db...
            var fraudTracker = Db.GetFraudTracker(SerialNumber);

            // if tracker is null, SN is not inspected so we'll inspect it now:
            if (fraudTracker == null)
            {
                // check if part number is a target for fraud inspection
                var target = Db.GetInspectionTarget(PartNumber);

                if (target != null)
                {
                    // it is a target, do fraud inspection now!
                    Tools.FlexLinkChrome.Minimize();
                    LblStatus.Text = "Performing fraud inspection, SN='" + SerialNumber + "'";

                    FrmFraudInspection fraudInspection 
                        = new FrmFraudInspection(SerialNumber);

                    fraudInspection.ShowDialog();

                    fraudTracker = new FraudTracker
                    {
                        Date = DateTime.Now,
                        DeviceType = target.Class,
                        SerialNumber = SerialNumber,
                        PSUTest = fraudInspection.GetResultText()
                    };
                    Db.InsertFraudTracker(fraudTracker);

                    LblStatus.Text = "Fraud inspection done, SN='" + SerialNumber + "'";
                    Tools.FlexLinkChrome.Maximize();
                }
                else
                {
                    // it is not a target, show message and do nothing...
                    string msg = string.Format(
                        "SN {0} is not a target for fraud inspection.", 
                        SerialNumber
                        );

                    LblStatus.Text = msg;
                }
                FraudInspectionDone = true;
            }
            else // SN is already inspected, show message and do nothing
            {
                string msg = string.Format(
                    "SN {0} inspected on {1}: {2}",
                    fraudTracker.SerialNumber, fraudTracker.Date.ToShortDateString(), fraudTracker.PSUTest
                    );

                LblStatus.Text = msg;
                FraudInspectionDone = true;
            }
            MainTimer.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resp =
                MessageBox
                .Show("FlexLink web browser will also be closed, are you sure to exit?",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
                Close();
        }
    }
}
