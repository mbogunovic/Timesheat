using System;
using System.Security.Cryptography;
using System.Text;

namespace TimeshEAT.Business.Helpers
{
    public class StringHasher
    {
        public static string GenerateHash(string input)
        {
            using (MD5 _md5 = MD5.Create())
            {
                string hash = "";
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = _md5.ComputeHash(inputBytes);

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hash += hashBytes[i].ToString("x2");
                }

                return hash;
            }
        }

        public static bool VerifyHash(string input, string hashedInput)
        {
            string inputHashed = GenerateHash(input);

            return string.Equals(inputHashed, hashedInput, StringComparison.Ordinal);
        }
    }
}
