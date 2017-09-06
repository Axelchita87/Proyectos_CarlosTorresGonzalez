using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace MyCTS.Presentation.Components
{
    public static class TransaccionesSecurity
    {
        private const string ivStr = "9W1jwst8c9fbHiG6XDvLEQ==";
        private const string keyStr = "9m80+F00uR2YI93rnXwTWOwbVZzGz8mfg7MmjIxcFTQ=";

        /// <summary>
        ///   Encripta una cadena.
        /// </summary>
        /// <param name="sCadenaSinEncriptar"> Cadena sin encriptar. </param>
        /// <returns> </returns>
        internal static string Encriptar(string sCadenaSinEncriptar)
        {
            AesManaged aesEncryption = new AesManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = Convert.FromBase64String(ivStr),
                Key = Convert.FromBase64String(keyStr)
            };
            byte[] plainText = Encoding.UTF8.GetBytes(sCadenaSinEncriptar);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            // The result of the encryption and decryption           
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
            return sCadenaSinEncriptar;
        }

        /// <summary>
        ///   Desencripta una cadena encriptada.
        /// </summary>
        /// <param name="CadenaEncriptada"> La cadena encriptada. </param>
        /// <returns> </returns>
        public static string Desencriptar(string CadenaEncriptada)
        {
            AesManaged aesEncryption = new AesManaged
                                           {
                                               KeySize = 256,
                                               BlockSize = 128,
                                               Mode = CipherMode.CBC,
                                               Padding = PaddingMode.PKCS7,
                                               IV = Convert.FromBase64String(ivStr),
                                               Key = Convert.FromBase64String(keyStr)
                                           };
            ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64CharArray(CadenaEncriptada.ToCharArray(), 0,
                                                                CadenaEncriptada.Length);
            return Encoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
        }
    }
}
