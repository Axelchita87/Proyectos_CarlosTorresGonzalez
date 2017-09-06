using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ADMIN2.Entity;
using ADMIN2.BR;
using ADMIN2.DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Configuration;

using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data;
using System.Windows.Input;
using System.Reflection;

namespace ADMIN2.Controls
{
    public class Utils
    {
        public static DateTime fechaNula = Convert.ToDateTime("01/01/0001");
        //public static Ent_ConfigPersonal ppalcong = new Entity.Ent_ConfigPersonal();
        public static string decriptD(string Codigo, string Texto)
        {
            string kPos = "VRAELQXGDCWSNPZTHMUJKYFBOI";
            int intOffset, intMod, intLetra, intMueve;
            string strTmp, strTexto, strLetra, res;
            strTmp = strTexto = strLetra = res = string.Empty;
            try
            {
                Codigo = Codigo.Trim();
                Texto = Texto.Trim();
                intOffset = Convert.ToInt32(Codigo.Substring(1, 1));
                if (intOffset == 0)
                    intOffset = 10;
                intMod = Convert.ToInt32(Codigo.Substring(Codigo.Length - 1, 1));
                if (Texto.Length > 0)
                {
                    strTexto = string.Empty;
                    for (intLetra = Texto.Length - 1; intLetra >= 0; intLetra--)
                        strTexto += Texto.Substring(intLetra, 1);

                    for (intLetra = 0; intLetra < strTexto.Length; intLetra++)
                    {
                        strLetra = strTexto.Substring(intLetra, 1);
                        if ((int)Convert.ToChar(strLetra) >= 65 && (int)Convert.ToChar(strLetra) <= 90)
                        {
                            intMueve = kPos.IndexOf(strLetra.ToUpper()) - intMod - ((intLetra + 1) % 10);
                            if (intMueve < 0)
                                intMueve += kPos.Length;
                            strLetra = Convert.ToChar(intMueve + 65).ToString();
                        }
                        else if ((int)Convert.ToChar(strLetra) >= 97 && (int)Convert.ToChar(strLetra) <= 122)
                        {
                            intMueve = kPos.IndexOf(strLetra.ToUpper()) - intMod - ((intLetra + 1) % 10);
                            if (intMueve < 0)
                                intMueve += kPos.Length;
                            strLetra = Convert.ToChar(intMueve + 97).ToString();
                        }
                        else if (strLetra == Convert.ToChar(96).ToString())
                            strLetra = Convert.ToChar(32).ToString();
                        strTmp += strLetra;

                    }
                    intLetra = Texto.Length - intOffset + 1;
                    while (intLetra < 1)
                    {
                        intLetra += Texto.Length;
                    }
                    strTexto = strTmp.Substring(intLetra) + strTmp.Substring(0, intLetra);
                }
                else
                    strTexto = string.Empty;
                res = strTexto;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #region Ventanas y llenado de grid genericos

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            try
            {
                return string.IsNullOrEmpty(name)
                   ? Application.Current.Windows.OfType<T>().Any()
                   : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static System.Collections.IEnumerable LlenaGridGenerico<T>(string currentColname, object SearchSource, List<Filter> filter,
            ListSortDirection _sortDirection, ref DataGrid dgrid) where T : class
        {
            try
            {
                List<T> convertc = new List<T>();

                string strSort = _sortDirection == ListSortDirection.Ascending ? "ASC" : "DESC";
                string orderby = currentColname + " " + strSort;
                object source = new object();

                //if ( ! string.IsNullOrEmpty(filter[0].Value.ToString()))
                if (filter != null)
                {
                    Type propertyType = typeof(T).GetProperty(filter[0].PropertyName).PropertyType;
                    string s = filter[0].Value.ToString();
                    bool respe = false;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (propertyType.Equals(typeof(int)))
                        {
                            int res = 0;
                            respe = int.TryParse(s, out res);
                        }
                        else if (propertyType.Equals(typeof(decimal)))
                        {
                            decimal res = 0;
                            respe = decimal.TryParse(s, out res);
                        }
                        else if (propertyType.Equals(typeof(double)))
                        {
                            double res = 0;
                            respe = double.TryParse(s, out res);
                        }
                        else if (propertyType.Equals(typeof(DateTime)))
                            respe = true;
                        else
                            respe = true;

                    }
                    else
                    {
                        if (propertyType.Equals(typeof(DateTime)))
                        {
                            DateTime res = DateTime.MinValue;
                            if (string.IsNullOrWhiteSpace(s))
                            {
                                foreach (var item in filter)
                                    item.Value = DateTime.MinValue.ToShortDateString();
                                s = DateTime.MinValue.ToShortDateString();
                            }
                            respe = DateTime.TryParse(s, out res);
                        }
                        else
                            respe = true;
                    }
                        
                    if (respe == false)
                    {
                        convertc = new List<T>();
                    }
                    else
                    {
                        var delegc = ExpressionBuilder.GetExpression<T>(filter).Compile();
                        convertc = ((ObservableCollection<T>)SearchSource).Where(delegc).ToList();
                    }
                    if (convertc.Count() > 0)
                    {
                        DynamicComparer<T> comparer = new DynamicComparer<T>(orderby);
                        convertc.Sort(comparer.Compare);
                        source = convertc;
                    }
                    else
                    {
                        source = null;
                        //source = ((ObservableCollection<T>)SearchSource).ToList();
                    }

                    var collection = source as System.Collections.IEnumerable;

                    dgrid.ItemsSource = collection;

                    if (source != null)// && convertc.Count != ((ObservableCollection<T>)SearchSource).Count)
                        dgrid.SelectedItem = dgrid.Items[0];
                    else
                        dgrid.SelectedItem = null;

                    return collection;
                }

                return (ObservableCollection<T>)SearchSource;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Manejo de certificado y llave

        private static byte[] GetFileBytes(String filename)
        {
            try
            {
                if (!File.Exists(filename))
                    return null;
                Stream stream = new FileStream(filename, FileMode.Open);
                int datalen = (int)stream.Length;
                byte[] filebytes = new byte[datalen];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(filebytes, 0, datalen);
                stream.Close();
                return filebytes;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static bool CompareCertKey(string strXmlCert, string strXxmlKey)
        {
            try
            {
                bool resultado = false;

                if (strXmlCert.Equals(strXxmlKey))
                    resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #region Certificado

        public static X509Certificate2 GetCertInfo(string filename)
        {
            try
            {
                X509Certificate2 x509 = new X509Certificate2();
                byte[] rawData = GetFileBytes(filename);

                x509.Import(rawData);

                return x509;
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("No se encontró el archivo.");
            }
            catch (IOException)
            {
                throw new Exception("Error de acceso al archivo.");
            }
            catch (NullReferenceException)
            {
                throw new Exception("Debe de ser un archivo con extensión .cer!");
            }
            catch (Exception)
            {
                throw new Exception("No se encontró el archivo cer.");
            }
        }

        public static string ObtenerNumeroSerieCert(string serieCert)
        {
            try
            {
                string serieResult = string.Empty;
                for (int idx = 1; idx <= serieCert.Length; idx++)
                {
                    serieResult += idx % 2 == 0 ? serieCert.Substring(idx - 1, 1) : string.Empty;
                }

                return serieResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Llave privada

        public static RSACryptoServiceProvider DecodeDERKey(String filename, string password)
        {
            try
            {
                RSACryptoServiceProvider rsa = null;
                byte[] keyblob = GetFileBytes(filename);
                if (keyblob == null)
                    throw new Exception("No se encontró el archivo key.");

                rsa = DecodeEncryptedPrivateKeyInfo(keyblob, password);	//PKCS #8 encrypted
                if (rsa != null)
                {
                    return rsa;
                }


                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static RSACryptoServiceProvider DecodeEncryptedPrivateKeyInfo(byte[] encpkcs8, string password)
        {

            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            // this byte[] includes the sequence byte and terminal encoded null 
            byte[] OIDpkcs5PBES2 = { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x05, 0x0D };
            byte[] OIDpkcs5PBKDF2 = { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x05, 0x0C };
            byte[] OIDdesEDE3CBC = { 0x06, 0x08, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x03, 0x07 };
            byte[] seqdes = new byte[10];
            byte[] seq = new byte[11];
            byte[] salt;
            byte[] IV;
            byte[] encryptedpkcs8;
            byte[] pkcs8;

            int saltsize, ivsize, encblobsize;
            int iterations;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            MemoryStream mem = new MemoryStream(encpkcs8);
            int lenstream = (int)mem.Length;
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;

            try
            {

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)	//data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();	//advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();	//advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();	//inner sequence
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();


                seq = binr.ReadBytes(11);		//read the Sequence OID
                if (!CompareBytearrays(seq, OIDpkcs5PBES2))	//is it a OIDpkcs5PBES2 ?
                    return null;

                twobytes = binr.ReadUInt16();	//inner sequence for pswd salt
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();

                twobytes = binr.ReadUInt16();	//inner sequence for pswd salt
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();

                seq = binr.ReadBytes(11);		//read the Sequence OID
                if (!CompareBytearrays(seq, OIDpkcs5PBKDF2))	//is it a OIDpkcs5PBKDF2 ?
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();

                bt = binr.ReadByte();
                if (bt != 0x04)		//expect octet string for salt
                    return null;
                saltsize = binr.ReadByte();
                salt = binr.ReadBytes(saltsize);

                bt = binr.ReadByte();
                if (bt != 0x02) 	//expect an integer for PBKF2 interation count
                    return null;

                int itbytes = binr.ReadByte();	//PBKD2 iterations should fit in 2 bytes.
                if (itbytes == 1)
                    iterations = binr.ReadByte();
                else if (itbytes == 2)
                    iterations = 256 * binr.ReadByte() + binr.ReadByte();
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();


                seqdes = binr.ReadBytes(10);		//read the Sequence OID
                if (!CompareBytearrays(seqdes, OIDdesEDE3CBC))	//is it a OIDdes-EDE3-CBC ?
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x04)		//expect octet string for IV
                    return null;
                ivsize = binr.ReadByte();	// IV byte size should fit in one byte (24 expected for 3DES)
                IV = binr.ReadBytes(ivsize);

                bt = binr.ReadByte();
                if (bt != 0x04)		// expect octet string for encrypted PKCS8 data
                    return null;


                bt = binr.ReadByte();

                if (bt == 0x81)
                    encblobsize = binr.ReadByte();	// data size in next byte
                else if (bt == 0x82)
                    encblobsize = 256 * binr.ReadByte() + binr.ReadByte();
                else
                    encblobsize = bt;		// we already have the data size


                encryptedpkcs8 = binr.ReadBytes(encblobsize);
                //if(verbose)
                //	showBytes("Encrypted PKCS8 blob", encryptedpkcs8) ;


                SecureString secpswd = GetSecPswd(password);
                pkcs8 = DecryptPBDK2(encryptedpkcs8, salt, IV, secpswd, iterations);
                if (pkcs8 == null)	// probably a bad pswd entered.
                    return null;

                //if(verbose)
                //	showBytes("Decrypted PKCS #8", pkcs8) ;
                //----- With a decrypted pkcs #8 PrivateKeyInfo blob, decode it to an RSA ---
                RSACryptoServiceProvider rsa = DecodePrivateKeyInfo(pkcs8);
                return rsa;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally { binr.Close(); }

        }

        public static byte[] DecryptPBDK2(byte[] edata, byte[] salt, byte[] IV, SecureString secpswd, int iterations)
        {
            CryptoStream decrypt = null;

            IntPtr unmanagedPswd = IntPtr.Zero;
            byte[] psbytes = new byte[secpswd.Length];
            unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
            Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length);
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd);

            try
            {
                Rfc2898DeriveBytes kd = new Rfc2898DeriveBytes(psbytes, salt, iterations);
                TripleDES decAlg = TripleDES.Create();
                decAlg.Key = kd.GetBytes(24);
                decAlg.IV = IV;
                MemoryStream memstr = new MemoryStream();
                decrypt = new CryptoStream(memstr, decAlg.CreateDecryptor(), CryptoStreamMode.Write);
                decrypt.Write(edata, 0, edata.Length);
                decrypt.Flush();
                decrypt.Close();	// this is REQUIRED.
                byte[] cleartext = memstr.ToArray();
                return cleartext;
            }
            catch (Exception e)
            {
                throw new Exception("Password del archivo KEY incorrecto! -> " + e.Message);
            }
        }

        public static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            // this byte[] includes the sequence byte and terminal encoded null 
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];
            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            MemoryStream mem = new MemoryStream(pkcs8);
            int lenstream = (int)mem.Length;
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;

            try
            {

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)	//data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();	//advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();	//advance 2 bytes
                else
                    return null;


                bt = binr.ReadByte();
                if (bt != 0x02)
                    return null;

                twobytes = binr.ReadUInt16();

                if (twobytes != 0x0001)
                    return null;

                seq = binr.ReadBytes(15);		//read the Sequence OID
                if (!CompareBytearrays(seq, SeqOID))	//make sure Sequence for OID is correct
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x04)	//expect an Octet string 
                    return null;

                bt = binr.ReadByte();		//read next byte, or next 2 bytes is  0x81 or 0x82; otherwise bt is the byte count
                if (bt == 0x81)
                    binr.ReadByte();
                else
                    if (bt == 0x82)
                        binr.ReadUInt16();
                //------ at this stage, the remaining sequence should be the RSA private key

                byte[] rsaprivkey = binr.ReadBytes((int)(lenstream - mem.Position));
                RSACryptoServiceProvider rsacsp = DecodeRSAPrivateKey(rsaprivkey);
                return rsacsp;
            }

            catch (Exception)
            {
                return null;
            }

            finally { binr.Close(); }

        }

        public static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)	//data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();	//advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();	//advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)	//version number
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;


                //------  all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally { binr.Close(); }
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)		//expect integer
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();	// data size in next byte
            else
                if (bt == 0x82)
                {
                    highbyte = binr.ReadByte();	// data size in next 2 bytes
                    lowbyte = binr.ReadByte();
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    count = BitConverter.ToInt32(modint, 0);
                }
                else
                {
                    count = bt;		// we already have the data size
                }



            while (binr.ReadByte() == 0x00)
            {	//remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);		//last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }

        private static SecureString GetSecPswd(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return null;
            else
            {
                SecureString Result = new SecureString();
                foreach (char c in password.ToCharArray())
                    Result.AppendChar(c);
                return Result;
            }
        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

        #endregion

        #endregion

        #region Conversion de arreglo de Byte's a imagen
        // JAH 24/11/2014 Se agrega la funcion generica, para realizar la conversion de un arreglo de Byte's a una imagen
        // Recibe como parametro un arreglo de Byte's y regrea un objeto de tipo imagen.
        public static BitmapSource ArrayToImg(byte[] imgByte)
        {
            BitmapImage bi = new BitmapImage();
            try
            {
                using (MemoryStream ms = new MemoryStream(imgByte))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return bi;
        }
        #endregion

        #region Actualización de Etapas de la Referencia
        //public static bool ActualizaEtapas(string referencia, int subdiv, string tipo_op, int etapa, DateTime HoraEtapa, string usuario)
        //{
        //    bool ret = false;
        //    BRTrafico ct = new BRTrafico();
        //    BRCatalogo cat = new BRCatalogo();
        //    Ent_Etapas_Referencia er = new Ent_Etapas_Referencia();
        //    er.Num_Ref = referencia;
        //    er.Sub = subdiv;

        //    try
        //    {
        //        Respuesta<List<Ent_Etapas_Referencia>> res = ct.GetEtapasReferencia(er);
        //        if (res.EsExitoso && res.Resultado.Count > 0)
        //        {
        //            foreach (Ent_Etapas_Referencia e in res.Resultado)
        //            {
        //                if (e.Id_Etapa == etapa)
        //                {
        //                    e.HorEta = HoraEtapa;
        //                    e.FecEta = HoraEtapa;
        //                    e.UsuMod = usuario;
        //                    Respuesta<int> rsact = ct.InsUpdDelEtapasReferencia(e, Comunes.CAMBIA);
        //                    if (!rsact.EsExitoso)
        //                    {
        //                        ret = false;
        //                    }
        //                    else
        //                    {
        //                        ret = true;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            List<Ent_Etapas> lstEt = new List<Ent_Etapas>();
        //            List<Ent_Etapas_Referencia> lster = new List<Entity.Ent_Etapas_Referencia>();
        //            Ent_Etapas e = new Ent_Etapas();
        //            e.Ceimp_exp = tipo_op;
        //            Respuesta<List<Ent_Etapas>> r = cat.GetEtapas(e);
        //            if (r.EsExitoso && r.Resultado.Count > 0)
        //            {
        //                lstEt = r.Resultado;
        //                foreach (Ent_Etapas x in lstEt)
        //                {
        //                    Ent_Etapas_Referencia ner = new Ent_Etapas_Referencia();
        //                    ner.Num_Ref = referencia;
        //                    ner.Sub = subdiv;
        //                    ner.Id_Etapa = Convert.ToInt32(x.Id_ceetapa);
        //                    ner.Ord_Etapa = Convert.ToInt32(x.Id_ceetapa);
        //                    if (ner.Id_Etapa == etapa)
        //                    {
        //                        ner.HorEta = HoraEtapa;
        //                        ner.FecEta = HoraEtapa;
        //                    }
        //                    else
        //                    {
        //                        ner.HorEta = null;
        //                        ner.FecEta = null;
        //                    }
        //                    ner.FecAlt = DateTime.Now;
        //                    ner.FecMod = DateTime.Now;
        //                    ner.UsuAlt = usuario;
        //                    ner.UsuMod = usuario;
        //                    lster.Add(ner);
        //                }
        //                // Ahora guardamos las etapas de la referencia
        //                ret = true;
        //                foreach (Ent_Etapas_Referencia x in lster)
        //                {
        //                    Respuesta<int> rs = ct.InsUpdDelEtapasReferencia(x, Comunes.AGREGA);
        //                    if (!rs.EsExitoso)
        //                    {
        //                        ret = false;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ret = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return ret;
        //}
        #endregion

        #region consultas de dia8
        //public static DataTable GetQryGeneral(string sp, string opc, int tipo, string fil1, string tar = "", string oper = "", string hist = "", string p_strDefTReg = "", string p_strDefTLIVA = "", string p_strDefTit = "", string p_strDefRegla = "", string p_strDefArt1 = "", string p_fecDefArt1 = "", string p_strDefArt2 = "", string p_fecDefArt2 = "", int limitToMySql = 0, string orderHist = "")
        //{
        //    DALDIA di = new DALDIA();
        //    DataTable ds_Bus = new DataTable();
        //    try
        //    {
        //        ds_Bus = di.GetQryGeneral(sp, opc, tipo, fil1, tar, oper, hist, p_strDefTReg, p_strDefTLIVA, p_strDefTit, p_strDefRegla, p_strDefArt1, p_fecDefArt1, p_strDefArt2, p_fecDefArt2, limitToMySql, orderHist);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds_Bus;
        //}

        public static void VisControl(params Object[] poCampo)
        {
            // ESTADOS PARA VISIBILIDAD EN CONTROLES 0=HIDDEN, 1=VISIBLE, 2=COLLAPSED
            //bool en = (bool)poCampo[poCampo.Length - 1];
            bool en = false;
            int est = 0;
            if (Convert.ToInt32(poCampo[poCampo.Length - 1]) == 2)
            {
                est = Convert.ToInt32(poCampo[poCampo.Length - 1]);
            }
            else
            {
                en = (bool)poCampo[poCampo.Length - 1];
            }

            for (int i = 0; i < poCampo.Length - 1; i++)
            {
                if (est == 2)
                    ((UIElement)poCampo[i]).Visibility = Visibility.Collapsed;
                else if (en)
                    ((UIElement)poCampo[i]).Visibility = Visibility.Visible;
                else
                    ((UIElement)poCampo[i]).Visibility = Visibility.Hidden;

            }
        }

        public static void LimpiaCampos(params Object[] poCampo)
        {
            for (int i = 0; i < poCampo.Length; i++)
            {
                if (poCampo[i] == null)
                {
                    return;
                }
                else if (poCampo[i].GetType().Equals(typeof(TextBox)))
                    ((TextBox)poCampo[i]).Text = string.Empty;
                //else if (poCampo[i].GetType().Equals(typeof(DropDownList)))
                //    ((DropDownList)poCampo[i]).SelectedIndex = 0;
                else if (poCampo[i].GetType().Equals(typeof(Label)))
                    ((Label)poCampo[i]).Content = string.Empty;
                else if (poCampo[i].GetType().Equals(typeof(CheckBox)))
                {
                    bool state = (bool)poCampo[poCampo.Length - 1];
                    ((CheckBox)poCampo[i]).IsChecked = state;
                }
                else if (poCampo[i].GetType().Equals(typeof(ListBox)))
                {
                    ((ListBox)poCampo[i]).Items.Clear();
                }
            }
        }

        public static void camposNumericos(Object sender, KeyEventArgs e)
        {

            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && e.Key != Key.Decimal && e.Key != Key.OemPeriod
                && e.Key != Key.NumPad0 && e.Key != Key.NumPad1 && e.Key != Key.NumPad2 && e.Key != Key.NumPad3 && e.Key != Key.NumPad4
                && e.Key != Key.NumPad5 && e.Key != Key.NumPad6 && e.Key != Key.NumPad7 && e.Key != Key.NumPad8 && e.Key != Key.NumPad9
                && e.Key != Key.Delete && e.Key != Key.Back && e.Key != Key.Left && e.Key != Key.Right && e.Key != Key.Tab)
            {
                e.Handled = !(char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)));
            }

        }

        //public static EntCampos getCustomData(string opc, string modulo, string descr)
        //{
        //    List<EntCampos> res = new List<EntCampos>();
        //    EntCampos Entres = new EntCampos();
        //    try
        //    {
        //        DALDIA dl = new DALDIA();
        //        res = dl.getCustomData(opc, modulo, descr);
        //        Entres.C1 = res[0].C1;
        //        Entres.C2 = res[0].C2;
        //        Entres.C3 = res[0].C3;
        //        Entres.C4 = res[0].C4;
        //        Entres.C5 = res[0].C5;
        //        Entres.C6 = res[0].C6;
        //        Entres.C7 = res[0].C7;
        //        Entres.C8 = res[0].C8;
        //        Entres.C9 = res[0].C9;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Entres;
        //}
        #endregion

        #region Abrir archivos incrustados
        public string AbrirArchivoIncrustado(string NombreArchivo, bool ValidaExistePrimero = false)
        {
            Assembly _assembly;
            Stream _textStreamReader;
            string file = "";

            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _textStreamReader = _assembly.GetManifestResourceStream("SITA." + NombreArchivo);
                file = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, NombreArchivo);


                if (ValidaExistePrimero)
                {
                    if (System.IO.File.Exists(file))
                        return file;
                }
                else
                {
                    //Guardando el archivo que se obtiene incrsutado del sistema en una ruta temporal
                    SaveStreamToFile(file, _textStreamReader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
               "Acceso archivos sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return file;
        }

        public void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
        #endregion

        public static string Unidad(string unid)
        {
            string aUnid = string.Empty;

            try
            {
                switch (unid)
                {
                    case "1":
                        aUnid = "Kilogramo"; //Kg.
                        break;
                    case "2":
                        aUnid = "Cabeza"; //Cbza.
                        break;
                    case "3":
                        aUnid = "Litro"; //L.
                        break;
                    case "4":
                        aUnid = "Metro Cúbico"; //m.3
                        break;
                    case "5":
                        aUnid = "Kilowatt/Hora"; //KWH.
                        break;
                    case "6":
                        aUnid = "Pieza"; //pza.
                        break;
                    case "7":
                        aUnid = "Gramo"; //GR.
                        break;
                    case "8":
                        aUnid = "Par";
                        break;
                    case "9":
                        aUnid = "Metro Cuadrado"; //m.2
                        break;
                    case "10":
                        aUnid = "C.P.";
                        break;
                    case "11":
                        aUnid = "Kilowatt";
                        break;
                    case "12":
                        aUnid = "Centímetro"; //cm.
                        break;
                    case "13":
                        aUnid = "Milímetro"; //mm.
                        break;
                    case "14":
                        aUnid = "Kv/A"; //KVA.
                        break;
                    case "15":
                        aUnid = "Metro"; //m.
                        break;
                    case "16":
                        aUnid = "vol.";
                        break;
                    case "17":
                        aUnid = "Juego"; //jgo.
                        break;
                    case "18":
                        aUnid = "dtex.";
                        break;
                    case "19":
                        aUnid = "GHz";
                        break;
                    case "20":
                        aUnid = "CN/tex";
                        break;
                    case "21":
                        aUnid = "r.p.m.";
                        break;
                    case "22":
                        aUnid = "MPa";
                        break;
                    case "23":
                        aUnid = "MHz";
                        break;
                    case "24":
                        aUnid = "c.c.";
                        break;
                    case "25":
                        aUnid = "G.N.";
                        break;
                    case "26":
                        aUnid = "Millar";
                        break;
                    case "27":
                        aUnid = "PROHIBIDA";
                        break;
                    case "28":
                        aUnid = "";
                        break;
                    case "29":
                        aUnid = "Barril";
                        break;
                    case "30":
                        aUnid = "Tonelada";
                        break;
                    case "31":
                        aUnid = "Gramo neto";
                        break;
                    case "32":
                        aUnid = "Decenas";
                        break;
                    case "33":
                        aUnid = "Cientos";
                        break;
                    case "34":
                        aUnid = "Docenas";
                        break;
                    default:
                        aUnid = "ERROR";
                        break;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return aUnid;
        }

    }
}
