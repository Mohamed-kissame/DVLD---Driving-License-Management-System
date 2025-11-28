using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsLicenseDrivingLocal : ClsApplication
    {

        public enum enMode { AddNew = 0 , Update = 1}

        public enMode Mode = enMode.AddNew;


        public int LocalDrivingLicenseApplicationID {get; set; }

        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo;


        public string PersonFullName
        {
            get 
            {
                return base._GetPeronInfo.FullName;
            }
        }

        public ClsLicenseDrivingLocal()
        {

            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;

        }

        private ClsLicenseDrivingLocal(int LocalDrivingLicenseApplicationID , int ApplicationID , int ApplicantPersonID , DateTime ApplicationDate 
                                       , int ApplicationTypeID , enApplicationStatus ApplicationStatus , DateTime LastStatusDate , decimal PaidFees , int CreatedByUserID , int LicenseClass) : base(ApplicationID ,ApplicantPersonID , ApplicationDate , ApplicationTypeID, ApplicationStatus ,LastStatusDate , PaidFees , CreatedByUserID)
        {


            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClass;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

            Mode = enMode.Update;

        }


        private bool _AddNewLicenseDrivingLocal()
        {

            this.LocalDrivingLicenseApplicationID = ClsLicenseDrivingLocalData.AddNewLicenseDrivingLocal(this._ApplicationID, this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID > -1;

        }

        private bool _UpdateLicenseDrivingLocal()
        {
            return ClsLicenseDrivingLocalData.UpdateLicenseDrivingLocal(this.LocalDrivingLicenseApplicationID, this._ApplicationID, this.LicenseClassID);
        }

        public static ClsLicenseDrivingLocal FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = -1, LicenseClassID = -1;

            bool isFound = ClsLicenseDrivingLocalData.GetAllLicenseDrivingLocalByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (isFound)
            {

                ClsApplication Application = ClsApplication.FindBaseApplication(ApplicationID);


                return new ClsLicenseDrivingLocal(LocalDrivingLicenseApplicationID, Application._ApplicationID, Application._PersonID, Application.ApplicationDate, Application._ApplicationTypeId, (enApplicationStatus)Application._ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application._CreatedByUser, LicenseClassID);

            }

            else
            {
                return null;
            }


        }

        public static ClsLicenseDrivingLocal FingByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;


            bool isFound = ClsLicenseDrivingLocalData.GetAllLicenseDrivingLocalByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


            if (isFound)
            {

                ClsApplication Application = ClsApplication.FindBaseApplication(ApplicationID);

                return new ClsLicenseDrivingLocal(LocalDrivingLicenseApplicationID, Application._ApplicationID, Application._PersonID, Application.ApplicationDate, Application._ApplicationTypeId, (enApplicationStatus)Application._ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application._CreatedByUser, LicenseClassID);


            }

            else
            {

                return null;

            }

        }

        public bool Save()
        {

            base._Mode = (ClsApplication.enMode)Mode;

            if(!base.Save())
                return false;


            switch (Mode)
            {

                case enMode.AddNew:
                    if (_AddNewLicenseDrivingLocal())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseDrivingLocal();



            }

            return false;
        }

        public bool Delete()
        {

            bool isLicenseAppDelete = false;
            bool IsBaseAppDelete = false;
            isLicenseAppDelete = ClsLicenseDrivingLocalData.DeleteLicenseDrivingLocal(this.LocalDrivingLicenseApplicationID);

            if (!isLicenseAppDelete)
                return false;

            IsBaseAppDelete = base.Delete();
            return IsBaseAppDelete;

        }

        public static DataTable GetAllLicense()
        {

            return ClsLicenseDrivingLocalData.ListOfLicenseDriving();
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return ClsLicenseDrivingLocalData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestType.enTestType CurrentTestType)
        {

            switch (CurrentTestType)
            {

                case clsTestType.enTestType.VisionTest: return true;

                case clsTestType.enTestType.WrittenTest: return this.DoesPassTestType(clsTestType.enTestType.VisionTest);

                case clsTestType.enTestType.StreetTest: return this.DoesPassTestType(clsTestType.enTestType.WrittenTest);

                default: return false;
                  

            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return ClsLicenseDrivingLocalData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return ClsLicenseDrivingLocalData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrailsPerTest(clsTestType.enTestType TestTypeID)
        {
            return ClsLicenseDrivingLocalData.TotalTrailsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrailsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return ClsLicenseDrivingLocalData.TotalTrailsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) { 

            return ClsLicenseDrivingLocalData.TotalTrailsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) >0; 

        }

        public bool AttendedTest(clsTestType.enTestType TestTypeID) {

            return ClsLicenseDrivingLocalData.TotalTrailsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) {

            return ClsLicenseDrivingLocalData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID,(int) TestTypeID);
        }

        public  bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return ClsLicenseDrivingLocalData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public ClsTests GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return ClsTests.FindLastTestPerPersonAndLicenseClass(this._PersonID, this.LicenseClassID, TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return ClsTests.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTest()
        {

            return ClsTests.PassedAllTests(this.LocalDrivingLicenseApplicationID);

        }

        public static bool PassedAllTest(int LocalDrivingLicenseApplicationID)
        {

            return ClsTests.PassedAllTests(LocalDrivingLicenseApplicationID);

        }

        public int IssueLicenseForFirstTime(string Notes , int CreatedBy)
        {

            int DriverID = -1;

            ClsDriver driver = ClsDriver.FindByPersonID(this._PersonID);

            if(driver == null)
            {

                driver = new ClsDriver();

                driver._PersonID = this._PersonID;
                driver._CreatedByUserID = CreatedBy;

                if (driver.Save())
                {
                    DriverID = driver._DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = driver._DriverID;
            }

            ClsLicense license = new ClsLicense();
            license._ApplicationID = this._ApplicationID;
            license._DriverID = DriverID;
            license._LicnseClass = this.LicenseClassID;
            license._IssueDate = DateTime.Now;
            license._ExperienceDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultLengethValidation);
            license._Notes = Notes;
            license._PaidFees = this.LicenseClassInfo.classFess;
            license._isActive = true;
            license._issueReason = ClsLicense.enIssueReason.FirstTime;
            license._CreatedByUserID = CreatedBy;

            if (license.Save())
            {

                this.SetComplete();

                return license._LicenseID;
            }
            else
                return -1;
            
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {

            return ClsLicense.GetActiveLicenseIDByPersonID(this._PersonID, this.LicenseClassID);
        }

    }
}
