using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace RLJones.FraudInspectionDriver.Forms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            // get product version (this will only work on deployed executables)
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                LblProductVersion.Text = string.Format("v{0}",
                    ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
            }
        }
    }
}
