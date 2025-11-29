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
using DVLD.Properties;
using Fizzler;

namespace DVLD.Tests.Controlls
{
    public partial class ctrlScheduleTest : UserControl
    {

        public enum enMode { AddNew = 0 , Update = 1}
        private enMode Mode = enMode.AddNew;

        public enum enCreationMode { FirstTime = 0 , RetakeTest = 1}
        private enCreationMode CreationMode = enCreationMode.FirstTime;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private ClsLicenseDrivingLocal _LicenseDrivingLocalApp;
        private int _LicenseDrivingLocalID = -1;
        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;


        public clsTestType.enTestType TestType
        {

            get { return _TestTypeID; } 

            set { _TestTypeID = value;


                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        gpTestName.Text = "Vision Test";
                        picChangeTestType.Image = Resources.Vision_512;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        gpTestName.Text = "Writte Test";
                        picChangeTestType.Image = Resources.Written_Test_512;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        gpTestName.Text = "Stret Test";
                        picChangeTestType.Image = Resources.Street_Test_32;
                        break;

                    default:
                        gpTestName.Text = "Vision Test";
                        picChangeTestType.Image = Resources.Vision_512;
                        break;

                }
            
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LocalDrivingLicenseAppID , int AppointmentID = -1)
        {

            if (AppointmentID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;

               _LicenseDrivingLocalID = LocalDrivingLicenseAppID;
               _TestAppointmentID = AppointmentID;
               _LicenseDrivingLocalApp = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(_LicenseDrivingLocalID);

            if( _LicenseDrivingLocalApp == null)
            {

                MessageBox.Show("Error No Local Driving License Application With Id = " + _LicenseDrivingLocalID.ToString() , "Error Message" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;

            }

            if (_LicenseDrivingLocalApp.DoesAttendTestType(_TestTypeID))
                CreationMode = enCreationMode.RetakeTest;

            else

                CreationMode = enCreationMode.FirstTime;

            if (CreationMode == enCreationMode.RetakeTest)
            {
                lblRetakeFees.Text = clsApplicationType.Find((int)ClsApplication.enApplicationType.RetakeTest).ApplicationFees.ToString();
                gpRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeID.Text = "0";

            }
            else
            {
                gpRetakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeFees.Text = "0";
                lblRetakeID.Text = "N/A";

            }

            lblIDApp.Text = _LicenseDrivingLocalApp._ApplicationID.ToString();
            lblClass.Text = _LicenseDrivingLocalApp.LicenseClassInfo.ClassName.ToString();
            lblName.Text = _LicenseDrivingLocalApp.ApplicantFullName.ToString();
            lblTrial.Text = _LicenseDrivingLocalApp.TotalTrailsPerTest(_TestTypeID).ToString();

            if (Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(_TestTypeID).TestFees.ToString();
                dateTimePicker1.MinDate = DateTime.Now;
                lblRetakeID.Text = "N/A";
                _TestAppointment = new clsTestAppointment();
            }

            else
            {
                if (!LoadTestAppointment())
                    return;

            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeFees.Text)).ToString();


            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppoitmentLocked())
                return;

            if (!_HandlePreviousTest())
                return;


        }

        private bool LoadTestAppointment()
        {

            _TestAppointment = clsTestAppointment.FindById(_TestAppointmentID);

            if(_TestAppointment == null)
            {

                MessageBox.Show("Error No Appointment With ID = " + _TestAppointmentID.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment._PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment._AppointmentDate) < 0)
                dateTimePicker1.MinDate = DateTime.Now;
            else
                dateTimePicker1.MinDate = _TestAppointment._AppointmentDate;

            dateTimePicker1.Value = _TestAppointment._AppointmentDate;

            if(_TestAppointment._RetakeTestAppointmentID == -1)
            {

                lblRetakeFees.Text = "0";
                lblRetakeID.Text = "N/A";

            }
            else
            {

                lblRetakeFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                gpRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeID.Text = _TestAppointment._RetakeTestAppointmentID.ToString();
            }

            return true;

        }

        private bool _HandleActiveTestAppointmentConstraint()
        {

            if (Mode == enMode.AddNew && ClsLicenseDrivingLocal.IsThereAnActiveScheduledTest(_LicenseDrivingLocalID, _TestTypeID))
            {

                lblErrorMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppoitmentLocked()
        {

            if (_TestAppointment._IsLocked)
            {

                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Person already sat for the test, appointment loacked";
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
                return false;
            }
            else

                lblErrorMessage.Enabled = false;

            return true;
        }

        private bool _HandlePreviousTest()
        {

            switch (_TestTypeID)
            {

                case clsTestType.enTestType.VisionTest: lblErrorMessage.Visible = false; return true;

                case clsTestType.enTestType.WrittenTest: 

                    if(!_LicenseDrivingLocalApp.DoesPassPreviousTest(clsTestType.enTestType.VisionTest))
                    {
                        lblErrorMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblErrorMessage.Visible = true;
                        btnSave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblErrorMessage.Visible = false;
                        btnSave.Enabled = true;
                        dateTimePicker1.Enabled = true;

                    }

                    return true;

                case clsTestType.enTestType.StreetTest:
                    if (!_LicenseDrivingLocalApp.DoesPassPreviousTest(clsTestType.enTestType.WrittenTest))
                    {
                        lblErrorMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblErrorMessage.Visible = true;
                        btnSave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblErrorMessage.Visible = false;
                        btnSave.Enabled = true;
                        dateTimePicker1.Enabled = true;

                    }

                    return true;

            }

            return true;

        }

        private bool _HandleRetakeApplication()
        {

            if(Mode == enMode.AddNew && CreationMode == enCreationMode.RetakeTest)
            {

                ClsApplication Application = new ClsApplication();

                Application._ApplicationID = _LicenseDrivingLocalApp._ApplicationID;
                Application.ApplicationDate = DateTime.Now;
                Application._ApplicationTypeId = (int)ClsApplication.enApplicationType.RetakeTest;
                Application._ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.Find((int)ClsApplication.enApplicationType.RetakeTest).ApplicationFees;
                Application._CreatedByUser = LoginInfo.SelectUserInfo._UserID;

                if (!Application.Save())
                {
                    _TestAppointment._RetakeTestAppointmentID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment._RetakeTestAppointmentID = Application._ApplicationID;

            }

            return true;
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment._TestTypeID = _TestTypeID;
            _TestAppointment._LocalDrivingLicenseApplicationID = _LicenseDrivingLocalApp.LocalDrivingLicenseApplicationID;
            _TestAppointment._AppointmentDate = dateTimePicker1.Value;
            _TestAppointment._PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment._CreatedByUserID = LoginInfo.SelectUserInfo._UserID;

            if (_TestAppointment.Save())
            {
                Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
