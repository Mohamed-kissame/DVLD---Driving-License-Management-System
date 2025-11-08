using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class clsTestType
    {


        public int Id { get; set; }

        public string TestName { get; set; }

        public string TestDescription { get; set; }

        public decimal TestFees { get; set; }


        clsTestType(int Id , string TestName , string TestDescription , decimal TestFees)
        {

            this.Id = Id;
            this.TestName = TestName;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
        }

        public static clsTestType Find(int ID)
        {

            string TestName = "", TestDescription = "";

            decimal TestFees = 0;

            if (ClsTestTypeData.GetAllTestByID(ID, ref TestName, ref TestDescription, ref TestFees))

                return new clsTestType(ID, TestName, TestDescription, TestFees);
            else

                return null;
        }


        public static DataTable GetAllTest()
        {

            return ClsTestTypeData.GetAllTests();
        }


        public bool Update()
        {

            return ClsTestTypeData.Update(this.Id, this.TestName, this.TestDescription, this.TestFees);
        }

    }
}
