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
using static BussniesDVLDLayer.clsTestType;

namespace DVLD.Tests.Controlls
{
    public partial class CtrlScheduledTest : UserControl
    {

        private clsTestType.enTestType _TestTypeID;
        private int _TestID;


        private ClsLicenseDrivingLocal _LocalDrivingLicenseApplication;

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointment _TestAppointment;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            gpTitle.Text = "Vision Test";
                            PicLogoChange.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            gpTitle.Text = "Written Test";
                            PicLogoChange.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gpTitle.Text = "Street Test";
                            PicLogoChange.Image = Resources.Street_Test_32;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        public void LoadInfo(int AppointmentID)
        {

            _TestAppointmentID = AppointmentID;
            _TestAppointment = clsTestAppointment.FindById(_TestAppointmentID);


            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment._LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplIcenseID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;



            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrailsPerTest(_TestTypeID).ToString();



            lblDate.Text = clsFormat.DateToShort(_TestAppointment._AppointmentDate);
            lblFees.Text = _TestAppointment._PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();


        }

        public CtrlScheduledTest()
        {
            InitializeComponent();
        }

    

        private void CtrlScheduledTest_Load(object sender, EventArgs e)
        {

        }
    }
}
