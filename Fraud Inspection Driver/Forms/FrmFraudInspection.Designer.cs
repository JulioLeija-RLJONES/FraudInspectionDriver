namespace RLJones.FraudInspectionDriver
{
    partial class FrmFraudInspection
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
            this.RadPass = new System.Windows.Forms.RadioButton();
            this.RadFail = new System.Windows.Forms.RadioButton();
            this.RadByPass = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.LblSerialNumber = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // RadPass
            // 
            this.RadPass.AutoSize = true;
            this.RadPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadPass.Location = new System.Drawing.Point(234, 229);
            this.RadPass.Name = "RadPass";
            this.RadPass.Size = new System.Drawing.Size(153, 50);
            this.RadPass.TabIndex = 0;
            this.RadPass.Text = "PASS";
            this.RadPass.UseVisualStyleBackColor = true;
            this.RadPass.CheckedChanged += new System.EventHandler(this.RadPass_CheckedChanged);
            // 
            // RadFail
            // 
            this.RadFail.AutoSize = true;
            this.RadFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadFail.Location = new System.Drawing.Point(234, 308);
            this.RadFail.Name = "RadFail";
            this.RadFail.Size = new System.Drawing.Size(128, 50);
            this.RadFail.TabIndex = 1;
            this.RadFail.Text = "FAIL";
            this.RadFail.UseVisualStyleBackColor = true;
            this.RadFail.CheckedChanged += new System.EventHandler(this.RadFail_CheckedChanged);
            // 
            // RadByPass
            // 
            this.RadByPass.AutoSize = true;
            this.RadByPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadByPass.Location = new System.Drawing.Point(234, 386);
            this.RadByPass.Name = "RadByPass";
            this.RadByPass.Size = new System.Drawing.Size(208, 50);
            this.RadByPass.TabIndex = 2;
            this.RadByPass.Text = "BYPASS";
            this.RadByPass.UseVisualStyleBackColor = true;
            this.RadByPass.CheckedChanged += new System.EventHandler(this.RadByPass_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RLJones.FraudInspectionDriver.Properties.Resources.check_48;
            this.pictureBox1.Location = new System.Drawing.Point(133, 229);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 66);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fraud inspection";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RLJones.FraudInspectionDriver.Properties.Resources.delete_48;
            this.pictureBox2.Location = new System.Drawing.Point(133, 308);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RLJones.FraudInspectionDriver.Properties.Resources.repeat_48;
            this.pictureBox3.Location = new System.Drawing.Point(133, 386);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnConfirm.Enabled = false;
            this.BtnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.Location = new System.Drawing.Point(0, 496);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(620, 98);
            this.BtnConfirm.TabIndex = 7;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // LblSerialNumber
            // 
            this.LblSerialNumber.AutoSize = true;
            this.LblSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSerialNumber.Location = new System.Drawing.Point(27, 81);
            this.LblSerialNumber.Name = "LblSerialNumber";
            this.LblSerialNumber.Size = new System.Drawing.Size(90, 46);
            this.LblSerialNumber.TabIndex = 8;
            this.LblSerialNumber.Text = "SN:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(234, 143);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(161, 50);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "NONE";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FrmFraudInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 594);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.LblSerialNumber);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RadByPass);
            this.Controls.Add(this.RadFail);
            this.Controls.Add(this.RadPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFraudInspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFraudInspection";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RadPass;
        private System.Windows.Forms.RadioButton RadFail;
        private System.Windows.Forms.RadioButton RadByPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Label LblSerialNumber;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}