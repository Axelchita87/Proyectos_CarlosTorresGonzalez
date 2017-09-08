using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.BR
{
    public class BREncripcion
    {
        public static Byte[] v = { 0x15, 0x32, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x92, 0xAB, 0xCD, 0xEF };
        public static string k = "b3vdz33M+9AMYV7dAzfEW66JbWYBoF3xlV/0bR958nk=";

        public static string encript2(string cad)
        {
            RijndaelManaged rij = (RijndaelManaged)RijndaelManaged.Create();
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            byte[] cypher = Encoding.UTF8.GetBytes(cad);

            try
            {

                rij.KeySize = rij.LegalKeySizes[rij.LegalKeySizes.Length - 1].MaxSize;
                rij.IV = v;
                rij.Key = Convert.FromBase64String(k);
                CryptoStream crytpo = new CryptoStream(memory, rij.CreateEncryptor(), CryptoStreamMode.Write);
                crytpo.Write(cypher, 0, cypher.Length);
                crytpo.Close();
                return Convert.ToBase64String(memory.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string decript2(string cad)
        {
            RijndaelManaged rij = (RijndaelManaged)RijndaelManaged.Create();
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            byte[] cypher = new Byte[cad.Length];
            try
            {
                rij.KeySize = rij.LegalKeySizes[rij.LegalKeySizes.Length - 1].MaxSize;
                rij.Key = Convert.FromBase64String(k);
                rij.IV = v;
                cypher = Convert.FromBase64String(cad);
                CryptoStream crypto = new CryptoStream(memory, rij.CreateDecryptor(), CryptoStreamMode.Write);
                crypto.Write(cypher, 0, cypher.Length);
                crypto.Close();
                return Encoding.UTF8.GetString(memory.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
