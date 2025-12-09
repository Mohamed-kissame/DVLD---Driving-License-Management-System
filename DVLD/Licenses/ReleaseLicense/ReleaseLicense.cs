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
using DVLD.Classes;

namespace DVLD.Licenses.ReleaseLicense
{
    public partial class ReleaseLicense : Form
    {

        private int SelectedLicenseID = -1;
     
      

        public ReleaseLicense()
        {
            InitializeComponent();
        }

        public ReleaseLicense(int License)
        {
            InitializeComponent();
            SelectedLicenseID = License;

            ctrlDriverInfoWithFilter1.LoadLicenseInfo(SelectedLicenseID);
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
        }

        private void ReleaseLicense_Load(object sender, EventArgs e) { }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {

            SelectedLicenseID = obj;

            lblLicense.Text = SelectedLicenseID.ToString();

            linkShowLicenseInfo.Enabled = (SelectedLicenseID != -1);

            if(SelectedLicenseID == -1)
            {

                return;

            }

            if (!ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected license is NOT detained, choose another one",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRelease.Enabled = false;
                return;
            }

           
            var info = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DetainInfo;

            lblApplFees.Text = clsApplicationType.Find((int)ClsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees.ToString();

            lblDetainID.Text = info.DetainID.ToString();
            lblDetainDate.Text = clsFormat.DateToShort(info.DetainDate);
            lblFineFees.Text = info.FineFees.ToString();
            lblCreted.Text = info.CreatedUserInfo._UserName;

            float applFees, fineFees;
            if (float.TryParse(lblApplFees.Text, out applFees) && float.TryParse(lblFineFees.Text, out fineFees))
            {
                lblTotalFees.Text = (applFees + fineFees).ToString();
            }
            else
            {
                lblTotalFees.Text = "Invalid fees";
            }

            btnRelease.Enabled = true;




        }

        private void btnRelease_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to release This Detained License ?" , "Confirm" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.No)
            {

                return;
            }

            int ApplicationID = -1;

            bool IsRelease = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(LoginInfo.SelectUserInfo._UserID, ref ApplicationID);

            lblAppIDD.Text = ApplicationID.ToString();

            if (!IsRelease)
            {

                MessageBox.Show("Failed to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detain License released Successfully", "Detain License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverInfoWithFilter1.Enabled = false;
            linkShowLicenseInfo.Enabled = true;
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicensesHistory personLicensesHistory = new ShowPersonLicensesHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverInfo._PersonID);
            personLicensesHistory.ShowDialog();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo licenseInfo = new ShowLicenseInfo(SelectedLicenseID);
            licenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
