using ADMIN2.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADMIN2.DAL.DALGen
{
    public class ConnectionStringManager
    {
        public static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[connectionStringName];
            return connStringSettings.ConnectionString;
        }

        public static void SaveConnectionString(string connectionStringName, string connectionString)
        {
            System.Configuration.Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appconfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = connectionString;
            appconfig.Save();
        }

        //public static string GuardaConexionVUCEMConfig()
        //{
        //    string CadCnx = ConfigurationManager.ConnectionStrings["conxSitaCOVEPrba"].ConnectionString;

        //    DALConfiguraciones br = new DALConfiguraciones();
        //    Ent_st_c_conexiones cnVucem = new Ent_st_c_conexiones();

        //    cnVucem.St_c_cn_id = "";
        //    List<Ent_st_c_conexiones> lstRes = br.GetConexiones(cnVucem);
        //    if (lstRes.Count() > 0)
        //    {
        //        cnVucem = lstRes.Where(x => x.St_c_cn_id == "VUC").FirstOrDefault();

        //        if (cnVucem != null)
        //        {
        //            string[] serv_bd = cnVucem.St_c_cn_servidor.Split('|');
        //            string Serv = string.Empty, Bd = string.Empty, usu = string.Empty, pwd = string.Empty;

        //            if (serv_bd.Count() > 0)
        //            {
        //                Serv = serv_bd[0];
        //                Bd = serv_bd[1];
        //            }
        //            usu = cnVucem.St_c_cn_serial;
        //            pwd = cnVucem.St_c_cn_pwd;

        //            CadCnx = String.Format(CadCnx, Serv, Bd, usu, pwd);
        //        }
        //    }

        //    ConnectionStringManager.SaveConnectionString("conxSitaCOVE", CadCnx);

        //    return CadCnx;
        //}

        //public static string GuardaConexionDiaConfig(string CadCnx)
        //{
            //string CadCnx = ConfigurationManager.ConnectionStrings["conxDiaPrba"].ConnectionString;

        //    DALConfiguraciones br = new DALConfiguraciones();
        //    Ent_st_c_conexiones cnDia = new Ent_st_c_conexiones();

        //    cnDia.St_c_cn_id = "";
        //    List<Ent_st_c_conexiones> lstRes = br.GetConexiones(cnDia);
        //    if (lstRes.Count() > 0)
        //    {
        //        cnDia = lstRes.Where(x => x.St_c_cn_id == "DIA").FirstOrDefault();

        //        if (cnDia != null)
        //        {
        //            string Serv = cnDia.St_c_cn_servidor;

        //            CadCnx = CadCnx.Replace("[0]", Serv);
        //        }
        //    }

        //    //ConnectionStringManager.SaveConnectionString("conxDia", CadCnx);

        //    return CadCnx;
        //}


        private string decriptD(string Codigo, string Texto)
        {
            string kPos = "VRAELQXGDCWSNPZTHMUJKYFBOI";
            int intOffset, intMod, intLetra, intMueve;
            string strTmp, strTexto, strLetra, res;
            strTmp = strTexto = strLetra = res = string.Empty;
            try
            {
                #region proceso de desencriptación
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
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public string EncriptD(string Codigo, string Texto)
        {
            string kPos = "VRAELQXGDCWSNPZTHMUJKYFBOI";
            int intOffset, intMod, intLetra, intMueve;
            string strTmp, strTexto, strLetra;
            strTmp = strTexto = strLetra = string.Empty;
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
                    strTexto = strTmp.Substring(intOffset - 1, Texto.Length);
                    strTmp = string.Empty;
                    for (intLetra = 0; intLetra < strTexto.Length; intLetra++)
                    {
                        strLetra = strTexto.Substring(intLetra, 1);
                        if ((int)Convert.ToChar(strLetra) >= 65 && (int)Convert.ToChar(strLetra) <= 90)
                        {
                            intMueve = (int)Convert.ToChar(strLetra) - 64 + intMod + ((intLetra + 1) % 10);
                            strLetra = (kPos + kPos).Substring(intMueve - 1, 1);
                        }
                        else if ((int)Convert.ToChar(strLetra) >= 97 && (int)Convert.ToChar(strLetra) <= 122)
                        {
                            intMueve = (int)Convert.ToChar(strLetra) - 96 + intMod + ((intLetra + 1) % 10);
                            strLetra = (kPos + kPos).ToLower().Substring(intMueve - 1, 1);
                        }
                        else if (strLetra == Convert.ToChar(32).ToString())
                            strLetra = Convert.ToChar(96).ToString();
                        strTmp += strLetra;
                    }
                    strTexto = string.Empty;
                    for (intLetra = strTmp.Length - 1; intLetra >= 0; intLetra--)
                        strTexto += strTmp.Substring(intLetra, 1);
                    strTmp = strTexto;
                }
                else
                    strTmp = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strTmp;
        }
    }
}
