using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniesDVLDLayer
{
    public class ClsDetained
    {

        public enum _enMode { Add = 0 , Update = 1}

        public _enMode Mode = _enMode.Add;


        public static DataTable GetAllDetainedLicense()
        {
            return DataAccessLayer.ClsDetainLicenseData.GetAllDetainedLicense();
        }


    }
}
