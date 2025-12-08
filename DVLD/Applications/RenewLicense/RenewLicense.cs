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

namespace DVLD.Application.RenewLicense
{
    public partial class RenewLicense : Form
    {

        private int _NewLicenseID = -1;
        public RenewLicense()
        {
            InitializeComponent();
        }

        private void RenewLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverInfoWithFilter1.TxtlicenseFocus();

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "[dd/mm/yyyy]";
            lblAppFees.Text = clsApplicationType.Find((int)ClsApplication.enApplicationType.Renew).ApplicationFees.ToString();
            lblCreatedBy.Text = LoginInfo.SelectUserInfo._UserName.ToString();

        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            linkNewLicenseInfo.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            int DefaulLengthOfLicense = (int)ctrlDriverInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultLengethValidation;

            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaulLengthOfLicense));
            lblLicenseFees.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.classFess.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo._Notes.ToString();


            if (!ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {

                MessageBox.Show("License is not expired yet , It Will Expire on " + clsFormat.DateToShort(ctrlDriverInfoWithFilter1.SelectedLicenseInfo._ExperienceDate), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }


            if (!ctrlDriverInfoWithFilter1.SelectedLicenseInfo._isActive)
            {
                MessageBox.Show("License is not active chose another License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;

            }

            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

           if(MessageBox.Show("Are you sure you want to renew this license ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            ClsLicense NewLicense = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), LoginInfo.SelectUserInfo._UserID);

            if(NewLicense == null)
            {
                MessageBox.Show("Error occured while renewing the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRLAppID.Text = NewLicense._ApplicationID.ToString();
            _NewLicenseID = NewLicense._LicenseID;
            lblRenewLicenseID.Text = NewLicense._LicenseID.ToString();

            MessageBox.Show("License renewed successfully With ID = " + _NewLicenseID.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrlDriverInfoWithFilter1.Enabled = false;
            linkNewLicenseInfo.Enabled = true;


        }

        private void linkNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo showLicenseInfo = new ShowLicenseInfo(_NewLicenseID);
            showLicenseInfo.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicensesHistory licensesHistory = new ShowPersonLicensesHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverInfo._PersonID);
            licensesHistory.ShowDialog();
        }
    }
}
