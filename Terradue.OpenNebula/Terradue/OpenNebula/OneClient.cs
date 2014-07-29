using System;
using CookComputing.XmlRpc;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Terradue.OpenNebula {
    public partial class OneClient {

        /// <summary>
        /// Gets or sets the proxy URL.
        /// </summary>
        /// <value>The proxy URL.</value>
        private string ProxyUrl { get; set; }

        /// <summary>
        /// Gets or sets the admin username.
        /// </summary>
        /// <value>The admin username.</value>
        private string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the admin password.
        /// </summary>
        /// <value>The admin password.</value>
        private string AdminPassword { get; set; }

        /// <summary>
        /// Gets or sets the target username.
        /// </summary>
        /// <value>The target username.</value>
        public string TargetUsername { get; set; }


        /// <summary>
        /// Gets the session SHA.
        /// </summary>
        /// <value>The session SHA.</value>
        protected string SessionSHA { 
            get { 
                if (this.TargetUsername != null){
                    TimeSpan span= DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc));
                    return this.AdminUsername + ":" + this.TargetUsername + ":" + OpenSslAes.Encrypt(this.AdminUsername + ":" + this.TargetUsername + ":" + span.TotalSeconds + 3600 + "", this.AdminPassword);//Encryptor(this.AdminUsername + ":" + this.TargetUsername + ":" + "3600");
                }
                else
                    return this.AdminUsername + ":" + this.AdminPassword;
            } 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneUser"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneClient(string adminUsername, string adminPassword) {
            this.ProxyUrl = Configuration.XMLRPC_SERVER;
            this.AdminUsername = adminUsername;
            this.AdminPassword = adminPassword;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneClient"/> class.
        /// </summary>
        /// <param name="proxy">Proxy url of the XML RPC server</param>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneClient(string proxy, string adminUsername, string adminPassword) {
            if (proxy == null) throw new Exception("ONe XML RPC proxy url cannot be null");
            if (adminUsername == null) throw new Exception("ONe XML RPC user cannot be null");

            this.ProxyUrl = proxy;
            this.AdminUsername = adminUsername;
            this.AdminPassword = adminPassword;
        }
            
        /// <summary>
        /// Creates the proxy management object
        /// </summary>
        /// <returns>The proxy.</returns>
        /// <param name="type">Type.</param>
        public IXmlRpcProxy GetProxy(Type type){
            MethodInfo mi = typeof(XmlRpcProxyGen).GetMethod("Create", new Type[]{});
            MethodInfo gmi = mi.MakeGenericMethod(type);
            IXmlRpcProxy result = (IXmlRpcProxy)gmi.Invoke(null,null);
            result.Url = this.ProxyUrl;
            return result;
        }

        /// <summary>
        /// Deserializes the response.
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="type">Type.</param>
        /// <param name="response">Response.</param>
        private object Deserialize(Type type, string response){
            object result = null;

            try{
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(type);
                using (System.IO.MemoryStream s = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(response ?? ""))) {
                    result = ser.Deserialize(s);
                }
            }catch(Exception e){
                throw new Exception(response);
            }

            return result;
        }

        private string Encryptor(string TextToEncrypt)
        {
            //Turn the plaintext into a byte array.
            byte[] PlainTextBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(TextToEncrypt);            

            //Setup the AES providor for our purposes.
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();

            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 256;  
            //My key and iv that i have used in openssl
            aesProvider.Key = System.Text.Encoding.ASCII.GetBytes(this.AdminPassword);
            aesProvider.IV = System.Text.Encoding.ASCII.GetBytes(this.AdminPassword);  
            aesProvider.Padding = PaddingMode.PKCS7;
            aesProvider.Mode = CipherMode.CBC;

            ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor(aesProvider.Key, aesProvider.IV);            
            byte[] EncryptedBytes = cryptoTransform.TransformFinalBlock(PlainTextBytes, 0, PlainTextBytes.Length);
            return Convert.ToBase64String(EncryptedBytes);                        
        }

    }


    public class OpenSslAes
    {

        public static string AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }


        public static string Encrypt(string plainText, string passphrase)
        {
            byte[] key, iv;
//            var salt = new byte[8];
//            new RNGCryptoServiceProvider().GetNonZeroBytes(salt);
//
            using(var cryptoProvider = new SHA1CryptoServiceProvider())
            {
                key = cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
                iv = key;
            }

            return AES_Encrypt(Encoding.UTF8.GetBytes(plainText), key);

//            EvpBytesToKey(passphrase, salt, out key, out iv);
//            byte[] encryptedBytes = AesEncrypt(plainText, key, iv);
//
//            var encryptedBytesWithSalt = CombineSaltAndEncryptedData(encryptedBytes, salt);
//            return Convert.ToBase64String(encryptedBytes);
        }

        // OpenSSL prefixes the combined encrypted data and salt with "Salted__"
        private static byte[] CombineSaltAndEncryptedData(byte[] encryptedData, byte[] salt)
        {
            var encryptedBytesWithSalt = new byte[salt.Length + encryptedData.Length + 8];
            Buffer.BlockCopy(Encoding.UTF8.GetBytes("Salted__"), 0, encryptedBytesWithSalt, 0, 8);
            Buffer.BlockCopy(salt, 0, encryptedBytesWithSalt, 8, salt.Length);
            Buffer.BlockCopy(encryptedData, 0, encryptedBytesWithSalt, salt.Length + 8, encryptedData.Length);
            return encryptedBytesWithSalt;
        }
//
//        public static string Decrypt(string encrypted, string passphrase)
//        {
//            byte[] encryptedBytesWithSalt = Convert.FromBase64String(encrypted);
//
//            var salt = ExtractSalt(encryptedBytesWithSalt);
//            var encryptedBytes = ExtractEncryptedData(salt, encryptedBytesWithSalt);
//
//            byte[] key, iv;
//            EvpBytesToKey(passphrase, salt, out key, out iv);
//            return AesDecrypt(encryptedBytes, key, iv);
//        }
//
//
        // Pull the data out from the combined salt and data
        private static byte[] ExtractEncryptedData(byte[] salt, byte[] encryptedBytesWithSalt)
        {
            var encryptedBytes = new byte[encryptedBytesWithSalt.Length - salt.Length - 8];
            Buffer.BlockCopy(encryptedBytesWithSalt, salt.Length + 8, encryptedBytes, 0, encryptedBytes.Length);
            return encryptedBytes;
        }

        // The salt is located in the first 8 bytes of the combined encrypted data and salt bytes
        private static byte[] ExtractSalt(byte[] encryptedBytesWithSalt)
        {
            var salt = new byte[8];
            Buffer.BlockCopy(encryptedBytesWithSalt, 8, salt, 0, salt.Length);
            return salt;
        }

        // Key derivation algorithm used by OpenSSL
        //
        // Derives a key and IV from the passphrase and salt using a hash algorithm (in this case, MD5).
        //
        // Refer to http://www.openssl.org/docs/crypto/EVP_BytesToKey.html#KEY_DERIVATION_ALGORITHM
        private static void EvpBytesToKey(string passphrase, byte[] salt, out byte[] key, out byte[] iv)
        {
            var concatenatedHashes = new List<byte>(48);

            byte[] password = Encoding.UTF8.GetBytes(passphrase);
            byte[] currentHash = new byte[0];
            MD5 md5 = MD5.Create();
            bool enoughBytesForKey = false;

            while (!enoughBytesForKey)
            {
                int preHashLength = currentHash.Length + password.Length + salt.Length;
                byte[] preHash = new byte[preHashLength];

                Buffer.BlockCopy(currentHash, 0, preHash, 0, currentHash.Length);
                Buffer.BlockCopy(password, 0, preHash, currentHash.Length, password.Length);
                Buffer.BlockCopy(salt, 0, preHash, currentHash.Length + password.Length, salt.Length);

                currentHash = md5.ComputeHash(preHash);
                concatenatedHashes.AddRange(currentHash);

                if (concatenatedHashes.Count >= 48) enoughBytesForKey = true;
            }

            key = new byte[32];
            iv = new byte[16];
            concatenatedHashes.CopyTo(0, key, 0, 32);
            concatenatedHashes.CopyTo(32, iv, 0, 16);

            md5.Clear();
            md5 = null;
        }

        static byte[] AesEncrypt(string plainText, byte[] key, byte[] iv)
        {
            MemoryStream memoryStream;
            RijndaelManaged aesAlgorithm = null;

            try
            {
                aesAlgorithm = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 128,
                    Key = key,
                    IV = iv
                };

                var cryptoTransform = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);
                memoryStream = new MemoryStream();

                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
            }
            finally
            {
                if (aesAlgorithm != null) aesAlgorithm.Clear();
            }

            return memoryStream.ToArray();
        }

        static string AesDecrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            RijndaelManaged aesAlgorithm = null;
            string plaintext;

            try
            {
                aesAlgorithm = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 128,
                    Key = key,
                    IV = iv
                };

                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);

                using (var memoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            plaintext = streamReader.ReadToEnd();
                            streamReader.Close();
                        }
                    }
                }
            }
            finally
            {
                if (aesAlgorithm != null) aesAlgorithm.Clear();
            }

            return plaintext;
        }
    }

}

