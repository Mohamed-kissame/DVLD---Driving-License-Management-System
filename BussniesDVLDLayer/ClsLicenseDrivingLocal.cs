using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsLicenseDrivingLocal : ClsApplication
    {


        public int LicenseDrivingLocalId { get; set; }

        public int ApplicationID {get; set; }

        public int LicenseClassID { get; set; }


        public static DataTable GetAllLicense()
        {

            return ClsLicenseDrivingLocalData.ListOfLicenseDriving();
        }



    }
}
