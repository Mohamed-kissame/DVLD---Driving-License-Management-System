using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class ShowLicenseInfo : Form
    {

        private int _LicenseID;

        public ShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInfo1.LoadInfo(_LicenseID);
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
