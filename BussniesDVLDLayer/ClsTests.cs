using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsTests
    {

        public enum enMode { AddNew = 0 , Update = 1}

        public enMode Mode = enMode.AddNew;

        public int _TestID { get; set; }

        public int _TestAppointmentID { get; set; }

        //  public clsTestAppointment TestAppointmentInfo { set; get; } // need To add Composition when we Finsh the TestAppoitment Classes

        public bool _TestResult { get; set; }

        public string _Notes { get; set; }

        public int _CreatedByUserID { get; set; }


       public ClsTests()
        {

            this._TestID = -1;
            this._TestAppointmentID = -1;
            this._TestResult = false;
            this._Notes = "";
            this._CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private ClsTests(int TestID , int TestAppointmentID , bool TestResult , string Notes , int CreatedByUserID)
        {

            this._TestID = TestID;
            this._TestAppointmentID = TestAppointmentID;
            this._TestResult = TestResult;
            this._Notes = Notes;
            this._CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static ClsTests FindByTestID(int TestID)
        {

            int TestAppoitment = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";


            if (ClsTestData.GetAllTestsByID(TestID, ref TestAppoitment, ref TestResult, ref Notes, ref CreatedByUserID))

                return new ClsTests(TestID, TestAppoitment, TestResult, Notes, CreatedByUserID);
            else
                return null;


        }

        public static ClsTests FindLastTestPerPersonAndLicenseClass
           (int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (ClsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new ClsTests(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        private bool _AddNewTest()
        {

            this._TestID = ClsTestData.AddNewTest(this._TestAppointmentID, this._TestResult, this._Notes, this._CreatedByUserID);

            return this._TestID != -1;
        }

        private bool _UpdateTest()
        {

            return ClsTestData.UpdateTest(this._TestID, this._TestAppointmentID, this._TestResult, this._Notes, this._CreatedByUserID);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }



                case enMode.Update:

                            return _UpdateTest();
                        }

            return false;

        }


        public static DataTable GetAllTests()
        {

            return ClsTestData.GetAllTests();
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return ClsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }

    }
}
