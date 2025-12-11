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
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(10, 463);
            this.ctrlDriverLicenses1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(716, 240);
            this.ctrlDriverLicenses1.TabIndex = 0;
            // 
            // showPersonCardByFilter1
            // 
            this.showPersonCardByFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showPersonCardByFilter1.FilterEnable = true;
            this.showPersonCardByFilter1.Location = new System.Drawing.Point(10, 8);
            this.showPersonCardByFilter1.Margin = new System.Windows.Forms.Padding(1);
            this.showPersonCardByFilter1.Name = "showPersonCardByFilter1";
            this.showPersonCardByFilter1.Size = new System.Drawing.Size(963, 438);
            this.showPersonCardByFilter1.TabIndex = 1;
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.Animated = true;
            this.guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton1.FillColor = System.Drawing.Color.Red;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton1.ForeColor = System.Drawing.Color.White;
            this.guna2TileButton1.Location = new System.Drawing.Point(866, 717);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Size = new System.Drawing.Size(88, 42);
            this.guna2TileButton1.TabIndex = 2;
            this.guna2TileButton1.Text = "Close";
            this.guna2TileButton1.Click += new System.EventHandler(this.guna2TileButton1_Click);
            // 
            // ShowPersonLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(983, 771);
            this.Controls.Add(this.guna2TileButton1);
            this.Controls.Add(this.showPersonCardByFilter1);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShowPersonLicensesHistory";
            this.Text = "ShowPersonLicensesHistory";
            this.Load += new System.EventHandler(this.ShowPersonLicensesHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controlls.CtrlDriverLicenses ctrlDriverLicenses1;
        private controlls.showPersonCardByFilter showPersonCardByFilter1;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
    }
}