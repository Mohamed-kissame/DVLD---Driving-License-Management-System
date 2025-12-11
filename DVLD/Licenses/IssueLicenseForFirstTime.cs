using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;

namespace DVLD.Licenses
{
    public partial class IssueLicenseForFirstTime : Form
    {

        private int _LicenseApplicationID;
        private ClsLicenseDrivingLocal LicenseDrivingLocal;

        public IssueLicenseForFirstTime(int LicenseApplicationID)
        {
            InitializeComponent();
            _LicenseApplicationID = LicenseApplicationID;
        }

        private void IssueLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();

            

            LicenseDrivingLocal = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(_LicenseApplicationID);

            if (LicenseDrivingLocal == null)
            {

                MessageBox.Show("License Application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!LicenseDrivingLocal.PassedAllTest())
            {

                MessageBox.Show("Cannot issue license. The applicant has not passed all required tests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int License = LicenseDrivingLocal.GetActiveLicenseID();

            if(License != -1)
            {
                MessageBox.Show("Cannot issue license. The applicant already has an active license with License ID = " + License, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
           
          
            ctrlShowLicenseApplicationInfo1.LoadLicenseApplicationInfo(_LicenseApplicationID);

            
          

        }


        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click_1(object sender, EventArgs e)
        {
            if (LicenseDrivingLocal != null)
            {

                int NewLicense = LicenseDrivingLocal.IssueLicenseForFirstTime(txtNotes.Text.Trim(), LicenseDrivingLocal._CreatedByUser);

                if (NewLicense != -1)
                    MessageBox.Show("License Issued Successfully With License ID = " + NewLicense, "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error Issuing License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
    }
}
