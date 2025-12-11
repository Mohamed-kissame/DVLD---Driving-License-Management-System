namespace DVLD.LocalLicenseDriver
{
    partial class ShowLicenseAppInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowLicenseAppInfo));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.ctrlShowLicenseApplicationInfo1 = new DVLD.controlls.ctrlShowLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Close.png");
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
            this.guna2TileButton1.Location = new System.Drawing.Point(763, 466);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Size = new System.Drawing.Size(107, 42);
            this.guna2TileButton1.TabIndex = 1;
            this.guna2TileButton1.Text = "Close";
            this.guna2TileButton1.Click += new System.EventHandler(this.guna2TileButton1_Click);
            // 
            // ctrlShowLicenseApplicationInfo1
            // 
            this.ctrlShowLicenseApplicationInfo1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlShowLicenseApplicationInfo1.Location = new System.Drawing.Point(8, 8);
            this.ctrlShowLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlShowLicenseApplicationInfo1.Name = "ctrlShowLicenseApplicationInfo1";
            this.ctrlShowLicenseApplicationInfo1.Size = new System.Drawing.Size(884, 453);
            this.ctrlShowLicenseApplicationInfo1.TabIndex = 0;
            this.ctrlShowLicenseApplicationInfo1.Load += new System.EventHandler(this.ctrlShowLicenseApplicationInfo1_Load);
            // 
            // ShowLicenseAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 520);
            this.Controls.Add(this.guna2TileButton1);
            this.Controls.Add(this.ctrlShowLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShowLicenseAppInfo";
            this.Text = "Show License App Info";
            this.Load += new System.EventHandler(this.ShowLicenseAppInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controlls.ctrlShowLicenseApplicationInfo ctrlShowLicenseApplicationInfo1;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
    }
}