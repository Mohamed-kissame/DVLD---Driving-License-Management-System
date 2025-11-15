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

namespace DVLD.LocalLicenseDriver
{
    public partial class AddEditLocalDrivingLicense : Form 
    {

        public enum enMode  { AddNew = 0, Update = 1 }

        private enMode _Mode = enMode.AddNew;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        ClsLicenseDrivingLocal _LocalDrivingLicenseApplication;

        public AddEditLocalDrivingLicense()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
            
        }

        public AddEditLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;


        }


        private void RestDefaultValues()
        {

            FillLicense();

           

            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Local Driving License Application";
                this.Text = "Add New Local Driving License Application";
                _LocalDrivingLicenseApplication = new ClsLicenseDrivingLocal();
                showPersonCardByFilter1.FilterFocus();
               

                comboBox1.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)ClsApplication.enApplicationType.NewLocalDrivingLicense).ApplicationFees.ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblUser.Text = LoginInfo.SelectUserInfo._UserName;

            }
            else
            {
                lblTitle.Text = "Edit Local Driving License Application";
                this.Text = "Edit Local Driving License Application";
                btnSave.Enabled = true;

            }

        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabPages.Count - 1)
            {
                tabControl1.SelectedIndex++; 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
          
        }

        private void FillLicense()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClass();


            foreach (DataRow row in dt.Rows)
            {

                comboBox1.Items.Add(row["ClassName"]);

            }

            comboBox1.SelectedIndex = 0;
        }

        private void LoadData()
        {

            _LocalDrivingLicenseApplication = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication != null)
            {
                _SelectedPersonID = _LocalDrivingLicenseApplication._PersonID;
                showPersonCardByFilter1.LoadPersonByID(_SelectedPersonID);
                comboBox1.SelectedItem = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
                lblDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
                lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
                lblUser.Text = _LocalDrivingLicenseApplication.UserInfo._UserName;
            }
            else
            {
                MessageBox.Show("Error Load Local Driving License Application Data", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void AddEditLocalDrivingLicense_Load(object sender, EventArgs e)
        {

            RestDefaultValues();

            if(_Mode == enMode.Update)
            {

                LoadData();
             
            }

        }

        private void AddEditLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            showPersonCardByFilter1.FilterFocus();

        }
    }
}
