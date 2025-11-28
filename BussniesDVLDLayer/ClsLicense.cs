using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsLicense
    {


        public enum enMode { AddNew = 0 , Update = 1 };

        public enMode _Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1 , Renew = 2 , ReplacementForDamaged = 3 , ReplacementForLost = 4 };


        public int _LicenseID { get; set; }
        public int _ApplicationID { get; set; }

        public int _DriverID { get; set; }

        public int _LicnseClass { get; set; }

        public clsLicenseClass LicenseClassInfo;

        public DateTime _IssueDate { get; set; }

        public DateTime _ExperienceDate { get; set; }

        public string _Notes { get; set; }

        public float _PaidFees { get; set; }

        public bool _isActive { get; set; }

        public enIssueReason _issueReason { get; set; }

        public string issueReasonText
        {

            get
            {

              return  GetIssueReasonText(_issueReason);
                
            }
        }

        public int _CreatedByUserID { get; set; }

        public ClsLicense()
        {

            _LicenseID = -1;
            _ApplicationID = -1;
            _DriverID = -1;
            _LicnseClass = -1;
            _IssueDate = DateTime.Now;
            _ExperienceDate = DateTime.Now;
            _Notes = "";
            _PaidFees = 0;
            _isActive = false;
            _issueReason = enIssueReason.FirstTime;

            _Mode = enMode.AddNew;
        }

        private ClsLicense(int LicenseID , int ApplicationID , int DriverID , int LicenseClass , DateTime issueDate , DateTime expirationDate , string Notes , float PaidFees , bool isActive , enIssueReason issueReason , int CreatedByUserID)
        {

            this._LicenseID = LicenseID;
            this._ApplicationID = ApplicationID;
            this._DriverID = DriverID;
            this._LicnseClass = LicenseClass;
            this._IssueDate = issueDate;
            this._ExperienceDate = expirationDate;
            this._Notes = Notes;
            this._PaidFees = PaidFees;
            this._isActive = isActive;
            this._issueReason = issueReason;
            this._CreatedByUserID = CreatedByUserID;

            this.LicenseClassInfo = clsLicenseClass.Find(this._LicnseClass);

            _Mode = enMode.Update;
        }


        public static ClsLicense Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUser = -1;
            DateTime issueDate  = DateTime.Now , expirationDate = DateTime.Now ;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte issueReason = 1;


            if (ClsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref issueDate, ref expirationDate, ref Notes, ref PaidFees, ref IsActive, ref issueReason, ref CreatedByUser))

                return new ClsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, issueDate, expirationDate, Notes, PaidFees, IsActive, (enIssueReason)issueReason, CreatedByUser);
            else
                return null;

            

        }


        private bool _AddNewLicense()
        {

            this._LicenseID = ClsLicenseData.AddNewLicense(this._ApplicationID, this._DriverID, this._LicnseClass, this._IssueDate, this._ExperienceDate, this._Notes, this._PaidFees, this._isActive, (byte)this._issueReason, this._CreatedByUserID);

            return this._LicenseID != -1;

        }

        private bool _UpdateLicense()
        {

            return ClsLicenseData.UpdateLicense(this._LicenseID, this._ApplicationID, this._DriverID, this._LicnseClass, this._IssueDate, this._ExperienceDate, this._Notes, this._PaidFees, this._isActive, (byte)this._issueReason, this._CreatedByUserID);

        }

        public static DataTable GetAllLicenses()
        {

            return ClsLicenseData.GetAllLicenses();
        }

        public static DataTable GetAllDrivers(int Driver)
        {

            return ClsLicenseData.GetDriverLicense(Driver);
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {

            return (GetActiveLicenseIDByPersonID(PersonID , LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return ClsLicenseData.GetActiveLicenseIdByPerson(PersonID, LicenseClassID);
        }

        public Boolean IsLicenseExpired()
        {

            return (this._ExperienceDate < DateTime.Now);
        }

        public bool DesactiveLicense(int LicenseID)
        {

            return ClsLicenseData.DesactiveLicense(LicenseID);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                   return  _UpdateLicense();
            }

            return false;

        }


        public static string GetIssueReasonText(enIssueReason reason)
        {


            switch (reason)
            {

                case enIssueReason.FirstTime:
                    return "First Time";

                case enIssueReason.Renew:
                    return "Renew License";

                case enIssueReason.ReplacementForDamaged:
                    return "Replacement for Damaged";

                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";

                default:
                    return "First Time";

            }

        }

    }
}
