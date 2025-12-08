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
using DVLD.Licenses;

namespace DVLD.InternationalLicense
{
    public partial class NewInternationalLicenseAPP : Form
    {
        private int _NewInternationalLicenseID = -1;

        public NewInternationalLicenseAPP()
        {
            InitializeComponent();
        }



        private void NewInternationalLicenseAPP_Load(object sender, EventArgs e)
        {

            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDatee.Text = lblAppDate.Text;
            lblExpiration.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblFeees.Text = clsApplicationType.Find((int)ClsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = LoginInfo.SelectUserInfo._UserName.ToString();

        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedID = obj;

            lblLocalLicenseID.Text = SelectedID.ToString();
            linkShowNewLicensesInfo.Enabled = (SelectedID != -1);

            if(SelectedID == -1)
            {
                return;
            }

            if (ctrlDriverInfoWithFilter1.SelectedLicenseInfo._LicnseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInternaionalLicenseID = ClsInternationalLicense.GetActiveInternationalLicenseCount(ctrlDriverInfoWithFilter1.SelectedLicenseInfo._DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linkShowNewLicensesInfo.Enabled = true;
                _NewInternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            ClsInternationalLicense InternationalLicense = new ClsInternationalLicense();
           

            InternationalLicense._ApplicationID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverInfo._PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense._ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)ClsApplication.enApplicationType.NewInternationalLicense).ApplicationFees;
            InternationalLicense._CreatedByUser = LoginInfo.SelectUserInfo._UserID;


            InternationalLicense._DriverID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo._DriverID;
            InternationalLicense._IssuedUsingLocalLicenseID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo._LicenseID;
            InternationalLicense._IssueDate = DateTime.Now;
            InternationalLicense._ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense._CreatedByUser = LoginInfo.SelectUserInfo._UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblILApplicationID.Text = InternationalLicense._ApplicationID.ToString();
            _NewInternationalLicenseID = InternationalLicense._InternationalLicenseID;
            lblILicenseID.Text = InternationalLicense._InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense._InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrlDriverInfoWithFilter1.Enabled = false;
            linkShowNewLicensesInfo.Enabled = true;

        }

        private void linkShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowIntLicenseInfo licenseInfo = new ShowIntLicenseInfo(_NewInternationalLicenseID);
            licenseInfo.Show();
        }

        private void linkLabelShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicensesHistory licensesHistory = new ShowPersonLicensesHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverInfo._PersonID);
            licensesHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
