using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class clsTestAppointment
    {

        public enum enMode { AddNew = 0 , Update = 1}

        public enMode _Mode = enMode.AddNew;

        public int _TestAppointmentID { get; set; }

        public clsTestType.enTestType _TestTypeID { get; set; }

        public int _LocalDrivingLicenseApplicationID { get; set; }

        public DateTime _AppointmentDate { get; set; }

        public float _PaidFees { get; set; }

        public int _CreatedByUserID { get; set; }

        public bool _IsLocked { get; set; }

        public int _RetakeTestAppointmentID { get; set; }

        public ClsApplication RetakeTestAppInfo { set; get; }

        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }

        public clsTestAppointment()
        {

            this._TestAppointmentID = -1;
            this._TestTypeID = clsTestType.enTestType.VisionTest;
            this._LocalDrivingLicenseApplicationID = -1;
            this._AppointmentDate = DateTime.Now;
            this._PaidFees = 0;
            this._CreatedByUserID = -1;
            this._IsLocked = false;
            this._RetakeTestAppointmentID = -1;
            _Mode = enMode.AddNew;

        }

        private clsTestAppointment(int TestAppointmentID , int TestTypeID , int LocalDrivingLicenseApplicationID , DateTime AppointmentDate , float PaidFees , int CreatedByUserID , bool IsLocked , int RetakeTestAppintmentID)
        {

            this._TestAppointmentID = TestAppointmentID;
            this._TestTypeID = (clsTestType.enTestType)TestTypeID;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._AppointmentDate = AppointmentDate;
            this._PaidFees = 0;
            this._CreatedByUserID = CreatedByUserID;
            this._IsLocked = IsLocked;
            this._RetakeTestAppointmentID = RetakeTestAppintmentID;
            RetakeTestAppInfo = ClsApplication.FindBaseApplication(RetakeTestAppintmentID);

            _Mode = enMode.Update;
        }


        public static clsTestAppointment FindById(int  TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1, RetakeTestAppointmentID = -1;
            DateTime AppintmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (ClsTestAppoitmentData.GetAllTestAppoitmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppintmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestAppointmentID))

                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppintmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestAppointmentID);
            else
                return null;
        }

        public static clsTestAppointment FindLastTestAppointment(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {

            int TestAppointment = -1, CreatedyUserID = -1, RetakeTestAppointmentID = -1;
            DateTime AppintmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (ClsTestAppoitmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID, ref TestAppointment, ref AppintmentDate, ref PaidFees, ref CreatedyUserID, ref IsLocked, ref RetakeTestAppointmentID))

                return new clsTestAppointment(TestAppointment, TestTypeID, LocalDrivingLicenseApplicationID, AppintmentDate, PaidFees, CreatedyUserID, IsLocked, RetakeTestAppointmentID);
            else
                return null;

        }

        public static DataTable GetAllTestAppointments()
        {
            return ClsTestAppoitmentData.GetAllTestAppoitment();
        }

        public  DataTable GetAllTestAppointmentPerTestType(clsTestType.enTestType TestTypeID)
        {
            return ClsTestAppoitmentData.GetApplicationTestAppointmentPerTestType(this._LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static DataTable GetAllTestAppointmentPerTestType(int LocalDrivingLicenseApplicationID , clsTestType.enTestType TestTypeID)
        {
            return ClsTestAppoitmentData.GetApplicationTestAppointmentPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        private bool _AddNewTestAppointment()
        {

            this._TestAppointmentID = ClsTestAppoitmentData.AddNewTestAppointment((int)this._TestTypeID, this._LocalDrivingLicenseApplicationID, this._AppointmentDate, this._PaidFees, this._CreatedByUserID, this._IsLocked, this._RetakeTestAppointmentID);

            return this._TestAppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return ClsTestAppoitmentData.UpdateTestAppointment(this._TestAppointmentID, (int)this._TestTypeID, this._LocalDrivingLicenseApplicationID, this._AppointmentDate, this._PaidFees, this._CreatedByUserID, this._IsLocked, this._RetakeTestAppointmentID);
        }

        private int _GetTestID()
        {
            return ClsTestAppoitmentData.GetTestID(this._TestAppointmentID);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:

                    if (_AddNewTestAppointment())
                    {
                        _Mode = enMode.Update;

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }

    }
}
