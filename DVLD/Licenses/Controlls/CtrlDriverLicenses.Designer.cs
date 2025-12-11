namespace DVLD.Licenses.Controlls
{
    partial class CtrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabcontrol1 = new System.Windows.Forms.TabControl();
            this.tabpageLocal = new System.Windows.Forms.TabPage();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.ctmLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageInternational = new System.Windows.Forms.TabPage();
            this.lblCount1 = new System.Windows.Forms.Label();
            this.dgvInternational = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabcontrol1.SuspendLayout();
            this.tabpageLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            this.ctmLocal.SuspendLayout();
            this.tabPageInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabcontrol1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(693, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabcontrol1
            // 
            this.tabcontrol1.Controls.Add(this.tabpageLocal);
            this.tabcontrol1.Controls.Add(this.tabPageInternational);
            this.tabcontrol1.Location = new System.Drawing.Point(4, 16);
            this.tabcontrol1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabcontrol1.Name = "tabcontrol1";
            this.tabcontrol1.SelectedIndex = 0;
            this.tabcontrol1.Size = new System.Drawing.Size(685, 217);
            this.tabcontrol1.TabIndex = 0;
            // 
            // tabpageLocal
            // 
            this.tabpageLocal.Controls.Add(this.lblCount);
            this.tabpageLocal.Controls.Add(this.dgvLocal);
            this.tabpageLocal.Controls.Add(this.label2);
            this.tabpageLocal.Location = new System.Drawing.Point(4, 22);
            this.tabpageLocal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageLocal.Name = "tabpageLocal";
            this.tabpageLocal.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageLocal.Size = new System.Drawing.Size(677, 191);
            this.tabpageLocal.TabIndex = 0;
            this.tabpageLocal.Text = "Local ";
            this.tabpageLocal.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(4, 172);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(92, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Local Licenses";
            // 
            // dgvLocal
            // 
            this.dgvLocal.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.ContextMenuStrip = this.ctmLocal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocal.GridColor = System.Drawing.Color.Gray;
            this.dgvLocal.Location = new System.Drawing.Point(7, 23);
            this.dgvLocal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLocal.Name = "dgvLocal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocal.RowHeadersWidth = 62;
            this.dgvLocal.RowTemplate.Height = 28;
            this.dgvLocal.Size = new System.Drawing.Size(669, 140);
            this.dgvLocal.TabIndex = 1;
            this.dgvLocal.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvLocal_Paint);
            // 
            // ctmLocal
            // 
            this.ctmLocal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.ctmLocal.Name = "ctmLocal";
            this.ctmLocal.Size = new System.Drawing.Size(178, 34);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.show;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Local Licenses History :";
            // 
            // tabPageInternational
            // 
            this.tabPageInternational.Controls.Add(this.lblCount1);
            this.tabPageInternational.Controls.Add(this.dgvInternational);
            this.tabPageInternational.Controls.Add(this.label1);
            this.tabPageInternational.Location = new System.Drawing.Point(4, 22);
            this.tabPageInternational.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageInternational.Name = "tabPageInternational";
            this.tabPageInternational.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageInternational.Size = new System.Drawing.Size(677, 191);
            this.tabPageInternational.TabIndex = 1;
            this.tabPageInternational.Text = "International";
            this.tabPageInternational.UseVisualStyleBackColor = true;
            // 
            // lblCount1
            // 
            this.lblCount1.AutoSize = true;
            this.lblCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount1.Location = new System.Drawing.Point(4, 174);
            this.lblCount1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount1.Name = "lblCount1";
            this.lblCount1.Size = new System.Drawing.Size(140, 13);
            this.lblCount1.TabIndex = 2;
            this.lblCount1.Text = "International Licenses :";
            // 
            // dgvInternational
            // 
            this.dgvInternational.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternational.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternational.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInternational.Location = new System.Drawing.Point(7, 25);
            this.dgvInternational.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvInternational.Name = "dgvInternational";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternational.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInternational.RowHeadersWidth = 62;
            this.dgvInternational.RowTemplate.Height = 28;
            this.dgvInternational.Size = new System.Drawing.Size(669, 140);
            this.dgvInternational.TabIndex = 1;
            this.dgvInternational.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvInternational_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "International Licenses History :";
            // 
            // CtrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CtrlDriverLicenses";
            this.Size = new System.Drawing.Size(697, 249);
            this.Load += new System.EventHandler(this.CtrlDriverLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabcontrol1.ResumeLayout(false);
            this.tabpageLocal.ResumeLayout(false);
            this.tabpageLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            this.ctmLocal.ResumeLayout(false);
            this.tabPageInternational.ResumeLayout(false);
            this.tabPageInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabcontrol1;
        private System.Windows.Forms.TabPage tabpageLocal;
        private System.Windows.Forms.TabPage tabPageInternational;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblCount1;
        private System.Windows.Forms.DataGridView dgvInternational;
        private System.Windows.Forms.ContextMenuStrip ctmLocal;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
