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
using static BussniesDVLDLayer.ClsLicense;

namespace DVLD.Application.ReplaceForDamagedOrLost
{
    public partial class ReplaceForDamagedLicense : Form
    {

        private int _NewLicenseID = -1;

        public ReplaceForDamagedLicense()
        {
            InitializeComponent();
        }

        private int _GetApplicationTypeID()
        {
            if (rdbForDamaged.Checked)
            {
                return (int)ClsApplication.enApplicationType.ReplacementADamagedDrivingLicense;
            }
            else
            {
                return (int)ClsApplication.enApplicationType.ReplacementALostDrivingLicense;
            }
        }

        private enIssueReason _GetIssueReason()
        {
            if (rdbForDamaged.Checked)
            {
                return ClsLicense.enIssueReason.ReplacementForDamaged;
            }
            else
            {
                return ClsLicense.enIssueReason.ReplacementForLost;
            }
        }


        private void rdbForDamaged_CheckedChanged(object sender, EventArgs e)
        {
            llblFees.Text = clsApplicationType.Find((int)_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            llblFees.Text = clsApplicationType.Find((int)_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            linkShowLicensesInfo.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (!ctrlDriverInfoWithFilter1.SelectedLicenseInfo._isActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplace.Enabled = false;
                return;
            }

        }

        private void btnIssueReplace_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to issue a replacement license ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }

            ClsLicense NewLicense = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), LoginInfo.SelectUserInfo._UserID);

            if(NewLicense == null)
            {
                MessageBox.Show("Error occured while issuing the replacement license","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense._LicenseID;

            lblLEAppID.Text = NewLicense._ApplicationID.ToString();

            lblReplacedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Replacement License issued successfully with ID = " + _NewLicenseID.ToString(),"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

            btnIssueReplace.Enabled = false;
            gpReplaceFor.Enabled = false;
            ctrlDriverInfoWithFilter1.Enabled = false;
            linkShowLicensesInfo.Enabled = true;

        }

        private void linkShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo licenseInfo = new ShowLicenseInfo(_NewLicenseID);
            licenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReplaceForDamagedLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = LoginInfo.SelectUserInfo._UserName;

            rdbForDamaged.Checked = true;
        }
    }
}
