using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static BussniesDVLDLayer.ClsApplication;

namespace BussniesDVLDLayer
{
    public class ClsInternationalLicense : ClsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;

        public ClsDriver DriverInfo;
        public int _InternationalLicenseID { get; set; }

        public int _DriverID { get; set; }

        public int _IssuedUsingLocalLicenseID { get; set; }

        public DateTime _IssueDate { get; set; }

        public DateTime _ExpirationDate { get; set; }

        public bool _IsActive { get; set; }

       


        public ClsInternationalLicense()
        {
            this._ApplicationTypeId = (int)ClsApplication.enApplicationType.NewInternationalLicense;
            this._InternationalLicenseID = -1;
            this._DriverID = -1;
            this._IssuedUsingLocalLicenseID = -1;
            this._IssueDate = DateTime.Now;
            this._ExpirationDate = DateTime.Now;
            this._IsActive = true;
           
            Mode = enMode.AddNew;

        }

        private ClsInternationalLicense(int InternationalID, int ApplicationID, int Driver, int IssuedUsingLocalLIcenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int ApplicatPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUser) : base(ApplicationID, ApplicatPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUser)
        {

            base._ApplicationTypeId = (int)ClsApplication.enApplicationType.NewInternationalLicense;

            this._InternationalLicenseID = InternationalID;
            this._DriverID = Driver;
            this._IssuedUsingLocalLicenseID = IssuedUsingLocalLIcenseID;
            this._IssueDate = IssueDate;
            this._ExpirationDate = ExpirationDate;
            this._IsActive = IsActive;
            this._CreatedByUser = CreatedByUser;
            Mode = enMode.Update;

            this.DriverInfo = ClsDriver.FindByDriverID(this._DriverID);
        }

        public static ClsInternationalLicense Find(int InternationaLicenseID)
        {
            int ApplID = -1, Driver = -1, IssuedUsingLocalLIcenseID = -1, CreatedByUser = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            bool isFound = ClsInternationalLicenseData.GetAllInternationalLicenseByID(InternationaLicenseID, ref ApplID, ref Driver, ref IssuedUsingLocalLIcenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUser);

            if (isFound)
            {

                ClsApplication application = ClsApplication.FindBaseApplication(ApplID);


                return new ClsInternationalLicense(InternationaLicenseID, ApplID, Driver, IssuedUsingLocalLIcenseID, IssueDate, ExpirationDate, IsActive, application._PersonID, application.ApplicationDate, application._ApplicationTypeId, (enApplicationStatus)application._ApplicationStatus, application.LastStatusDate, application.PaidFees, CreatedByUser);

            }
            else

                return null;


        }

        public static DataTable GetAllInternationalLicense()
        {

            return ClsInternationalLicenseData.GetAllInternationalLicenses();
        }

        private bool _AddNewInternationalLicense()
        {
            this._InternationalLicenseID = ClsInternationalLicenseData.AddNewInternationalLicense(this._ApplicationID,this._DriverID, this._IssuedUsingLocalLicenseID, this._IssueDate, this._ExpirationDate, this._IsActive, this._CreatedByUser);
            return (this._InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return ClsInternationalLicenseData.UpdateInternationalLicense(this._InternationalLicenseID ,this._ApplicationID, this._DriverID , this._IssuedUsingLocalLicenseID, this._IssueDate, this._ExpirationDate, this._IsActive, this._CreatedByUser);

        }

        public bool Save()
        {

            base._Mode = (ClsApplication.enMode)Mode;

            if(!base.Save())
                return false;

            switch (Mode)
            {

                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateInternationalLicense();
                
                 
            }

            return false;
        }

        public static int GetActiveInternationalLicenseCount(int DriverID)
        {
            return ClsInternationalLicenseData.GetActiveInternationalLicenseID(DriverID);
        }

    }
}
