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
                                       , int ApplicationTypeID , enApplicationStatus ApplicationStatus , DateTime LastStatusDate , float PaidFees , int CreatedByUserID , int LicenseClass)
        {


            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._ApplicationID = ApplicationID;
            this._PersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this._ApplicationTypeId = ApplicationTypeID;
            this._ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUser = CreatedByUserID;
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

            bool isFound = ClsLicenseDrivingLocalData.GetAllLicenseDrivingLocalByApplicationID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (isFound)
            {

                ClsApplication Application = ClsApplication.FindBaseApplication(ApplicationID);


                return new ClsLicenseDrivingLocal(LocalDrivingLicenseApplicationID, Application._ApplicationID, Application._PersonID, Application.ApplicationDate, Application._ApplicationTypeId, (enApplicationStatus)Application._ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUser, LicenseClassID);

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

                return new ClsLicenseDrivingLocal(LocalDrivingLicenseApplicationID, Application._ApplicationID, Application._PersonID, Application.ApplicationDate, Application._ApplicationTypeId, (enApplicationStatus)Application._ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUser, LicenseClassID);


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
            return ClsLicenseDrivingLocalData.DeleteLicenseDrivingLocal(this.LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLicense()
        {

            return ClsLicenseDrivingLocalData.ListOfLicenseDriving();
        }



    }
}
