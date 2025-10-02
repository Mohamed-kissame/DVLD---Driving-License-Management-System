using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Pepole;

namespace DVLD
{
    public partial class main : Form
    {

        private string _username;
        private DateTime _loginTime;
        private Login _LoginForm;

        public main(Login LoginForm ,string UserName)
        {
            InitializeComponent();
        }

        private void SetupModernUI()
        {
            // ===== MenuStrip Modern Look =====
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ModernColors());
            menuStrip1.BackColor = Color.FromArgb(44, 62, 80);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // ===== Status Bar =====
            StatusStrip status = new StatusStrip();
            status.BackColor = Color.FromArgb(52, 73, 94);
            status.ForeColor = Color.White;
            status.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // User info
            ToolStripStatusLabel lblUser = new ToolStripStatusLabel($"Logged in as: {_username}");
            ToolStripStatusLabel spacer = new ToolStripStatusLabel() { Spring = true };
            ToolStripStatusLabel lblDate = new ToolStripStatusLabel($"Login time: {_loginTime:dd/MM/yyyy HH:mm}");

            status.Items.Add(lblUser);
            status.Items.Add(spacer);
            status.Items.Add(lblDate);

            this.Controls.Add(status);

            // ===== Form Style =====
            this.IsMdiContainer = true;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        public class ModernMenuRenderer : ToolStripProfessionalRenderer
        {
            public ModernMenuRenderer() : base(new ModernColors()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(52, 152, 219)), e.Item.ContentRectangle);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        public class ModernColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(52, 152, 219);
            public override Color MenuItemBorder => Color.FromArgb(41, 128, 185);
            public override Color MenuBorder => Color.FromArgb(236, 240, 241);
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }

        private void accountSeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Pepole.Pepole pepole = new DVLD.Pepole.Pepole();
            
            pepole.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
