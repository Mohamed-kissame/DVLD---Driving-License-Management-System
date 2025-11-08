using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class clsPeople
    {

        enum enMode { AddNew = 0 , Update = 1};

        private enMode _Mode = enMode.AddNew;

        public  int _PersonID { get; set; }

        public string _NationaleNumber { get; set; }

        public string _FirstNAme { get; set; }

        public string _SecondName { get; set ; }

        public string _ThierdName { get; set; }

        public string _LastName { get; set; }

        public DateTime _BirthOfDate { get; set; }

        public string _Gender { get; set; }

        public string _Addrress { get; set; }

        public string _Phone { get; set; }

        public string _Email { get; set; }

        public int _Nationality { get; set; }

        public string _ImagePath { get; set; }

        public string FullName
        {
            get
            {

                if (!string.IsNullOrEmpty(_SecondName) && string.IsNullOrEmpty(_ThierdName))

                    return _FirstNAme + " " + _SecondName + " " + _ThierdName + " " + _LastName;

                else

                    return _FirstNAme + " " + _LastName;
            }
        }


        public clsPeople()
        {

            _PersonID = -1;
            _NationaleNumber = "";
            _FirstNAme = "";
            _SecondName = "";
            _ThierdName = "";
            _LastName = "";
            _Gender = "";
            _BirthOfDate = DateTime.Now;
            _Addrress = "";
            _Phone = "";
            _Email = "";
            _Nationality = -1;
            _ImagePath = "";
            _Mode = enMode.AddNew;

        }
       
        private clsPeople(int PepoleID, string NationaelNumber , string FirstName , string SecondName , string ThierdName , string LastName 
            , DateTime BirthOfDate, string Gender , string Address , string Phone , string Email , int Nationality, string IamgePath)
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
        

        public static clsPeople Find(int PersonID)
        {
            string NationlaNo = "", FirstName = "", SecondName = "", ThierdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int Nationality = -1;
            string Gender = "";

            if(clsPeopleData.GetAllPepolesByID(PersonID, ref NationlaNo, ref FirstName, ref SecondName, ref ThierdName, ref LastName
               , ref DateOfBirth , ref Gender, ref Address , ref Phone, ref Email, ref Nationality , ref ImagePath))

                return new clsPeople(PersonID, NationlaNo, FirstName, SecondName, ThierdName, LastName, DateOfBirth, Gender , Address, Phone, Email, Nationality, ImagePath);
            else
                return null;
        }

        public static clsPeople Find(string NationalNo)
        {
           string FirstName = "", SecondName = "", ThierdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PesronId = -1 ,Nationality = -1;
            string Gender = "";

            if (clsPeopleData.GetAllPepolesByNational(NationalNo, ref PesronId , ref FirstName, ref SecondName, ref ThierdName, ref LastName
               , ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref Nationality, ref ImagePath))

                return new clsPeople(PesronId, NationalNo, FirstName, SecondName, ThierdName, LastName, DateOfBirth, Gender, Address, Phone, Email, Nationality, ImagePath);
            else
                return null;
        }

        private bool _AddNew()
        {

             this._PersonID = clsPeopleData.AddNewPerson(this._NationaleNumber, this._FirstNAme, this._SecondName, this._ThierdName, this._LastName,
                 this._BirthOfDate, this._Gender, this._Addrress, this._Phone, this._Email, this._Nationality, this._ImagePath);

            return (this._PersonID != -1);
        }


        private bool _Update()
        {

            return clsPeopleData.UpdatePerson(this._PersonID, this._NationaleNumber, this._FirstNAme, this._SecondName, this._ThierdName, this._LastName
                , this._BirthOfDate, this._Gender, this._Addrress, this._Phone, this._Email, this._Nationality, this._ImagePath);
        }
     
        public static bool DeletePerson(int ID)
        {

            return clsPeopleData.DeletePersonById(ID);
        }

        public static DataTable GetAllPepole()
        {

            return clsPeopleData.ListAllPepole();
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

            return clsPeopleData.IsExistsByID(ID);
        }


        public static bool isExistsInUser(int PersonID)
        {
            return clsPeopleData.IsExistsInUser(PersonID);
        }

        public static bool isExistsByNationalNo(string NationalNo)
        {

            return clsPeopleData.IsExistsByNationalNo(NationalNo);
        }

    }
}
