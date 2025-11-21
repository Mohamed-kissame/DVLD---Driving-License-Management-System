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

        public enum enMode { AddNew = 0 , Update = 1}

        public enMode Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestType.enTestType Id { set; get; }

        public string TestName { get; set; }

        public string TestDescription { get; set; }

        public float TestFees { get; set; }


        clsTestType()
        {
            this.Id = clsTestType.enTestType.VisionTest;
            this.TestName = "";
            this.TestDescription = "";
            this.TestFees = 0;
            Mode = enMode.AddNew;
        }


        clsTestType(clsTestType.enTestType Id , string TestName , string TestDescription , float TestFees)
        {

            this.Id = Id;
            this.TestName = TestName;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {

            string TestName = "", TestDescription = "";

            float TestFees = 0;

            if (ClsTestTypeData.GetAllTestByID((int)TestTypeID, ref TestName, ref TestDescription, ref TestFees))

                return new clsTestType(TestTypeID, TestName, TestDescription, TestFees);
            else

                return null;
        }


        public static DataTable GetAllTest()
        {

            return ClsTestTypeData.GetAllTests();
        }

        

        public bool Update()
        {

            return ClsTestTypeData.Update((int)this.Id, this.TestName, this.TestDescription, this.TestFees);
        }

    }
}
