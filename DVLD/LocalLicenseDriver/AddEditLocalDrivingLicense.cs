using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
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

            _Mode = enMode.Update;
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
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                btnSave.Enabled = true;

            }

        }



        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabControl1.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                return;
            }


           
            if (showPersonCardByFilter1._PersonID != -1)
            {

                btnSave.Enabled = true;
                tabControl1.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                ;

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showPersonCardByFilter1.FilterFocus();
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

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            showPersonCardByFilter1.LoadPersonByID(_LocalDrivingLicenseApplication._PersonID);
            lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            comboBox1.SelectedIndex = comboBox1.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblUser.Text = clsUsers.Find(_LocalDrivingLicenseApplication._CreatedByUser)._UserName;
        }

        private void DataBackEvent(object sender, int PersonID)
        {
           
            _SelectedPersonID = PersonID;
            showPersonCardByFilter1.LoadPersonByID(PersonID);


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
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenseClass.Find(comboBox1.Text).LicenseClassID;


            int ActiveApplicationID = ClsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, ClsApplication.enApplicationType.NewLocalDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }


           
            if (ClsLicense.IsLicenseExistByPersonID(showPersonCardByFilter1._PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication._PersonID = showPersonCardByFilter1._PersonID; 
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication._ApplicationTypeId = 1;
            _LocalDrivingLicenseApplication._ApplicationStatus = ClsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(lblFees.Text);
            _LocalDrivingLicenseApplication._CreatedByUser = LoginInfo.SelectUserInfo._UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
              
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
