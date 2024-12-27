using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Helpers
{
    public static class HashHelper
    {
        const int keySize = 64;
        const int iterations = 350000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string HashPasword(string password )//out byte[] salt)
        {
            byte[] salt = Encoding.UTF8.GetBytes("Hi");
            

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            byte[] salt = Encoding.UTF8.GetBytes("Hi");
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        //public static string SHA256Hash(string value)
        //{
        //    string salt = "Salam";
        //    value = salt + value + salt.Reverse();

        //    using (SHA256 hash = SHA256.Create())
        //    {
        //        byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
        //        StringBuilder builder = new StringBuilder();

        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }

        //    return builder.ToString();
        //    }

        //}
        //public static byte[] SHA256HashByte(string value)
        //{

        //    using (SHA256 hash = SHA256.Create())
        //    {
        //        byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
        //        return bytes;
        //    }

        //}

    }
}
