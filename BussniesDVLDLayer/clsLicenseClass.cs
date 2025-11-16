using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class clsLicenseClass
    {


        public int LicenseClassID { get; set; }

        public string ClassName { get; set;}

        public string ClassDescription { get; set; }

        public int MinAllowedAge { get; set; }

        public int DefaultLengethValidation { get; set; }

        public decimal classFess { get; set; }


        public clsLicenseClass()
        {

            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinAllowedAge = -1;
            DefaultLengethValidation = -1;
            classFess = -1;
        }
        private clsLicenseClass(int Id, string ClassName, string ClassDescription, int MinAllowedAge, int DefaultLengthValidation, decimal ClassFess)
        {

            this.LicenseClassID = Id;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinAllowedAge = MinAllowedAge;
            this.DefaultLengethValidation = DefaultLengthValidation;
            this.classFess = ClassFess;
        }

        public static clsLicenseClass Find(int ID)
        {

            string ClassName = "", ClassDescription = "";
            int MinAllowedAge = -1, DefaultLengthValidation = -1;
            decimal ClassFess = -1;

            if (ClsLicenseClassData.GetAllLicenseClassByID(ID, ref ClassName, ref ClassDescription, ref MinAllowedAge, ref DefaultLengthValidation, ref ClassFess))

                return new clsLicenseClass(ID, ClassName, ClassDescription, MinAllowedAge, DefaultLengthValidation, ClassFess);
            else
                return null;
          
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int ClassID = -1;
            string ClassDescription = "";
            int MinAllowedAge = -1, DefaultLengthValidation = -1;
            decimal ClassFess = -1;

            if (ClsLicenseClassData.GetAllLicenseClassByName(ClassName , ref ClassID, ref ClassDescription, ref MinAllowedAge, ref DefaultLengthValidation, ref ClassFess))

                return new clsLicenseClass(ClassID, ClassName, ClassDescription, MinAllowedAge, DefaultLengthValidation, ClassFess);
            else
                return null;

        }


        public static DataTable GetAllLicenseClass()
        {
            return ClsLicenseClassData.ListofLisenseClass();
        }

    }
}
