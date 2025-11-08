using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussniesDVLDLayer;

namespace DVLD.Classes
{
     internal static class LoginInfo
    {

        private static clsUsers _currentUser;

        public  static clsUsers SelectUserInfo { get { return _currentUser; } }

        public static void SetUser(clsUsers user)
        {
            _currentUser = user;
        }
    }
}
