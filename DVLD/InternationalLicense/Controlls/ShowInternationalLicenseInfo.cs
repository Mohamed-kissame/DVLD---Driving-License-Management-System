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
using GumroadLicensing;

namespace DVLD.InternationalLicense.Controlls
{
    public partial class ShowInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;

        private ClsInternationalLicense InternationalLicense;

        public ShowInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int InternationalLicenseID)
        {

            _InternationalLicenseID = InternationalLicenseID;

            InternationalLicense = ClsInternationalLicense.Find(_InternationalLicenseID);

            if (InternationalLicense == null)
            {
                MessageBox.Show("Could Not find International License ID = " + InternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            lblName.Text = InternationalLicense._GetPeronInfo.FullName.ToString();
            lblIntLicenseID.Text = _InternationalLicenseID.ToString();
            lblLicenseID.Text = InternationalLicense._IssuedUsingLocalLicenseID.ToString();
            lblNationalNO.Text = InternationalLicense._GetPeronInfo._NationaleNumber.ToString();
            lblGendor.Text = InternationalLicense._GetPeronInfo._Gender.ToString();
            lblIssueDAte.Text = clsFormat.DateToShort(InternationalLicense._IssueDate);
            lblAppID.Text = InternationalLicense._ApplicationID.ToString();
            LblIsActive.Text = InternationalLicense._IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(InternationalLicense._GetPeronInfo._BirthOfDate);
            lblDriverID.Text = InternationalLicense._DriverID.ToString();
            lblExpirationDAte.Text = clsFormat.DateToShort(InternationalLicense._ExpirationDate);


        }

        private void _LoadImage()
        {

            if (InternationalLicense.DriverInfo._PersonInfo._Gender == "Male")
                PicLogo.Image = Resources.man;
            else
               PicLogo .Image = Resources.woman;

            string ImagePath = InternationalLicense.DriverInfo._PersonInfo._ImagePath;

            if (ImagePath != "")
            {

                if (File.Exists(ImagePath))
                    PicLogo.Load(ImagePath);
                else
                    MessageBox.Show("Could not Find this Image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
