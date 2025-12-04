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

namespace DVLD.Licenses.Controlls
{
    public partial class CtrlDriverInfoWithFilter : UserControl
    {

        public event Action<int> OnLicenseSelected;

        protected virtual void PersonSelected(int LicenseID)
        {

            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);
            }

        }

        private int _LicenseID;

        private ClsLicense _License;


        public CtrlDriverInfoWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                groupBox1.Enabled = _FilterEnabled;
            }
        }

        public int LicenseID
        {
            get { return ctrlDriverInfo1.LicenseID; }
        }

        public ClsLicense selectedLicenseInfo
        {
            get { return ctrlDriverInfo1.selectedLicenseInfo; }
        }

        private void CtrlDriverInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        public void LoadLicenseInfo(int LicenseID)
        {

            txtSearch.Text = LicenseID.ToString();
            ctrlDriverInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDriverInfo1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
            {
                OnLicenseSelected(_LicenseID);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show("Some fields have invalid data. Please correct them and try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Focus();
                return;
            }


            _LicenseID = int.Parse(txtSearch.Text);

            LoadLicenseInfo(_LicenseID);

        }

        public void TxtlicenseFocus()
        {
            txtSearch.Focus();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "License ID is required.");

            }
            else
            {
                errorProvider1.SetError(txtSearch, string.Empty);

            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();

            }
        }
    }
}
