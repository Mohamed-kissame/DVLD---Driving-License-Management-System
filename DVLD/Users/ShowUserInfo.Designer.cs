namespace DVLD.controlls
{
    partial class ShowUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowUserInfo));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.showUserCard1 = new DVLD.controlls.ShowUserCard();
            this.BtnClose = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Close.png");
            // 
            // showUserCard1
            // 
            this.showUserCard1.Location = new System.Drawing.Point(12, 0);
            this.showUserCard1.Margin = new System.Windows.Forms.Padding(2);
            this.showUserCard1.Name = "showUserCard1";
            this.showUserCard1.Size = new System.Drawing.Size(1064, 530);
            this.showUserCard1.TabIndex = 0;
            this.showUserCard1.Load += new System.EventHandler(this.showUserCard1_Load);
            // 
            // BtnClose
            // 
            this.BtnClose.Animated = true;
            this.BtnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnClose.FillColor = System.Drawing.Color.Red;
            this.BtnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(966, 551);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(97, 50);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click_1);
            // 
            // ShowUserInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1088, 625);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.showUserCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowUserInfo";
            this.Text = "ShowUserInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ShowUserCard showUserCard1;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2TileButton BtnClose;
    }
}