using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Win32;
using BussniesDVLDLayer;

namespace DVLD.Classes
{
     internal static class LoginInfo
    {

        private static clsUsers _currentUser;

        private static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

        private static string UserNameKey = "UserName";

        private static string PassWordKey = "Password";

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

        /// <summary>
        /// Saves the user's username and password into the Windows Registry.
        /// The password is encrypted before being stored for basic data protection.
        /// This method is typically used when the user enables a "Remember Me" feature.
        /// </summary>
        /// <param name="userName">The username to store in the Registry.</param>
        /// <param name="password">
        /// The plain text password that will be encrypted before storage.
        /// </param>
        /// <returns>
        /// True if the data was saved successfully; otherwise, false.
        /// </returns>
        public static bool SaveTheUsernameAndPasswordInRegistry(string UserName , string PassWord)
        {

            try
            {


                Registry.SetValue(KeyPath, UserNameKey, UserName, RegistryValueKind.String);

                Registry.SetValue(KeyPath, PassWordKey, Encrypt(PassWord), RegistryValueKind.String);

                return true;
                

            }catch(Exception ex)
            {
                MessageBox.Show($"An Error :  {ex.Message}");

                return false;
            }

        }


        /// <summary>
        /// Retrieves the stored username and password from the Windows Registry.
        /// If data exists, the password is decrypted and returned.
        /// This method allows automatic login or pre-filling login fields.
        /// </summary>
        /// <param name="userName">
        /// A reference parameter that receives the stored username.
        /// </param>
        /// <param name="password">
        /// A reference parameter that receives the decrypted password.
        /// </param>
        /// <returns>
        /// True if stored credentials were found; otherwise, false.
        /// </returns>
        public static bool GetStoreInfoFromRegistry(ref string UserName , ref string PassWord)
        {

            try
            {

                string NodeUserName = Registry.GetValue(KeyPath, UserNameKey, null) as string;

                string NodePassWord = Registry.GetValue(KeyPath, PassWordKey, null) as string;

                if (NodeUserName != null && (NodePassWord != null))
                {

                    UserName = NodeUserName;
                    PassWord = Decrypt(NodePassWord);

                    return true;

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

        /// <summary>
        /// [DEPRECATED] Saves the username and password to a local text file.
        /// This method is no longer used in the project and has been replaced
        /// by a Registry-based implementation.
        /// </summary>
        /// <remarks>
        /// This method stored user credentials in a file named "data.txt"
        /// located in the application's current directory.
        /// The password was encrypted before being written to the file.
        /// 
        /// Reason for deprecation:
        /// - File-based storage is less secure
        /// - Users can easily access or modify the file
        /// - Registry storage provides better integration for Windows applications
        /// </remarks>
        /// <param name="UserName">The username to store in the file.</param>
        /// <param name="Password">
        /// The plain text password that is encrypted before being written.
        /// </param>
        /// <returns>
        /// True if the operation succeeded; otherwise, false.
        /// </returns>

        [Obsolete("This file-based method is deprecated and no longer used. Credential storage has been migrated to a Registry-based implementation.")]
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

        /// <summary>
        /// [DEPRECATED] Retrieves the stored username and password from a local file.
        /// This method is no longer used and has been replaced by reading from
        /// the Windows Registry.
        /// </summary>
        /// <remarks>
        /// The method reads data from "data.txt", splits the stored values
        /// using a custom delimiter, and decrypts the password before returning it.
        /// 
        /// Reason for deprecation:
        /// - File-based credential storage is less reliable
        /// - Harder to manage across different user environments
        /// - Registry-based storage is more suitable for this application
        /// </remarks>
        /// <param name="UserName">
        /// A reference parameter that receives the stored username.
        /// </param>
        /// <param name="Password">
        /// A reference parameter that receives the decrypted password.
        /// </param>
        /// <returns>
        /// True if stored data was found; otherwise, false.
        /// </returns>
        /// 
        [Obsolete("This method is deprecated. Stored login information is now retrieved from the Windows Registry instead of local files.")]

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
