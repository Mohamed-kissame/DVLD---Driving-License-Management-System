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
        public main()
        {
            InitializeComponent();
        }

        private Pepole.Pepole pepole = new DVLD.Pepole.Pepole();

        private void accountSeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //pepole.MdiParent = this;
            //pepole.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
