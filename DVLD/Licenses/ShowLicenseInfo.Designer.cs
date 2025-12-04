namespace DVLD.Licenses
{
    partial class ShowLicenseInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowLicenseInfo));
            this.ctrlDriverInfo1 = new DVLD.Licenses.Controlls.CtrlDriverInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ctrlDriverInfo1
            // 
            this.ctrlDriverInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlDriverInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDriverInfo1.Name = "ctrlDriverInfo1";
            this.ctrlDriverInfo1.Size = new System.Drawing.Size(1058, 502);
            this.ctrlDriverInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(903, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 50);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = " Close";
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
            // ShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 615);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDriverInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowLicenseInfo";
            this.Text = "ShowLicenseInfo";
            this.Load += new System.EventHandler(this.ShowLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controlls.CtrlDriverInfo ctrlDriverInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageList1;
    }
}