using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class clsPepole
    {


        enum enMode { AddNew = 0 , Update = 1};

        private enMode _Mode = enMode.AddNew;

        public  int _PersonID { get; set; }

        public string _NationaleNumber { get; set; }

        public string _FirstNAme { get; set; }

        public string _SecondName { get; set; }

        public string _ThierdName { get; set; }

        public string _LastName { get; set; }

        public DateTime _BirthOfDate { get; set; }

        public string _Addrress { get; set; }

        public string _Phone { get; set; }

        public string _Email { get; set; }

        public int _Nationality { get; set; }

        public string _ImagePath { get; set; }

        public string FullName()
        {
            return _FirstNAme + " " + _SecondName + " " + _ThierdName + " " + _LastName;

        }

        public clsPepole()
        {

            _PersonID = -1;
            _NationaleNumber = "";
            _FirstNAme = "";
            _SecondName = "";
            _ThierdName = "";
            _LastName = "";
            _Gender = false;
            _BirthOfDate = DateTime.Now;
            _Addrress = "";
            _Phone = "";
            _Email = "";
            _Nationality = -1;
            _ImagePath = "";
            _Mode = enMode.AddNew;

        }
       
        private clsPepole(int PepoleID, string NationaelNumber , string FirstName , string SecondName , string ThierdName , string LastName 
            , DateTime BirthOfDate, bool Gender , string Address , string Phone , string Email , int Nationality, string IamgePath)
        {

            this._PersonID = PepoleID;
            this._NationaleNumber = NationaelNumber;
            this._FirstNAme = FirstName;
            this._SecondName = SecondName;
            this._ThierdName = ThierdName;
            this._LastName = LastName;
            this._BirthOfDate = BirthOfDate;
            this._Gender = Gender;
            this._Addrress = Address;
            this._Phone = Phone;
            this._Email = Email;
            this._Nationality = Nationality;
            this._ImagePath = IamgePath;

            _Mode = enMode.Update;
        }
        

        public static clsPepole Find(int PersonID)
        {
            string NationlaNo = "", FirstName = "", SecondName = "", ThierdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int Nationality = -1;
            bool Gender = false;

            if(clsPepoleData.GetAllPepolesByID(PersonID, ref NationlaNo, ref FirstName, ref SecondName, ref ThierdName, ref LastName
               , ref DateOfBirth , ref Gender, ref Address , ref Phone, ref Email, ref Nationality , ref ImagePath))

                return new clsPepole(PersonID, NationlaNo, FirstName, SecondName, ThierdName, LastName, DateOfBirth, Gender , Address, Phone, Email, Nationality, ImagePath);
            else
                return null;
        }

        private bool _AddNew()
        {

             this._PersonID = clsPepoleData.AddNewPerson(this._NationaleNumber, this._FirstNAme, this._SecondName, this._ThierdName, this._LastName,
                 this._BirthOfDate, this._Gender, this._Addrress, this._Phone, this._Email, this._Nationality, this._ImagePath);

            return (this._PersonID != -1);
        }


        private bool _Update()
        {

            return clsPepoleData.UpdatePerson(this._PersonID, this._NationaleNumber, this._FirstNAme, this._SecondName, this._ThierdName, this._LastName
                , this._BirthOfDate, this._Gender, this._Addrress, this._Phone, this._Email, this._Nationality, this._ImagePath);
        }
     
        public static bool DeletePerson(int ID)
        {

            return clsPepoleData.DeletePersonById(ID);
        }

        public static DataTable GetAllPepole()
        {

            return clsPepoleData.ListAllPepole();
        }


         public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();
            }

            return false;
        }


        public static bool isExistsByID(int ID)
        {

            return clsPepoleData.IsExistsByID(ID);
        }


        public static bool isExistsInUser(int PersonID)
        {
            return clsPepoleData.IsExistsInUser(PersonID);
        }

        public static bool isExistsByNationalNo(string NationalNo)
        {

            return clsPepoleData.IsExistsByNationalNo(NationalNo);
        }

    }
}
