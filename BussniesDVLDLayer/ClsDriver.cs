using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsDriver
    {

        public enum enMode { AddNew = 0 , Update = 1 }

        public enMode _Mode = enMode.AddNew;

        public clsPeople _PersonInfo;

        public int _DriverID { get; set; }

        public int _PersonID { get; set; }

        public int _CreatedByUserID { get; set; }

        public DateTime _CreatedDAte { get; }

        public ClsDriver()
        {

            this._DriverID = -1;
            this._PersonID = -1;
            this._CreatedByUserID = -1;
            this._CreatedDAte = DateTime.Now;

            _Mode = enMode.AddNew;
        }

        private  ClsDriver(int DriverID , int PersonId , int CreatedByUserID , DateTime CreatedDate)
        {

            this._DriverID = DriverID;
            this._PersonID = PersonId;
            this._PersonInfo = clsPeople.Find(PersonId);
            this._CreatedByUserID = CreatedByUserID;
            this._CreatedDAte = CreatedDate;

            _Mode = enMode.Update;

        }

        public static ClsDriver FindByDriverID(int DriverID)
        {

            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (ClsDriverData.GetAllDriverByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new ClsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);

            else
                return null;


        }

        public static ClsDriver FindByPersonID(int PersonID)
        {

            int DriverID = -1, CreatedByUserID = -1;

            DateTime CreatedDate = DateTime.Now;

            if (ClsDriverData.GetAllDriverByPersonID(PersonID, ref DriverID,ref CreatedByUserID,ref CreatedDate))

                return new ClsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }


        public static DataTable GetAllDrivers()
        {

            return ClsDriverData.GetAllDrivers();


        }

        private bool _AddNewDriver()
        {

            this._DriverID = ClsDriverData.AddNewDriver(this._PersonID, this._CreatedByUserID, this._CreatedDAte);

            return this._DriverID != -1;
        }

        private bool UpdateDriver()
        {

            return ClsDriverData.UpdateDriver(this._DriverID, this._PersonID, this._CreatedByUserID, this._CreatedDAte);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return UpdateDriver();

            }

            return false;

        }

    }
}
