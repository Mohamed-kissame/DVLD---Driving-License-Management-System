using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.InternationalLicense
{
    public partial class ShowIntLicenseInfo : Form
    {

        private int _InterNational;

        public ShowIntLicenseInfo(int InterNational)
        {
            InitializeComponent();

            _InterNational = InterNational;
        }

        private void ShowIntLicenseInfo_Load(object sender, EventArgs e)
        {
            showInternationalLicenseInfo1.LoadInfo(_InterNational);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
