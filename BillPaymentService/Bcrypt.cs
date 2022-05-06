using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BillPaymentService
{
    public class Bcrypt
    {
        private string authCode = System.Configuration.ConfigurationManager.AppSettings["AuthCode"];
        private string APIkey = System.Configuration.ConfigurationManager.AppSettings["Apikey"];


        public string generateBCrypthash()
        {
            var stringtohash = authCode + APIkey;
            var hash = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(stringtohash, DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt(12));
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(hash));
        }

    }
}



















//private static string GetRandomSalt()
//{
//    return DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt(12);
//}

//public static string HashPassword(string password)
//{
//    return DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(password, GetRandomSalt());
//}

//public static string ValidatePassword(string stringtoHash)
//{
//    return DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(stringtoHash, DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt(12));
//}