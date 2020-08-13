using RLJones.FraudInspectionDriver.Classes;
using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace RLJones.FraudInspectionDriver.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly ConnectionStringManager ConnStrMgr;

        public FrmSettings()
        {
            InitializeComponent();

            // parse connection string to modify parameters later
            ConnStrMgr = 
                new ConnectionStringManager( ApplicationDeployment.IsNetworkDeployed ? 
                                             "ProductionDatabase" : "DebugDatabase"
                                           );
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            TxtDataSource.Text = ConnStrMgr.GetParameter("DATA SOURCE");
            TxtInitialCatalog.Text = ConnStrMgr.GetParameter("INITIAL CATALOG");

            ChkIntegratedSecurity.Checked
                = ConnStrMgr.GetParameter("INTEGRATED SECURITY") == "SSPI";

            if(!ChkIntegratedSecurity.Checked)
            {
                TxtUserID.Text = ConnStrMgr.GetParameter("USER ID");
                TxtPassword.Text = ConnStrMgr.GetParameter("PASSWORD");
            }
        }

        private void ChkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            LoginCredentials.Visible = !ChkIntegratedSecurity.Checked;

            if (ChkIntegratedSecurity.Checked)
            {
                ConnStrMgr.SetParameter("INTEGRATED SECURITY", "SSPI");
                ConnStrMgr.RemoveParameter("USER ID");
                ConnStrMgr.RemoveParameter("PASSWORD");
            }
            else
            {
                ConnStrMgr.SetParameter("INTEGRATED SECURITY", "False");
                ConnStrMgr.SetParameter("USER ID", TxtUserID.Text);
                ConnStrMgr.SetParameter("PASSWORD", TxtPassword.Text);
            }
        }

        private void TxtDataSource_TextChanged(object sender, EventArgs e)
        {
            ConnStrMgr.SetParameter("DATA SOURCE", TxtDataSource.Text);
        }

        private void TxtInitialCatalog_TextChanged(object sender, EventArgs e)
        {
            ConnStrMgr.SetParameter("INITIAL CATALOG", TxtInitialCatalog.Text);
        }

        private void TxtUserID_TextChanged(object sender, EventArgs e)
        {
            ConnStrMgr.SetParameter("USER ID", TxtUserID.Text);
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            ConnStrMgr.SetParameter("PASSWORD", TxtPassword.Text);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string errorsFound = ConnStrMgr.GetErrorMessages();

            if(errorsFound != string.Empty)
            {
                MessageBox.Show(errorsFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult response
                = MessageBox.Show("Save configuration?", "Confirm saving", 
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(response == DialogResult.Yes)
            {
                ConnStrMgr.Save();
                DialogResult = DialogResult.OK;
                MessageBox.Show("Configuration saved to disk, restart the application.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
