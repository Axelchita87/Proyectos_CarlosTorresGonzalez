using System;
using System.Security.Cryptography;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEvents
{
    public class Util
    {
        public static DateTime fechaNula = Convert.ToDateTime("01/01/0001");
        private static string kPos = "VRAELQXGDCWSNPZTHMUJKYFBOI";
        public static Byte[] v = { 0x15, 0x32, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x92, 0xAB, 0xCD, 0xEF };
        public static string k = "b3vdz33M+9AMYV7dAzfEW66JbWYBoF3xlV/0bR958nk=";
        public static string encript(string cad)
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

        public static string encriptD(string Codigo, string Texto) { 
            
            int intOffset, intMod, intLetra, intMueve;
            string strTmp, strTexto, strLetra;
            strTmp=strTexto=strLetra=string.Empty;
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
                    while (strTmp.Length < Texto.Length + intOffset)
                        strTmp += Texto;
                    strTexto = strTmp.Substring(intOffset-1, Texto.Length);
                    strTmp = string.Empty;
                    for (intLetra = 0; intLetra < strTexto.Length; intLetra++)
                    {
                        strLetra = strTexto.Substring(intLetra, 1);
                        if ((int)Convert.ToChar(strLetra) >= 65 && (int)Convert.ToChar(strLetra) <= 90)
                        {
                            intMueve = (int)Convert.ToChar(strLetra) - 64 + intMod + ((intLetra + 1) % 10);
                            strLetra = (kPos + kPos).Substring(intMueve-1, 1);
                        }
                        else if ((int)Convert.ToChar(strLetra) >= 97 && (int)Convert.ToChar(strLetra) <= 122)
                        {
                            intMueve = (int)Convert.ToChar(strLetra) - 96 + intMod + ((intLetra + 1) % 10);
                            strLetra = (kPos + kPos).ToLower().Substring(intMueve-1, 1);
                        }
                        else if (strLetra == Convert.ToChar(32).ToString())
                            strLetra = Convert.ToChar(96).ToString();
                        strTmp += strLetra;
                    }
                    strTexto = string.Empty;
                    for (intLetra = strTmp.Length-1; intLetra >= 0; intLetra--)
                        strTexto += strTmp.Substring(intLetra, 1);
                    strTmp = strTexto;
                }
                else
                    strTmp = string.Empty;
            }
            catch (Exception ex) {
                throw ex;
            }
            return strTmp;
        }
        public static string decriptD(string Codigo, string Texto)
        {
            
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
        public static DataTable decriptTable(DataTable t, EntEncript e) {
            string codigo = string.Empty;
            int i=0;
            try
            {

                foreach (DataRow r in t.Rows) {
                    i=0;
                    foreach (int c in e.Campos) {
                        if (i == 0)
                            codigo = r[c].ToString();
                        else
                            r[c] = decriptD(codigo, r[c].ToString());
                        i++;
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return t;
        }
        public static DataTable encriptTable(DataTable t, EntEncript e)
        {
            string codigo = string.Empty;
            int i = 0;
            int j = 0;
            try
            {

                foreach (DataRow r in t.Rows)
                {
                    i = 0;
                    j++;
                    if (j == 296)
                        j = 296;
                    foreach (int c in e.Campos)
                    {
                        if (i == 0)
                            codigo = r[c].ToString();
                        else
                        {
                            if (r[c].ToString()!=string.Empty)
                                r[c] = encriptD(codigo, r[c].ToString());
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public static DataTable revisaCamposHist(DataTable t, string nomt) {
            Var v = new Var();
            try
            {
                var bh = v.TabHist.Where(x => x.TablaHist == nomt);
                if (bh.ToList().Count == 1) {
                    List<string> campos = bh.ToList().First().CamposAd;
                    foreach (string c in campos)
                    {
                        if (c.ToUpper().Contains("FEC"))
                            t.Columns.Add(c,typeof(DateTime));
                        else
                            t.Columns.Add(c, typeof(String));
                        
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return t;
        }
        public static string LimpiaCadena(object val) 
        {
            string res=string.Empty;
            try
            {
                string sin = (string)val;
                if (sin.Contains("difenil)-4-iloxi)-alfa-(1,1-dimetiletil)-1H-1,2,4-triazol-1-etanol (BITERTANOL)"))
                {
                    string papas = string.Empty;
                }
                if (!sin.Contains(@"\'") && sin.Contains("'"))
                    sin.Replace("'", @"\'");
            }
            catch (Exception ex) {
                throw ex;
            }
            return res;
        }

        public static DataTable LimpiaApost(DataTable t)
        {
            string codigo = string.Empty;

            try
            {

                foreach (DataRow r in t.Rows)
                {

                    if (r[0].ToString().Contains("'"))
                    {
                        r[0] = r[0].ToString().Replace("'", "");
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
    }
}
