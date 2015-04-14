using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Web.Models
{
    static public class Security
    {
        public static string EncryptPassword(string txtPassword)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
            string encryptPassword = Convert.ToBase64String(passBytes);
            return encryptPassword;
        }
        /*
        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }*/
    }
}
