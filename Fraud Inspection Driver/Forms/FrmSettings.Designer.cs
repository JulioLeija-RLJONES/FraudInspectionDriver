namespace RLJones.FraudInspectionDriver.Forms
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabDatabase = new System.Windows.Forms.TabPage();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LoginCredentials = new System.Windows.Forms.GroupBox();
            this.TxtUserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ChkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.TxtInitialCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDataSource = new System.Windows.Forms.TextBox();
            this.TabIcons = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.TabDatabase.SuspendLayout();
            this.LoginCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabDatabase);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.TabIcons;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 471);
            this.tabControl1.TabIndex = 0;
            // 
            // TabDatabase
            // 
            this.TabDatabase.Controls.Add(this.BtnCancel);
            this.TabDatabase.Controls.Add(this.LoginCredentials);
            this.TabDatabase.Controls.Add(this.BtnSave);
            this.TabDatabase.Controls.Add(this.ChkIntegratedSecurity);
            this.TabDatabase.Controls.Add(this.TxtInitialCatalog);
            this.TabDatabase.Controls.Add(this.label2);
            this.TabDatabase.Controls.Add(this.label1);
            this.TabDatabase.Controls.Add(this.TxtDataSource);
            this.TabDatabase.ImageIndex = 0;
            this.TabDatabase.Location = new System.Drawing.Point(4, 31);
            this.TabDatabase.Name = "TabDatabase";
            this.TabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.TabDatabase.Size = new System.Drawing.Size(416, 436);
            this.TabDatabase.TabIndex = 0;
            this.TabDatabase.Text = "Database";
            this.TabDatabase.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(203, 381);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(95, 40);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LoginCredentials
            // 
            this.LoginCredentials.Controls.Add(this.TxtUserID);
            this.LoginCredentials.Controls.Add(this.label3);
            this.LoginCredentials.Controls.Add(this.label4);
            this.LoginCredentials.Controls.Add(this.TxtPassword);
            this.LoginCredentials.Location = new System.Drawing.Point(23, 205);
            this.LoginCredentials.Name = "LoginCredentials";
            this.LoginCredentials.Size = new System.Drawing.Size(376, 160);
            this.LoginCredentials.TabIndex = 10;
            this.LoginCredentials.TabStop = false;
            this.LoginCredentials.Text = "Login credentials";
            // 
            // TxtUserID
            // 
            this.TxtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserID.Location = new System.Drawing.Point(17, 54);
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.Size = new System.Drawing.Size(336, 30);
            this.TxtUserID.TabIndex = 5;
            this.TxtUserID.TextChanged += new System.EventHandler(this.TxtUserID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "User ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(17, 113);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '•';
            this.TxtPassword.Size = new System.Drawing.Size(336, 30);
            this.TxtPassword.TabIndex = 7;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(304, 381);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(95, 40);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ChkIntegratedSecurity
            // 
            this.ChkIntegratedSecurity.AutoSize = true;
            this.ChkIntegratedSecurity.Location = new System.Drawing.Point(252, 160);
            this.ChkIntegratedSecurity.Name = "ChkIntegratedSecurity";
            this.ChkIntegratedSecurity.Size = new System.Drawing.Size(147, 21);
            this.ChkIntegratedSecurity.TabIndex = 4;
            this.ChkIntegratedSecurity.Text = "Integrated security";
            this.ChkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.ChkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.ChkIntegratedSecurity_CheckedChanged);
            // 
            // TxtInitialCatalog
            // 
            this.TxtInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInitialCatalog.Location = new System.Drawing.Point(23, 105);
            this.TxtInitialCatalog.Name = "TxtInitialCatalog";
            this.TxtInitialCatalog.Size = new System.Drawing.Size(376, 30);
            this.TxtInitialCatalog.TabIndex = 3;
            this.TxtInitialCatalog.TextChanged += new System.EventHandler(this.TxtInitialCatalog_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initial Catalog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Source:";
            // 
            // TxtDataSource
            // 
            this.TxtDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDataSource.Location = new System.Drawing.Point(23, 41);
            this.TxtDataSource.Name = "TxtDataSource";
            this.TxtDataSource.Size = new System.Drawing.Size(376, 30);
            this.TxtDataSource.TabIndex = 0;
            this.TxtDataSource.TextChanged += new System.EventHandler(this.TxtDataSource_TextChanged);
            // 
            // TabIcons
            // 
            this.TabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabIcons.ImageStream")));
            this.TabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TabIcons.Images.SetKeyName(0, "database_24.png");
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 471);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabDatabase.ResumeLayout(false);
            this.TabDatabase.PerformLayout();
            this.LoginCredentials.ResumeLayout(false);
            this.LoginCredentials.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabDatabase;
        private System.Windows.Forms.ImageList TabIcons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDataSource;
        private System.Windows.Forms.TextBox TxtInitialCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkIntegratedSecurity;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUserID;
        private System.Windows.Forms.GroupBox LoginCredentials;
        private System.Windows.Forms.Button BtnCancel;
    }
}