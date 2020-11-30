using RLJones.FraudInspectionDriver.Classes;
using System;
using System.Deployment.Application;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLJones.FraudInspectionDriver.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // get product version (this will only work on deployed executables)
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                LblProductVersion.Text = string.Format("v{0}",
                    ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));

                TxtEmail.Text = string.Empty;
                TxtPassword.Text = string.Empty;
            }
            else
            {
                // use this when debugging only for rapid access
                TxtEmail.Text = "j.leija@babinc.com";
                TxtPassword.Text = "Flex.321";
            }
            Text = "RL Jones | Fraud Inspection Driver " + LblProductVersion.Text;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            LblStatus.ForeColor = Color.Black;
            TxtEmail.Enabled = false;
            TxtPassword.Enabled = false;
            BtnLogin.Enabled = false;

            LblStatus.Text = "Trying to connect with RL Jones database...";

            if(await VerifyDatabase())
            {
                LblStatus.Text = "Trying to login into FlexLink...";

                if (await LoginAsync())
                {
                    Visible = false;
                    FrmMain main = new FrmMain();
                    main.Show();
                }
                else
                {
                    Tools.FlexLinkChrome.Close();
                    LblStatus.Text = "Unable to login; ";
                    LblStatus.Text += "verify your network connection and your credentials...";
                    LblStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                LblStatus.Text = "Unable to connect with RL Jones database, verify settings.";
                LblStatus.ForeColor = Color.Red;
            }

            Cursor = Cursors.Default;
            TxtEmail.Enabled = true;
            TxtPassword.Enabled = true;
            BtnLogin.Enabled = true;
        }

        private async Task<bool> LoginAsync()
        {
            bool loggedIn = false;

            await Task.Run(() =>
            {
                Tools.FlexLinkChrome.Open();
                Tools.FlexLinkChrome.Maximize();
                Tools.FlexLinkChrome.Navigate("https://flexlinkmicrosoft.flex.com/#/");

                var username = Tools.FlexLinkChrome.WaitForElementById("okta-signin-username", 10);

                if (username != null)
                    username.SendKeys(TxtEmail.Text);

                var password = Tools.FlexLinkChrome.WaitForElementById("okta-signin-password", 10);

                if (password != null)
                    password.SendKeys(TxtPassword.Text);

                if(username != null && password != null)
                {
                    var loginButton = Tools.FlexLinkChrome.WaitForElementById("okta-signin-submit", 10);

                    if (loginButton != null)
                    {
                        loginButton.Click();

                        var welcomeMessage = Tools.FlexLinkChrome.WaitForElementById("ddlUser", 20);
                        loggedIn = welcomeMessage != null;
                    }
                }
            });
            return loggedIn;
        }

        private async Task<bool> VerifyDatabase()
        {
            bool dbOk = false;

            await Task.Run(() =>
            {
                try
                {
                    using (var db = new FraudInspectionDb())
                    {
                        db.Open();
                        var tracker = db.ExecuteReader("SELECT * FROM FraudInspectionTargets");
                    }
                    dbOk = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            return dbOk;
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            LblStatus.Text = "Enter your FlexLink credentials...";
            LblStatus.ForeColor = Color.Black;
            BtnLogin.Enabled = ValidateData();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            LblStatus.Text = "Enter your FlexLink credentials...";
            LblStatus.ForeColor = Color.Black;
            BtnLogin.Enabled = ValidateData();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tools.FlexLinkChrome.Close();
            Tools.FlexLinkChrome.Quit();
        }

        private bool ValidateData()
        {
            return TxtEmail.Text != "" && TxtPassword.Text != "";
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter && ValidateData())
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && ValidateData())
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.ShowDialog();
        }
    }
}
