namespace DVLD.InternationalLicense
{
    partial class ShowIntLicenseInfo
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
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.showInternationalLicenseInfo1 = new DVLD.InternationalLicense.Controlls.ShowInternationalLicenseInfo();
            this.SuspendLayout();
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Red;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(861, 387);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(134, 49);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // showInternationalLicenseInfo1
            // 
            this.showInternationalLicenseInfo1.Location = new System.Drawing.Point(23, 12);
            this.showInternationalLicenseInfo1.Name = "showInternationalLicenseInfo1";
            this.showInternationalLicenseInfo1.Size = new System.Drawing.Size(987, 361);
            this.showInternationalLicenseInfo1.TabIndex = 0;
            // 
            // ShowIntLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 461);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.showInternationalLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowIntLicenseInfo";
            this.Text = "ShowIntLicenseInfo";
            this.Load += new System.EventHandler(this.ShowIntLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controlls.ShowInternationalLicenseInfo showInternationalLicenseInfo1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}