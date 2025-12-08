using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;
using DVLD.Classes;
using DVLD.Properties;

namespace DVLD.Licenses.Controlls
{
    public partial class CtrlDriverInfo : UserControl
    {

        private int _LicenseID;

        private ClsLicense _License;

        public int LicenseID { get { return _LicenseID; } }

        public void LoadInfo(int LicenseID)
        {

            _LicenseID = LicenseID;

            ClsLicense license = ClsLicense.Find(LicenseID);

            if (license == null)
            {

                MessageBox.Show("Could Not find License ID = " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;

            }

            _License = license;


            lblClass.Text = license.LicenseClassInfo.ClassName.ToString();
            lblName.Text = license.DriverInfo._PersonInfo.FullName.ToString();
            lblLicenseID.Text = license._LicenseID.ToString();
            lblNationalNo.Text = license.DriverInfo._PersonInfo._NationaleNumber.ToString();
            lblGendor.Text = license.DriverInfo._PersonInfo._Gender.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(license._IssueDate);
            lblIssueReason.Text = license.issueReasonText.ToString();
            lblNotes.Text = license._Notes != "" ? license._Notes.ToString() : "Nothing";
            lblIsActive.Text = license._isActive ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(license.DriverInfo._PersonInfo._BirthOfDate);
            lblDriverID.Text = license.DriverInfo._DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(license._ExperienceDate);
            lblIsDetained.Text = "No";

            //_LoadImage();

        }

        public ClsLicense _SelectedLicenseInfo { get {return _License; } }

        public CtrlDriverInfo()
        {
            InitializeComponent();
           
        }

        private void _LoadImage()
        {

            if (_License.DriverInfo._PersonInfo._Gender == "Male")
                PicLogo.Image = Resources.man;
            else
                PicLogo.Image = Resources.woman;

            string ImagePath = _License.DriverInfo._PersonInfo._ImagePath;

            if(ImagePath != "")
            {

                if (File.Exists(ImagePath))
                    PicLogo.Load(ImagePath);
                else
                    MessageBox.Show("Could not Find this Image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }
    }
}
