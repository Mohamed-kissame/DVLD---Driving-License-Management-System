using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;

namespace DVLD.Licenses.DetainLicense
{
    public partial class Detained : Form
    {

        private int _DetainID = -1;

        private int SelectedLicenseID = -1;

        public Detained()
        {
            InitializeComponent();
        }

        private void Detained_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = LoginInfo.SelectUserInfo._UserName;
        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {

            SelectedLicenseID = obj;

            lblLicense.Text = SelectedLicenseID.ToString();
            linkShowInfo.Enabled = (SelectedLicenseID != -1);

            if(SelectedLicenseID == -1)
            {
                return;
            }

            if (!ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {

                MessageBox.Show("Selected License is Already Detained Choose another one ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                btnDetain.Enabled = false;
                txtFineFees.Enabled = false;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;



        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fine fees may be empty ", "not valid fees", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain This License ?" , "Confirm" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No)
            {

                return;
            }

            _DetainID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text) , LoginInfo.SelectUserInfo._UserID );

            if(_DetainID == -1)
            {

                MessageBox.Show("Failed To Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            lblDetainID.Text = _DetainID.ToString();

            MessageBox.Show("License Detained Successfully with ID = " + _DetainID.ToString(), "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            linkShowInfo.Enabled = true;

        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }
            ;
        }

        private void linkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ShowPersonLicensesHistory licensesHistory = new ShowPersonLicensesHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverInfo._PersonID);
            licensesHistory.ShowDialog();
        }

        private void linkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo licenseInfo = new ShowLicenseInfo(SelectedLicenseID);
            licenseInfo.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
