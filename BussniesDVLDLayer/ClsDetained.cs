using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsDetained
    {

        public enum _enMode { Add = 0 , Update = 1}

        public _enMode Mode = _enMode.Add;

        public int DetainID { get; set; }

        public int LicenseID { get; set; }

        public DateTime DetainDate { get; set; }

        public float FineFees { get; set; }

        public int CreatedByUserID { get; set; }

        public clsUsers CreatedUserInfo;

        public bool IsReleased { get; set; }

        public DateTime? ReleasedDate { get; set; }

        public int? ReleaseByUserID { get; set; }

        public clsUsers ReleaseUserInfo;

        public int? ReleaseApplicationID { get; set; }


        public ClsDetained()
        {

            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = true;
            this.ReleasedDate = null;
            this.ReleaseByUserID = null;
            this.ReleaseApplicationID = null;

            Mode = _enMode.Add;


        }

        private ClsDetained(int DetainId , int LicenseID , DateTime DetainDate , float FineFees , int CreatedByUserID , bool IsReleased , DateTime? ReleaseDate , int? ReleaseByUserID , int? ReleaseApplicationID)
        {

            this.DetainID = DetainId;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedUserInfo = clsUsers.Find(this.CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleasedDate = ReleaseDate;
            this.ReleaseByUserID = ReleaseByUserID;

            this.ReleaseUserInfo = this.ReleaseByUserID.HasValue ? clsUsers.Find(this.ReleaseByUserID.Value) : null;
         

            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = _enMode.Update;

        }


        public static ClsDetained Find(int DetainID)
        {

            int LicenseID = -1, CreatedByUserID = -1;
            
            DateTime DetainDate = DateTime.Now;

            float FineFees = 0;

            bool IsReleased = false;

            int? ReleaseApplicationsID = null;
            int? ReleaseByUserID = null;
            DateTime? ReleaseDate = null;

            

            if (ClsDetainLicenseData.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleaseByUserID, ref ReleaseApplicationsID))

                return new ClsDetained(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationsID);

            else

                return null;

        }

        public static ClsDetained FindByLicenseID(int LicenseID)
        {

            int DetainID = -1, CreatedByUserID = -1; int? ReleaseByUserID = null, ReleaseApplicationsID = null;

            DateTime DetainDate = DateTime.Now; DateTime? ReleaseDate = null;

            float FineFees = 0;

            bool IsReleased = false;

            if (ClsDetainLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleaseByUserID, ref ReleaseApplicationsID))

                return new ClsDetained(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationsID);

            else

                return null;

        }

        private bool _AddDetainLicense()
        {

            this.DetainID = ClsDetainLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

            return this.DetainID != 0;

        }

        private bool _UpdateDetainLicense()
        {

            return ClsDetainLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case _enMode.Add:
                    if (_AddDetainLicense())
                    {
                        Mode = _enMode.Update;

                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case _enMode.Update:

                    return _UpdateDetainLicense();

            }

            return false;

        }


        public static DataTable GetAllDetainedLicense()
        {
            return DataAccessLayer.ClsDetainLicenseData.GetAllDetainedLicenses();
        }

        public static bool IsLicenseDetained(int LicenseID)
        {

            return ClsDetainLicenseData.IsLicenseDetained(LicenseID);

        }

        public bool ReleaseDetainLicense(int ReleasedByUserID ,int ReleaseApplicationID)
        {

            return ClsDetainLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleaseApplicationID);

        }


    }
}
