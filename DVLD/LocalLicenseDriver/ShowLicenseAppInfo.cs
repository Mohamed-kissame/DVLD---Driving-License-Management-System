using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalLicenseDriver
{
    public partial class ShowLicenseAppInfo : Form
    {

        private int _LApplicationID = -1;

        public ShowLicenseAppInfo(int LAppID)
        {
            InitializeComponent();
            _LApplicationID = LAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlShowLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ShowLicenseAppInfo_Load(object sender, EventArgs e)
        {
            ctrlShowLicenseApplicationInfo1.LoadLicenseApplicationInfo(_LApplicationID);
        }
    }
}
