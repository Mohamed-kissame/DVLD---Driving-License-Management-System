namespace DVLD.Licenses
{
    partial class ShowPersonLicensesHistory
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
            this.ctrlDriverLicenses1 = new DVLD.Licenses.Controlls.CtrlDriverLicenses();
            this.showPersonCardByFilter1 = new DVLD.controlls.showPersonCardByFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(12, 517);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(1037, 370);
            this.ctrlDriverLicenses1.TabIndex = 0;
            // 
            // showPersonCardByFilter1
            // 
            this.showPersonCardByFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showPersonCardByFilter1.Location = new System.Drawing.Point(45, 12);
            this.showPersonCardByFilter1.Name = "showPersonCardByFilter1";
            this.showPersonCardByFilter1.Size = new System.Drawing.Size(962, 494);
            this.showPersonCardByFilter1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(920, 893);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 54);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ShowPersonLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1061, 971);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.showPersonCardByFilter1);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowPersonLicensesHistory";
            this.Text = "ShowPersonLicensesHistory";
            this.Load += new System.EventHandler(this.ShowPersonLicensesHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controlls.CtrlDriverLicenses ctrlDriverLicenses1;
        private controlls.showPersonCardByFilter showPersonCardByFilter1;
        private System.Windows.Forms.Button btnClose;
    }
}