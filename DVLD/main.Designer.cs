namespace DVLD
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationaleLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.relaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pepoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.pepoleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1720, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingToolStripMenuItem,
            this.manageApplicationToolStripMenuItem,
            this.detainLicensesToolStripMenuItem,
            this.manageApplicationToolStripMenuItem1,
            this.manageTestTypesToolStripMenuItem});
            this.applicationsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.application;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(158, 29);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // drivingToolStripMenuItem
            // 
            this.drivingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.replaToolStripMenuItem,
            this.releaseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingToolStripMenuItem.Image = global::DVLD.Properties.Resources.drivers_license;
            this.drivingToolStripMenuItem.Name = "drivingToolStripMenuItem";
            this.drivingToolStripMenuItem.Size = new System.Drawing.Size(340, 34);
            this.drivingToolStripMenuItem.Text = "Driving Licenses Services";
            this.drivingToolStripMenuItem.Click += new System.EventHandler(this.drivingToolStripMenuItem_Click);
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localToolStripMenuItem,
            this.internationaleLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(476, 34);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_32;
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(292, 34);
            this.localToolStripMenuItem.Text = "Local License ";
            this.localToolStripMenuItem.Click += new System.EventHandler(this.localToolStripMenuItem_Click);
            // 
            // internationaleLicenseToolStripMenuItem
            // 
            this.internationaleLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.internationaleLicenseToolStripMenuItem.Name = "internationaleLicenseToolStripMenuItem";
            this.internationaleLicenseToolStripMenuItem.Size = new System.Drawing.Size(292, 34);
            this.internationaleLicenseToolStripMenuItem.Text = "International License";
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(476, 34);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // replaToolStripMenuItem
            // 
            this.replaToolStripMenuItem.Image = global::DVLD.Properties.Resources.Lost_Driving_License_32;
            this.replaToolStripMenuItem.Name = "replaToolStripMenuItem";
            this.replaToolStripMenuItem.Size = new System.Drawing.Size(476, 34);
            this.replaToolStripMenuItem.Text = "Replacement for Lost or Damaged License ";
            this.replaToolStripMenuItem.Click += new System.EventHandler(this.replaToolStripMenuItem_Click);
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_512;
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(476, 34);
            this.releaseToolStripMenuItem.Text = "Release Detained Driving License";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(476, 34);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // manageApplicationToolStripMenuItem
            // 
            this.manageApplicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDriToolStripMenuItem,
            this.internationalDrivingLicenseApplicationToolStripMenuItem});
            this.manageApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.control_system_1_;
            this.manageApplicationToolStripMenuItem.Name = "manageApplicationToolStripMenuItem";
            this.manageApplicationToolStripMenuItem.Size = new System.Drawing.Size(340, 34);
            this.manageApplicationToolStripMenuItem.Text = "Manage Application";
            this.manageApplicationToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationToolStripMenuItem_Click);
            // 
            // localDriToolStripMenuItem
            // 
            this.localDriToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_32;
            this.localDriToolStripMenuItem.Name = "localDriToolStripMenuItem";
            this.localDriToolStripMenuItem.Size = new System.Drawing.Size(470, 34);
            this.localDriToolStripMenuItem.Text = "Local Driving License Applications";
            this.localDriToolStripMenuItem.Click += new System.EventHandler(this.localDriToolStripMenuItem_Click);
            // 
            // internationalDrivingLicenseApplicationToolStripMenuItem
            // 
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Name = "internationalDrivingLicenseApplicationToolStripMenuItem";
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(470, 34);
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Text = "International Driving License Applications";
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainLicenseToolStripMenuItem,
            this.toolStripSeparator2,
            this.detainLicenseToolStripMenuItem,
            this.toolStripSeparator1,
            this.relaseLicenseToolStripMenuItem});
            this.detainLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            this.detainLicensesToolStripMenuItem.Size = new System.Drawing.Size(340, 34);
            this.detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainLicenseToolStripMenuItem
            // 
            this.manageDetainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.manageDetainLicenseToolStripMenuItem.Name = "manageDetainLicenseToolStripMenuItem";
            this.manageDetainLicenseToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.manageDetainLicenseToolStripMenuItem.Text = "Manage Detain License";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(325, 6);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(325, 6);
            // 
            // relaseLicenseToolStripMenuItem
            // 
            this.relaseLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_512;
            this.relaseLicenseToolStripMenuItem.Name = "relaseLicenseToolStripMenuItem";
            this.relaseLicenseToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.relaseLicenseToolStripMenuItem.Text = "Release Detained License";
            // 
            // manageApplicationToolStripMenuItem1
            // 
            this.manageApplicationToolStripMenuItem1.Image = global::DVLD.Properties.Resources.control_system;
            this.manageApplicationToolStripMenuItem1.Name = "manageApplicationToolStripMenuItem1";
            this.manageApplicationToolStripMenuItem1.Size = new System.Drawing.Size(340, 34);
            this.manageApplicationToolStripMenuItem1.Text = "Manage Application Types";
            this.manageApplicationToolStripMenuItem1.Click += new System.EventHandler(this.manageApplicationToolStripMenuItem1_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.standards;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(340, 34);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // pepoleToolStripMenuItem
            // 
            this.pepoleToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pepoleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pepoleToolStripMenuItem.Image = global::DVLD.Properties.Resources.ManagePepole;
            this.pepoleToolStripMenuItem.Name = "pepoleToolStripMenuItem";
            this.pepoleToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.pepoleToolStripMenuItem.Text = "Pepole";
            this.pepoleToolStripMenuItem.Click += new System.EventHandler(this.pepoleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.driversToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.driversToolStripMenuItem.Image = global::DVLD.Properties.Resources.driving;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.usersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usersToolStripMenuItem.Image = global::DVLD.Properties.Resources.Users;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.accountSettingsToolStripMenuItem.Image = global::DVLD.Properties.Resources.AccountSettings;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(197, 29);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.project;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLD.Properties.Resources.account_recovery;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.changePasswordToolStripMenuItem.Text = "change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signToolStripMenuItem
            // 
            this.signToolStripMenuItem.Image = global::DVLD.Properties.Resources.logout;
            this.signToolStripMenuItem.Name = "signToolStripMenuItem";
            this.signToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.signToolStripMenuItem.Text = "Sign Out";
            this.signToolStripMenuItem.Click += new System.EventHandler(this.signToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.driving__vehicle_license_department_system_high_resolution_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1720, 821);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1720, 854);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVLD SYSTEM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pepoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem drivingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationaleLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem relaseLicenseToolStripMenuItem;
    }
}