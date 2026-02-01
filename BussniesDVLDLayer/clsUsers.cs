using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BussniesDVLDLayer.Security;
using DataAccessLayer;

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

        public string _Salt { get; set; }

        public bool _IsActive { get; set; }


        public clsUsers()
        {

            _UserID = -1;
            _PersonID = -1;
            _UserName = "";
            _Password = "";
            _Salt = "";
            _IsActive = false;

            _Mode = enMode.AddNew;
        }


        private clsUsers(int UserID , int PersonID , string UserName , string Password , string salt , bool IsActive)
        {

            this._UserID = UserID;
            this._PersonID = PersonID;
            this._UserName = UserName;
            this._Password = Password;
            this._Salt = salt;
            this._IsActive = IsActive;

            _Mode = enMode.Update;
        }

        public static clsUsers Find(int UserID)
        {

            int PersonID = -1;
            string UserName = "", PaasWord = "" , Salt = "";
            bool IsActive = false;

            if (clsUsersData.GetAllUsersByID(UserID, ref PersonID, ref UserName, ref PaasWord,ref Salt , ref IsActive))

                return new clsUsers(UserID, PersonID, UserName, PaasWord, Salt,IsActive);
            else

                return null;

        }

        public static clsUsers Find(string Username)
        {

            int UserID = -1, PersonID = -1;
            string PaasWord = "" , Salt = "";
            bool IsActive = false;

            if (clsUsersData.GetAllUsersByUserName(Username, ref UserID, ref PersonID, ref PaasWord, ref Salt, ref IsActive))

                return new clsUsers(UserID, PersonID, Username, PaasWord, Salt, IsActive);
            else

                return null;

        }

        public static clsUsers FindByUsernameAndPassword(string Username , string Password)
        {

            int UserID = -1, PersonID = -1;
            string StoredHash = "" , Salt = "";
            bool IsActive = false;

            if (clsUsersData.GetUserInfoBuUsernameAndPassword(Username, ref UserID, ref PersonID , ref StoredHash, ref Salt , ref IsActive))
            {

                if (Security.Hasher.VerifyPassword(Password, StoredHash, Salt))
                {
                    return new clsUsers(UserID, PersonID, Username, StoredHash, Salt, IsActive);
                }

               

            }
          
                return null;

        }

        private  bool _AddNewUser() {

            this._Salt = Security.Hasher.GenerateSalt();

           
            this._Password = Security.Hasher.HashPassword(this._Password, this._Salt);

            this._UserID = clsUsersData.AddNewUser(this._PersonID, this._UserName, this._Password, this._Salt , this._IsActive);

            return (this._UserID != -1);

        }

        private bool _UpdateUser()
        {

            string Salt = Security.Hasher.GenerateSalt();
            string Hash = Security.Hasher.HashPassword(this._Password, Salt);

            return clsUsersData.UpdateUser( this._UserID, this._UserName, Hash , this._Salt, this._IsActive);
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

        public static DataTable  GetAllUsers()
        {

            return clsUsersData.ListUsers();
        }

        public static bool UserIsExistsWithPassword(string UserName , string Password)
        {

            return clsUsersData.UserIsExists(UserName, Password);
        }

        public static bool ChangePassword(int UserId , string Password)
        {


            string salt = Security.Hasher.GenerateSalt();
            string hash = Security.Hasher.HashPassword(Password, salt);

            return clsUsersData.ChangePassword(UserId, hash,salt);

        }


    }
}
