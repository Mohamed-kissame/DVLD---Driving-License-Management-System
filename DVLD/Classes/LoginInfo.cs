using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private static string Encrypt(string Txt, int EncryptionShift = 2)
        {

            string Result = "";

            for (short i = 0; i < Txt.Length; i++)
            {

                Result += (char)((int)Txt[i] + EncryptionShift);

            }
            return Result;
        }

        private static string Decrypt(string Txt, int DecryptionShift = 2)
        {

            string Result = "";

            for (int i = 0; i < Txt.Length; i++)
            {

                Result += (char)((int)Txt[i] - DecryptionShift);

            }
            return Result;

        }


        public static bool RememberUserNameAndPassword(string UserName , string Password)
        {

            try
            {

                string currentDirec = System.IO.Directory.GetCurrentDirectory();

                string FilePath = currentDirec + "\\data.txt";

                if(UserName == "" && File.Exists(FilePath))
                {

                    File.Delete(FilePath);
                    return true;

                }

                string dataToSave = UserName + "#//#" + Encrypt(Password);

                using(StreamWriter writer = new StreamWriter(FilePath))
                {

                    writer.WriteLine(dataToSave);
                    return true;
                }

            }catch(Exception ex)
            {
                MessageBox.Show($"An Error :  { ex.Message}");

                return false;

            }

        }

        public static bool GetStoredInfo(ref string UserName , ref string Password)
        {

            try
            {

                string currntDirec = System.IO.Directory.GetCurrentDirectory();

                string FilePath = currntDirec + "\\data.txt";

                if (File.Exists(FilePath))
                {

                    using(StreamReader reader = new StreamReader(FilePath))
                    {

                        string Line;

                        while((Line = reader.ReadLine()) != null)
                        {

                            Console.WriteLine(Line);

                            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            UserName = result[0];
                            Password = Decrypt(result[1]);

                        }

                        return true;

                    }

                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {

                MessageBox.Show($"An Error :  {ex.Message}");

                return false;
            }
        }

    }
}
