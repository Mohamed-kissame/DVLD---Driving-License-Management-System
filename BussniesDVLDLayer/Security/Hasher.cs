using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BussniesDVLDLayer.Security
{
    public class Hasher
    {


        public static string GenerateSalt()
        {

            byte[] salt = new byte[16];

            using(var rng = RandomNumberGenerator.Create())
            {

                rng.GetBytes(salt);

            }

            return Convert.ToBase64String(salt);

        }

        public static string HashPassword(string password , string salt)
        {

            string input = password + salt;

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] Hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(Hashbytes).Replace("-", "").ToLower();

            }

        }

        public static bool VerifyPassword(string enteredPassword,string storedHash, string storedSalt)
        {
            string newHash = HashPassword(enteredPassword, storedSalt);
            return newHash == storedHash;
        }




    }
}
