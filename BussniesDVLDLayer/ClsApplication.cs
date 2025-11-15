using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsApplication
    {

       public enum enMode { AddNew = 0 , Update = 1};

       public enum enApplicationType {NewLocalDrivingLicense = 1 , Renew = 2 , ReplacementALostDrivingLicense = 3 , ReplacementADamagedDrivingLicense = 4
        , ReleaseDetainedDrivingLicense = 5 , NewInternationalLicense = 6 , RetakeTest = 7 
        };


       public enMode _Mode = enMode.AddNew;

       public enum  enApplicationStatus { New = 1 , Cancelled = 2 , Completed = 3  };

       public int _ApplicationID { get; set; }

       public int _PersonID { get; set; }

        public clsPeople _GetPeronInfo;

        public string ApplicantFullName
        {
            get { return clsPeople.Find(_PersonID).FullName; }
        }

        public DateTime ApplicationDate { get; set; }

        public int _ApplicationTypeId { get; set; }

        public clsApplicationType ApplicationTypeInfo;

        public enApplicationStatus _ApplicationStatus { get; set; }

        public string StatusText
        {

            get
            {

                switch (_ApplicationStatus)
                {

                    case enApplicationStatus.New:
                        return "New";

                    case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";

                    default:
                        return "Unknown";

                }

            }

        }

        public DateTime LastStatusDate { get; set; }

        public float PaidFees { get; set; }

        public int CreatedByUser { get; set; }

        public clsUsers UserInfo;

        public ClsApplication()
        {

            this._ApplicationID = -1;
            this._PersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this._ApplicationTypeId = -1;
            this._ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUser = -1;

        }

        private ClsApplication(int ApplicationId , int ApplicatPersonID , DateTime ApplicationDate , int ApplicationTypeID , enApplicationStatus ApplicationStatus , DateTime LastStatusDate , float PaidFees , int CreatedByUser)
        {

            this._ApplicationID = ApplicationId;
            this._PersonID = ApplicatPersonID;
            this._GetPeronInfo = clsPeople.Find(ApplicatPersonID);
            this.ApplicationDate = ApplicationDate;
            this._ApplicationTypeId = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this._ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUser = CreatedByUser;
            this.UserInfo = clsUsers.Find(CreatedByUser);
            _Mode = enMode.Update;

        }

        private bool _AddNewApplication()
        {

            this._ApplicationID = clsApplicationData.AddApplication(this._PersonID, this.ApplicationDate, this._ApplicationTypeId, (byte)this._ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUser);

            return this._ApplicationID != -1;

        }

        private bool _UpdateApplication()
        {

            return clsApplicationData.UpdateApplication(this._ApplicationID, this._PersonID, this.ApplicationDate, this._ApplicationTypeId, (byte)this._ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUser);
        }

        public static ClsApplication FindBaseApplication(int ApplicationID)
        {

            int PersonID = -1, ApplicationTypeID = -1, CreatedByUser = -1;

            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;

            float PaidFees = 0;

            byte ApplicationStatus = 0;

            if (clsApplicationData.GetAllApplicationByID(ApplicationID, ref PersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUser))

                return new ClsApplication(ApplicationID, PersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUser);
            else
                return null;

        }

        public bool Cancel()
        {

            return clsApplicationData.UpdateApplucationStatus(_ApplicationID, 2);

        }

        public bool SetComplete()
        {

            return clsApplicationData.UpdateApplucationStatus(_ApplicationID, 3);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;

        }

        public bool Delete()
        {
            return clsApplicationData.Delete(this._ApplicationID);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {

            return clsApplicationData.isApplicationExists(ApplicationID);

        }

        public static bool DoesPersonHaveActiveApplication(int Person , int ApplicationType)
        {

            return clsApplicationData.DoesPersonHaveActiveApplication(Person, ApplicationType);
        }

        public static int GetActiveApplicationID(int PersonID , ClsApplication.enApplicationType ApplicationType)
        {

            return clsApplicationData.GetActiveApplication(PersonID,(int) ApplicationType);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, ClsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }



    }
}
