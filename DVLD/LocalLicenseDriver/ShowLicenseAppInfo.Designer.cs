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
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ctrlShowLicenseApplicationInfo1 = new DVLD.controlls.ctrlShowLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(953, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 52);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Close.png");
            // 
            // ctrlShowLicenseApplicationInfo1
            // 
            this.ctrlShowLicenseApplicationInfo1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlShowLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlShowLicenseApplicationInfo1.Name = "ctrlShowLicenseApplicationInfo1";
            this.ctrlShowLicenseApplicationInfo1.Size = new System.Drawing.Size(1072, 451);
            this.ctrlShowLicenseApplicationInfo1.TabIndex = 0;
            this.ctrlShowLicenseApplicationInfo1.Load += new System.EventHandler(this.ctrlShowLicenseApplicationInfo1_Load);
            // 
            // ShowLicenseAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowLicenseAppInfo";
            this.Text = "Show License App Info";
            this.Load += new System.EventHandler(this.ShowLicenseAppInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controlls.ctrlShowLicenseApplicationInfo ctrlShowLicenseApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageList1;
    }
}