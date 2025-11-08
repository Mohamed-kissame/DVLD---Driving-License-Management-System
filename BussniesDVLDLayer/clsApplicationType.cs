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
    public class clsApplicationType
    {


        public int Id { get; set; }

        public string ApplicationName { get; set; }

        public decimal ApplicationFees { get; set; }


        clsApplicationType(int Id , string ApplicationType , decimal Fees)
        {

            this.Id = Id;
            this.ApplicationName = ApplicationType;
            this.ApplicationFees = Fees;
        }

        public static clsApplicationType Find(int ID)
        {

            string ApplicationType = "";
            decimal Fees = 0;

            if (ClsApplicationTypesData.GetAllApplicationByID(ID, ref ApplicationType, ref Fees))

                return new clsApplicationType(ID, ApplicationType, Fees);
            else

                return null;

        }

        public static DataTable GetALLApplicationType()
        {

            return ClsApplicationTypesData.ListApplicationType();
        }

        public bool Update()
        {

            return ClsApplicationTypesData.UpdateApplication(this.Id, this.ApplicationName, this.ApplicationFees);
        }

    }
}
