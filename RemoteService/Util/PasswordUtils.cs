using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/* *
 * Hashing solution source:
 * http://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
 * */
namespace RemoteService.Util
{
    public static class PasswordUtils
    {
        public static string Encode(string password)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[16];
            provider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool IsCorrect(string hashPassword, string password)
        {
            byte[] hashBytes = Convert.FromBase64String(hashPassword);
            byte[] salt = new byte[16];
            byte[] target = new byte[20];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            Array.Copy(hashBytes, 16, target, 0, 20);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            return StructuralComparisons.StructuralEqualityComparer.Equals(target, hash);
        }
    }
}