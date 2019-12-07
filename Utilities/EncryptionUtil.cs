
using System;
using System.Security.Cryptography;
using System.Text;

namespace RandomizerLib.Utilities
{
    public class EncryptionUtil
    {
        public string Encrypt(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider cryptoProvider = new MD5CryptoServiceProvider();
            byte[] byteHash = cryptoProvider.ComputeHash(bytes);

            string hash = string.Empty;
            
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}