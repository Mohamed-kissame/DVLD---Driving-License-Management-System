using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniesDVLDLayer
{
    public class clsUsers
    {

         enum enMode { AddNew = 0 , Update = 1}

        private enMode _Mode = enMode.AddNew;

        public int _UserID { get; set; }

        public int _PersonID { get; set; }

        public string _UserName { get; set; }

        public string _Password { get; set; }

        public bool _IsActive { get; set; }


        public clsUsers()
        {

            _UserID = -1;
            _PersonID = -1;
            _UserName = "";
            _Password = "";
            _IsActive = false;

            _Mode = enMode.AddNew;
        }


        private clsUsers(int UserID , int PersonID , string UserName , string Password , bool IsActive)
        {

            this._UserID = UserID;
            this._PersonID = PersonID;
            this._UserName = UserName;
            this._Password = Password;
            this._IsActive = IsActive;

            _Mode = enMode.Update;
        }

        public static clsUsers Find(int UserID)
        {

            int PersonID = -1;
            string UserName = "", PaasWord = "";
            bool IsActive = false;

            if (clsUsersData.GetAllUsersByID(UserID, ref PersonID, ref UserName, ref PaasWord, ref IsActive))

                return new clsUsers(UserID, PersonID, UserName, PaasWord, IsActive);
            else

                return null;

        }

        public static clsUsers Find(string Username)
        {

            int UserID = -1, PersonID = -1;
            string PaasWord = "";
            bool IsActive = false;

            if (clsUsersData.GetAllUsersByUserName(Username, ref UserID, ref PersonID, ref PaasWord, ref IsActive))

                return new clsUsers(UserID, PersonID, Username, PaasWord, IsActive);
            else

                return null;

        }

        private  bool _AddNewUser() {


            this._UserID = clsUsersData.AddNewUser(this._PersonID, this._UserName, this._Password, this._IsActive);

            return (this._UserID != -1);

        }

        private bool _UpdateUser()
        {

            return clsUsersData.UpdateUser( this._UserID, this._UserName, this._Password, this._IsActive);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:

                    if (_AddNewUser())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateUser();
            }

            return false;
        }

        public static bool DeleteUser(int UserID)
        {

            return clsUsersData.DeleteUser(UserID);
        }

        public static DataTable GetAllUsers()
        {

            return clsUsersData.ListUsers();
        }

        public static bool UserIsExistsWithPassword(string UserName , string Password)
    {
    }
}
