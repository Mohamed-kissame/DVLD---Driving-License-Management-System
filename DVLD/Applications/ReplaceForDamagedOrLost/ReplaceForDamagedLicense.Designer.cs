namespace DVLD.Application.ReplaceForDamagedOrLost
{
    partial class ReplaceForDamagedLicense
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
            this.ctrlDriverInfoWithFilter1 = new DVLD.Licenses.Controlls.CtrlDriverInfoWithFilter();
            this.gpReplaceFor = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdbForDamaged = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.llblFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.lblLEAppID = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.linkShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssueReplace = new Guna.UI2.WinForms.Guna2Button();
            this.gpReplaceFor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDriverInfoWithFilter1
            // 
            this.ctrlDriverInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverInfoWithFilter1.Location = new System.Drawing.Point(15, -1);
            this.ctrlDriverInfoWithFilter1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlDriverInfoWithFilter1.Name = "ctrlDriverInfoWithFilter1";
            this.ctrlDriverInfoWithFilter1.Size = new System.Drawing.Size(687, 393);
            this.ctrlDriverInfoWithFilter1.TabIndex = 0;
            this.ctrlDriverInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverInfoWithFilter1_OnLicenseSelected);
            // 
            // gpReplaceFor
            // 
            this.gpReplaceFor.Controls.Add(this.radioButton1);
            this.gpReplaceFor.Controls.Add(this.rdbForDamaged);
            this.gpReplaceFor.Location = new System.Drawing.Point(469, 8);
            this.gpReplaceFor.Margin = new System.Windows.Forms.Padding(2);
            this.gpReplaceFor.Name = "gpReplaceFor";
            this.gpReplaceFor.Padding = new System.Windows.Forms.Padding(2);
            this.gpReplaceFor.Size = new System.Drawing.Size(209, 66);
            this.gpReplaceFor.TabIndex = 1;
            this.gpReplaceFor.TabStop = false;
            this.gpReplaceFor.Text = "Replace For ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(13, 42);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Lost License";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdbForDamaged
            // 
            this.rdbForDamaged.AutoSize = true;
            this.rdbForDamaged.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbForDamaged.Location = new System.Drawing.Point(13, 23);
            this.rdbForDamaged.Margin = new System.Windows.Forms.Padding(2);
            this.rdbForDamaged.Name = "rdbForDamaged";
            this.rdbForDamaged.Size = new System.Drawing.Size(110, 17);
            this.rdbForDamaged.TabIndex = 0;
            this.rdbForDamaged.TabStop = true;
            this.rdbForDamaged.Text = "Damaged License";
            this.rdbForDamaged.UseVisualStyleBackColor = true;
            this.rdbForDamaged.CheckedChanged += new System.EventHandler(this.rdbForDamaged_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.llblFees);
            this.groupBox2.Controls.Add(this.lblAppDate);
            this.groupBox2.Controls.Add(this.lblOldLicenseID);
            this.groupBox2.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox2.Controls.Add(this.lblLEAppID);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(8, 402);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(703, 121);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For License Replacement";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(520, 90);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(43, 13);
            this.lblCreatedBy.TabIndex = 17;
            this.lblCreatedBy.Text = "[????]";
            // 
            // llblFees
            // 
            this.llblFees.AutoSize = true;
            this.llblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblFees.Location = new System.Drawing.Point(171, 90);
            this.llblFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llblFees.Name = "llblFees";
            this.llblFees.Size = new System.Drawing.Size(36, 13);
            this.llblFees.TabIndex = 16;
            this.llblFees.Text = "[$$$]";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(171, 58);
            this.lblAppDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(83, 13);
            this.lblAppDate.TabIndex = 15;
            this.lblAppDate.Text = "[dd/mm/yyyy]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(520, 58);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(29, 13);
            this.lblOldLicenseID.TabIndex = 14;
            this.lblOldLicenseID.Text = "[??]";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(520, 22);
            this.lblReplacedLicenseID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(29, 13);
            this.lblReplacedLicenseID.TabIndex = 13;
            this.lblReplacedLicenseID.Text = "[??]";
            // 
            // lblLEAppID
            // 
            this.lblLEAppID.AutoSize = true;
            this.lblLEAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLEAppID.Location = new System.Drawing.Point(171, 22);
            this.lblLEAppID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLEAppID.Name = "lblLEAppID";
            this.lblLEAppID.Size = new System.Drawing.Size(29, 13);
            this.lblLEAppID.TabIndex = 12;
            this.lblLEAppID.Text = "[??]";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.Properties.Resources.user_4_;
            this.pictureBox6.Location = new System.Drawing.Point(477, 90);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(19, 13);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.Properties.Resources.Driver_License_48;
            this.pictureBox5.Location = new System.Drawing.Point(477, 58);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 13);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.driving;
            this.pictureBox4.Location = new System.Drawing.Point(477, 22);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 13);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money;
            this.pictureBox3.Location = new System.Drawing.Point(129, 90);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 13);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.calendar;
            this.pictureBox2.Location = new System.Drawing.Point(129, 58);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 13);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.id_card;
            this.pictureBox1.Location = new System.Drawing.Point(129, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 13);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(337, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "CreatedBy :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(337, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Old License ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(337, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Replaced License ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Application Fees :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "L.R.Application ID :";
            // 
            // linkShowLicensesHistory
            // 
            this.linkShowLicensesHistory.AutoSize = true;
            this.linkShowLicensesHistory.Location = new System.Drawing.Point(20, 544);
            this.linkShowLicensesHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkShowLicensesHistory.Name = "linkShowLicensesHistory";
            this.linkShowLicensesHistory.Size = new System.Drawing.Size(114, 13);
            this.linkShowLicensesHistory.TabIndex = 3;
            this.linkShowLicensesHistory.TabStop = true;
            this.linkShowLicensesHistory.Text = "Show Licenses History";
            this.linkShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicensesHistory_LinkClicked);
            // 
            // linkShowLicensesInfo
            // 
            this.linkShowLicensesInfo.AutoSize = true;
            this.linkShowLicensesInfo.Enabled = false;
            this.linkShowLicensesInfo.Location = new System.Drawing.Point(197, 544);
            this.linkShowLicensesInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkShowLicensesInfo.Name = "linkShowLicensesInfo";
            this.linkShowLicensesInfo.Size = new System.Drawing.Size(125, 13);
            this.linkShowLicensesInfo.TabIndex = 5;
            this.linkShowLicensesInfo.TabStop = true;
            this.linkShowLicensesInfo.Text = "Show New Licenses Info";
            this.linkShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicensesInfo_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(448, 535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 39);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnIssueReplace
            // 
            this.btnIssueReplace.Animated = true;
            this.btnIssueReplace.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueReplace.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueReplace.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueReplace.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssueReplace.FillColor = System.Drawing.Color.Green;
            this.btnIssueReplace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIssueReplace.ForeColor = System.Drawing.Color.White;
            this.btnIssueReplace.Location = new System.Drawing.Point(567, 535);
            this.btnIssueReplace.Name = "btnIssueReplace";
            this.btnIssueReplace.Size = new System.Drawing.Size(135, 39);
            this.btnIssueReplace.TabIndex = 7;
            this.btnIssueReplace.Text = "Issue Replace";
            this.btnIssueReplace.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ReplaceForDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(719, 584);
            this.Controls.Add(this.btnIssueReplace);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkShowLicensesInfo);
            this.Controls.Add(this.linkShowLicensesHistory);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpReplaceFor);
            this.Controls.Add(this.ctrlDriverInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReplaceForDamagedLicense";
            this.Text = "ReplaceForDamagedLicense";
            this.Load += new System.EventHandler(this.ReplaceForDamagedLicense_Load);
            this.gpReplaceFor.ResumeLayout(false);
            this.gpReplaceFor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Controlls.CtrlDriverInfoWithFilter ctrlDriverInfoWithFilter1;
        private System.Windows.Forms.GroupBox gpReplaceFor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkShowLicensesHistory;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkShowLicensesInfo;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdbForDamaged;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label llblFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label lblLEAppID;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnIssueReplace;
    }
}