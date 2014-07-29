using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Terradue.OpenNebula {
    public class OpenSslAes
    {

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="PlainText">Text to be encrypted</param>
        /// <param name="Password">Password to encrypt with</param>
        /// <param name="Salt">Salt to encrypt with</param>
        /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
        /// <param name="PasswordIterations">Number of iterations to do</param>
        /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
        /// <param name="KeySize">Can be 128, 192, or 256</param>
        /// <returns>An encrypted string</returns>
        public static string Encrypt(string PlainText, string Password,
                                     string Salt = "Kosher", string HashAlgorithm = "SHA1",
                                     int PasswordIterations = 2048, string InitialVector = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0",
                                     int KeySize = 256){
            if (string.IsNullOrEmpty(PlainText))
                return "";
            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
            byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
            string hash = "";
            byte[] KeyBytes = null;
            using(var cryptoProvider = new SHA1CryptoServiceProvider())
            {
                hash = BitConverter
                    .ToString(cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(Password))).Replace("-", "").ToLower();
            }
            Array.Resize<byte>(ref KeyBytes, KeySize / 8);
            KeyBytes = Encoding.UTF8.GetBytes(hash.ToCharArray(), 0, KeySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;
            SymmetricKey.KeySize = KeySize;
            SymmetricKey.Padding = PaddingMode.PKCS7;
            byte[] CipherTextBytes = null;
            using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                    {
                        CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                        CryptoStream.FlushFinalBlock();
                        CipherTextBytes = MemStream.ToArray();
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            SymmetricKey.Clear();
            return Convert.ToBase64String(CipherTextBytes);
        }
    }
}

