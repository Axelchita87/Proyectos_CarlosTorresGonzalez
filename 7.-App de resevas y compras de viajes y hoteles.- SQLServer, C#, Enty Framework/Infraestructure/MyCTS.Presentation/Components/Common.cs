using DevExpress.XtraEditors;
using MyCTS.Business;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public class Common
    {
        private static byte[] IV = new byte[9] { 67, 84, 83, 86, 101, 99, 116, 111, 114, };
        private static byte[] Key = new byte[24] { 66, 38, 115, 181, 206, 69, 152, 3, 23, 254, 61, 32, 120, 174, 47, 69, 179, 19, 64, 19, 186, 13, 37, 142 };
        public static string toDecrypt(string msj)
        {
            byte[] message = Convert.FromBase64String(msj);
            MemoryStream msDecrypt = new MemoryStream(message);
            TripleDES tripleDESalg = TripleDES.Create();
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                tripleDESalg.CreateDecryptor(Key, IV),
                CryptoStreamMode.Read);
            byte[] fromEncrypt = new byte[message.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            return UTF8Encoding.UTF8.GetString(fromEncrypt);
        }

        public static string toEncrypt(string cadenaOrigen)
        {
            MemoryStream memory = new MemoryStream();
            TripleDES criptoProvider = TripleDES.Create("TripleDES");
            //IV = criptoProvider.IV;
            //Key = criptoProvider.Key;
            TripleDES tripleDESalg = TripleDES.Create();
            CryptoStream cStream = new CryptoStream(memory, tripleDESalg.CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);
            byte[] toEncrypt = UTF8Encoding.UTF8.GetBytes(cadenaOrigen);
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
            byte[] ret = memory.ToArray();
            return Convert.ToBase64String(ret, 0, ret.Length);
        }

        #region Control Areas
        public enum Area
        {
            Area_A = 0,
            Area_B = 1,
            Area_C = 2,
            Area_D = 3,
            Area_E = 4,
            Area_F = 5
        }

        public static void RenewCurrentArea()
        {
            string area = CurrentArea.Substring(0, 1);
            CurrentArea = area + "_" + Guid.NewGuid().ToString();

        }

        /// <summary>
        /// Asigna el valor del PNR
        /// </summary>
        /// <param name="result">Valor que contendrá</param>
        public static void SetValueCurrentPNR(string result)
        {
            string area = CurrentArea.Substring(0, 1);
            string lastPNR = CurrentPNR;

            switch (area)
            {
                case "A":
                    PNR_A = result;
                    CurrentPNR = PNR_A;
                    if (string.IsNullOrEmpty(result))
                    {
                        Area_A = "A_" + Guid.NewGuid().ToString();
                        CurrentArea = Area_A;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lastPNR))
                            return;

                        if (!CurrentPNR.Equals(lastPNR))
                            RenewCurrentArea();
                    }
                    break;
                case "B":
                    PNR_B = result;
                    CurrentPNR = PNR_B;
                    if (string.IsNullOrEmpty(result))
                    {
                        Area_B = "B_" + Guid.NewGuid().ToString();
                        CurrentArea = Area_B;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lastPNR))
                            return;

                        if (!CurrentPNR.Equals(lastPNR))
                            RenewCurrentArea();
                    }
                    break;
                case "C":
                    PNR_C = result;
                    CurrentPNR = PNR_C;
                    if (string.IsNullOrEmpty(result))
                    {
                        Area_C = "C_" + Guid.NewGuid().ToString();
                        CurrentArea = Area_C;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lastPNR))
                            return;

                        if (!CurrentPNR.Equals(lastPNR))
                            RenewCurrentArea();
                    }
                    break;
                case "D":
                    PNR_D = result;
                    CurrentPNR = PNR_D;
                    if (string.IsNullOrEmpty(result))
                    {
                        Area_D = "D_" + Guid.NewGuid().ToString();
                        CurrentArea = Area_D;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lastPNR))
                            return;

                        if (!CurrentPNR.Equals(lastPNR))
                            RenewCurrentArea();
                    }
                    break;
                case "E":
                    PNR_E = result;
                    CurrentPNR = PNR_E;
                    if (string.IsNullOrEmpty(result))
                    {
                        Area_E = "E_" + Guid.NewGuid().ToString();
                        CurrentArea = Area_E;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lastPNR))
                            return;

                        if (!CurrentPNR.Equals(lastPNR))
                            RenewCurrentArea();
                    }
                    break;
                case "F":
                    PNR_F = result;
                    CurrentPNR = PNR_F;
                    if (string.IsNullOrEmpty(result))
                    {
                        Area_F = "F_" + Guid.NewGuid().ToString();
                        CurrentArea = Area_F;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lastPNR))
                            return;

                        if (!CurrentPNR.Equals(lastPNR))
                            RenewCurrentArea();
                    }
                    break;
            }
        }
        /// <summary>
        /// Asinga el área actual en la que se encuentra el usuario
        /// </summary>
        /// <param name="a">Area (A,B,C,D,E,F)</param>
        public static void SetCurrentArea(Area a)
        {
            switch (a)
            {
                case Area.Area_A:
                    CurrentArea = Area_A;
                    CurrentPNR = PNR_A;
                    break;
                case Area.Area_B:
                    CurrentArea = Area_B;
                    CurrentPNR = PNR_B;
                    break;
                case Area.Area_C:
                    CurrentArea = Area_C;
                    CurrentPNR = PNR_C;
                    break;
                case Area.Area_D:
                    CurrentArea = Area_D;
                    CurrentPNR = PNR_D;
                    break;
                case Area.Area_E:
                    CurrentArea = Area_E;
                    CurrentPNR = PNR_E;
                    break;
                case Area.Area_F:
                    CurrentArea = Area_F;
                    CurrentPNR = PNR_F;
                    break;
            }
        }

        private static string currentArea;
        public static string CurrentArea
        {
            get
            {
                if (string.IsNullOrEmpty(currentArea))
                    currentArea = "A";
                return currentArea;
            }
            set
            {
                currentArea = value;
            }
        }

        #region Propiedades PNR
        private static string currentPNR;
        public static string CurrentPNR
        {
            get
            {
                return currentPNR;
            }
            set
            {
                currentPNR = value;
            }
        }

        private static string pnr_a;
        public static string PNR_A
        {
            get
            {
                return pnr_a;
            }
            set
            {
                pnr_a = value;
            }
        }
        private static string pnr_b;
        public static string PNR_B
        {
            get
            {
                return pnr_b;
            }
            set
            {
                pnr_b = value;
            }
        }
        private static string pnr_c;
        public static string PNR_C
        {
            get
            {
                return pnr_c;
            }
            set
            {
                pnr_c = value;
            }
        }
        private static string pnr_d;
        public static string PNR_D
        {
            get
            {
                return pnr_d;
            }
            set
            {
                pnr_d = value;
            }
        }
        private static string pnr_e;
        public static string PNR_E
        {
            get
            {
                return pnr_e;
            }
            set
            {
                pnr_e = value;
            }
        }
        private static string pnr_f;
        public static string PNR_F
        {
            get
            {
                return pnr_f;
            }
            set
            {
                pnr_f = value;
            }
        }
        #endregion

        #region Propieades Areas
        private static string area_a;
        private static string Area_A
        {
            get
            {
                if (string.IsNullOrEmpty(area_a))
                    area_a = "A_" + Guid.NewGuid().ToString();
                return area_a;
            }
            set
            {
                area_a = value;
            }
        }
        private static string area_b;
        private static string Area_B
        {
            get
            {
                if (string.IsNullOrEmpty(area_b))
                    area_b = "B_" + Guid.NewGuid().ToString();
                return area_b;
            }
            set
            {
                area_b = value;
            }
        }
        private static string area_c;
        private static string Area_C
        {
            get
            {
                if (string.IsNullOrEmpty(area_c))
                    area_c = "C_" + Guid.NewGuid().ToString();
                return area_c;
            }
            set
            {
                area_c = value;
            }
        }
        private static string area_d;
        private static string Area_D
        {
            get
            {
                if (string.IsNullOrEmpty(area_d))
                    area_d = "D_" + Guid.NewGuid().ToString();
                return area_d;
            }
            set
            {
                area_d = value;
            }
        }
        private static string area_e;
        private static string Area_E
        {
            get
            {
                if (string.IsNullOrEmpty(area_e))
                    area_e = "E_" + Guid.NewGuid().ToString();
                return area_e;
            }
            set
            {
                area_e = value;
            }
        }

        private static string area_f;
        private static string Area_F
        {
            get
            {
                if (string.IsNullOrEmpty(area_f))
                    area_f = "F_" + Guid.NewGuid().ToString();
                return area_f;
            }
            set
            {
                area_f = value;
            }
        }
        #endregion

        #endregion

        public static void FindPNR(string result)
        {
            if (string.IsNullOrEmpty(result))
                return;

            result = result.Split(new char[] { '\n' })[0];
            //result = "BJKFTP";
            string pattern = @"^[a-zA-z]{6}$";
            Regex regExp = new Regex(pattern);
            result = result.Replace("\r", string.Empty);

            if (regExp.Match(result).Success)
            {
                SetValueCurrentPNR(result);
            }
        }

        #region Predictivos
        public static void SetListBoxAirports(TextBox sender, ListBox lbDest)
        {
            List<ListItem> airportCityCountryList = AirPortCityCountryBL.GetAirPortCityCountry_Predictive(sender.Text);
            SetListBox(sender, lbDest, airportCityCountryList);
        }

        public static void SetListBoxAirports(TextEdit sender, ListBox lbDest)
        {
            List<ListItem> airportCityCountryList = AirPortCityCountryBL.GetAirPortCityCountry_Predictive(sender.Text.ToUpper());
            SetListBox(sender, lbDest, airportCityCountryList);
        }

        public static void SetListBoxAirlines(TextBox sender, ListBox lbDest)
        {
            List<ListItem> airLinesList = CatAirlinesBL.GetAirLines_Predictive(sender.Text);
            SetListBox(sender, lbDest, airLinesList);
        }
        public static void SetListBoxAirlines(TextEdit sender, ListBox lbDest)
        {
            List<ListItem> airLinesList = CatAirlinesBL.GetAirLines_Predictive(sender.Text.ToUpper());
            SetListBox(sender, lbDest, airLinesList);
        }


        public static void SetListBoxCountries(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CatCountriesList = CatCountriesBL.GetCountries_Predictive(sender.Text);
            SetListBox(sender, lbDest, CatCountriesList);
        }


        public static void SetListBoxStateVolaris(TextBox sender, ListBox lbDest)
        {
            List<ListItem> listState = VolarisStateBL.GetAllStatePredictive(sender.Text);
            SetListBox(sender, lbDest, listState);
        }

        public static void SetListBoxBus(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CatBusCodesList = CatBusCodesBL.GetBusCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, CatBusCodesList);
        }

        public static void SetListBoxHotels(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CatHotelsList = CatHotelsBL.GetHotels_Predictive(sender.Text);
            SetListBox(sender, lbDest, CatHotelsList);
        }

        public static void SetListBoxCreditCards(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CatCreditCardsCodesList = CatCreditCardsCodesBL.GetCreditCardsCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, CatCreditCardsCodesList);
        }

        public static void SetListBoxSeaVendors(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CatSeaVendorsCodesList = CatSeaVendorsCodesBL.GetSeaVendorsCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, CatSeaVendorsCodesList);
        }

        public static void SetListBoxCurrenciesCountries(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CurrenciesCountriesList = CurrenciesCountriesBL.GetCurrenciesCountries_Predictive(sender.Text);
            SetListBox(sender, lbDest, CurrenciesCountriesList);
        }

        public static void SetListBoxStatusCodes(TextBox sender, ListBox lbDest)
        {
            List<ListItem> StatusCodesList = CatStatusCodesBL.GetStatusCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, StatusCodesList);
        }

        public static void SetListBoxStatesUSA(TextBox sender, ListBox lbDest)
        {
            List<ListItem> StatesUSAList = CatStatesUSABL.GetSatesUSA_Predictive(sender.Text);
            SetListBox(sender, lbDest, StatesUSAList);
        }


        public static void SetListBoxLineClasses(TextBox sender, ListBox lbDest)
        {
            List<ListItem> LineClassList = CatLineClassesBL.GetAirLinesClasses_Predictive(sender.Text);
            SetListBox(sender, lbDest, LineClassList);
        }


        public static void SetListBoxCities(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CitiesList = CatCitiesBL.GetCities_Predictive(sender.Text);
            SetListBox(sender, lbDest, CitiesList);
        }


        public static void SetListBoxCarTypeCodes(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CarTypeCodesList = CatCarTypeCodesBL.GetTypeCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, CarTypeCodesList);
        }

        public static void SetListBoxCarEquipmentCodes(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CarEquipmentCodesList = CatCarEquipemetCodesBL.GetEquipmentCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, CarEquipmentCodesList);
        }

        public static void SetListBoxCarVendorsCodes(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CarVendorCodesList = CatCarVendorsCodesBL.GetVendorCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, CarVendorCodesList);
        }

        public static void SetListBoxPax(TextBox sender, ListBox lbDest)
        {
            //List<ListItem> ChargeServiceList = ChargePerServiceBL.GetChargePerService_Predictive(sender.Text);
            //SetListBox(sender, lbDest, ChargeServiceList);
        }

        public static void SetDeleteListBoxPCCs(TextBox sender, ListBox lbDest)
        {
            List<ListItem> PCCsList = CatPccsBL.DeletePCCs_Predictive(sender.Text);
            SetListBox(sender, lbDest, PCCsList);
        }

        public static void SetListBoxPCCs(TextBox sender, ListBox lbDest)
        {
           List<ListItem> PCCsList = CatPccsBL.GetPCCs_Predictive(sender.Text);
            SetListBox(sender, lbDest, PCCsList);
        }

        public static void SetListBoxConfirmDK(TextBox sender, ListBox lbDest)
        {
            List<ListItem> DKList = CatConfirmDKBL.GetConfirmDK(sender.Text);
            SetListBox(sender, lbDest, DKList);
        }

        public static void SetListBoxPAirlines(TextBox sender, ListBox lbDest)
        {
            List<ListItem> PAirlinesList = CatPAirlinesFareBL.GetPAirlinesFare_Predictive(sender.Text);
            SetListBox(sender, lbDest, PAirlinesList);
        }

        public static void SetListCostCenter(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CostCenterList = CatCostCenterBL.GetCostCenters_Predictive(sender.Text);
            SetListBox(sender, lbDest, CostCenterList);
        }


        public static void SetListBoxMealCodes(TextBox sender, ListBox lbDest)
        {
            List<ListItem> MealCodesList = CatMealCodesBL.GetMealCodes_Predictive(sender.Text);
            SetListBox(sender, lbDest, MealCodesList);
        }

        public static void SetListworkerNumber_Nextel(TextBox sender, ListBox lbDest)
        {
            List<ListItem> WorkerNumberList = ClientsCatalogs_NextelBL.GetCatalog_ClientsCatalogs_Nextel_Predictive(sender.Text);
            SetListBox(sender, lbDest, WorkerNumberList);
        }

        public static void SetListCostCenter_Nextel(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CostCenterList = ClientsCatalogs_NextelCCBL.GetCatalog_ClientsCatalogs_NextelCC_Predictive(sender.Text);
            SetListBox(sender, lbDest, CostCenterList);
        }

        public static void SetListBoxFareType(TextBox sender, ListBox lbDest)
        {
            List<ListItem> FareTypeList = CatFareTypeCodesBL.GetFareType_Predictive(sender.Text);
            SetListBox(sender, lbDest, FareTypeList);
        }

        public static void SetListClientCatalogs(TextBox sender, ListBox lbDest, string CorporativeID, string labelRemark)
        {
            List<ListItem> ClientCatalogsList = CatClientsCatalogsBL.GetCatalog_ClientsCatalogs_Predictive(sender.Text, CorporativeID, labelRemark);
            SetListBox(sender, lbDest, ClientCatalogsList);
        }

        public static void SetListBoxIDGroup(TextBox sender, ListBox lbDest)
        {
            List<ListItem> idGroupList = GetIDGroupBL.GetIDGroups_Predictive(sender.Text);
            SetListBox(sender, lbDest, idGroupList);
        }

        public static void SetListBoxStarsFirstLevel(TextBox sender, ListBox lbDest, string StrToSearch)
        {
            List<ListItem> Stars1stLevelList = CatStars1stLevelBL.GetStars1stLevel_Predictive(StrToSearch, Login.OrgId);
            SetListBox(sender, lbDest, Stars1stLevelList);
        }

        public static void SetListBoxStarsFirstLevel(TextEdit sender, ListBox lbDest, string StrToSearch)
        {
            List<ListItem> Stars1stLevelList = CatStars1stLevelBL.GetStars1stLevel_Predictive(StrToSearch, Login.OrgId);
            SetListBox(sender, lbDest, Stars1stLevelList);
        }


        public static void SetListBoxStarsSecondLevel(TextBox sender, ListBox lbDest, string StrToSearch, string PCC, string Star1id)
        {
            List<ListItem> Stars2ndLevelList = CatStars2ndLevelBL.GetStars2ndLevel_Predictive(StrToSearch, PCC, Star1id);
            SetListBox(sender, lbDest, Stars2ndLevelList);
        }

        public static void SetListBoxStarsSecondLevel(TextEdit sender, ListBox lbDest, string StrToSearch, string PCC, string Star1id)
        {
            List<ListItem> Stars2ndLevelList = CatStars2ndLevelBL.GetStars2ndLevel_Predictive(StrToSearch, PCC, Star1id);
            SetListBox(sender, lbDest, Stars2ndLevelList);
        }


        public static void SetListBoxAgents(TextBox sender, ListBox lbDest)
        {
            List<ListItem> AgentList = AgentsBL.GetAgent_Predictive(sender.Text);
            SetListBox(sender, lbDest, AgentList);
        }

        public static void SetListBoxFormPaymentCTS(TextBox sender, ListBox lbDest)
        {
            List<ListItem> CatFormPaymentCTSList = CatCreditCardsCodesBL.GetFormPaymentCTS_Predictive(sender.Text);
            SetListBox(sender, lbDest, CatFormPaymentCTSList);
        }

        private static void SetListBox(TextBox sender, ListBox lbDest, List<ListItem> list)
        {
            int len = sender.Text.Length;
            lbDest.Items.Clear();

            if (!(len > 0))
            {
                lbDest.Visible = false;
                return;
            }

            lbDest.Location = new Point(sender.Location.X, sender.Location.Y + 19);
            int lbHeight = 0; //inicializa el alto que tendrá que control listbox para mostrar los resultados
            string searchText = sender.Text;
            lbDest.Height = 0;

            len = list.Count;

            if (!len.Equals(0))
            {
                lbHeight = len * 20;
                foreach (ListItem items in list)
                    lbDest.Items.Add(items);

                if (len > 8)
                    lbDest.Height = 200;
                else
                    lbDest.Height = lbHeight;

                lbDest.Visible = true;
            }

        }



        private static void SetListBox(TextEdit sender, ListBox lbDest, List<ListItem> list)
        {
            int len = sender.Text.Length;
            lbDest.Items.Clear();

            if (!(len > 0))
            {
                lbDest.Visible = false;
                return;
            }

            lbDest.Location = new Point(sender.Location.X, sender.Location.Y + 19);
            int lbHeight = 0; //inicializa el alto que tendrá que control listbox para mostrar los resultados
            string searchText = sender.Text;
            lbDest.Height = 0;

            len = list.Count;

            if (!len.Equals(0))
            {
                lbHeight = len * 20;
                foreach (ListItem items in list)
                    lbDest.Items.Add(items);

                if (len > 8)
                    lbDest.Height = 200;
                else
                    lbDest.Height = lbHeight;

                lbDest.Visible = true;
            }

        }
        #endregion

        private static LogsApplication logapplicationitem;
        public static LogsApplication LogApplicationItem
        {
            get
            {
                if (logapplicationitem == null)
                    logapplicationitem = new LogsApplication();

                return logapplicationitem;
            }
            set
            {
                logapplicationitem = value;



            }
        }

        public static void AddMessageToLog(Exception ex)
        {
            try
            {

                Common.LogApplicationItem.ErrorDescription = ex.ToString();
                Common.LogApplicationItem.StackTrace = ex.StackTrace;
                LogsApplicationBL.AddLogApplication(Common.LogApplicationItem);
            }
            catch { }
        }

        /// <summary>
        /// Obtiene las propiedades personalizadas del usuario
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GetProfileElement(string fieldName, string fields, string values)
        {
            char[] delimiter = "|*|".ToCharArray();
            string[] allFields = fields.Split(delimiter);
            string[] allValues = values.Split(delimiter);

            for (int i = 0; i < allFields.Length; i++)
            {
                if (allFields[i].Equals(fieldName))
                    return allValues[i];
            }

            return string.Empty;

        }

        private static List<BannerImage> bannerImageList;
        public static List<BannerImage> GetBannerImageList(int index)
        {
            if (bannerImageList == null)
            {
                bannerImageList = new List<BannerImage>();
                bannerImageList = GetBannerImageBL.GetBannerImageList(index.ToString());
            }

            return bannerImageList;
        }

        private static string welcomeMessage;
        public static string WelcomeMessage
        {
            get { return welcomeMessage; }
            set { welcomeMessage = value; }
        }

        #region QueueFiles
        /// <summary>
        /// Verifica archivos que están en queue para insertar
        /// instrucciones contenidas
        /// </summary>
        public static void ReadQueueFiles()
        {
            //DirectoryInfo dir = new DirectoryInfo(GlobalConstants.QUEUE_FILES);
            //if (dir.Exists)
            //{
            //    FileInfo[] fInfo = dir.GetFiles();

            //    foreach (FileInfo f in fInfo)
            //    {
            //        string sql = GetContentFile(f.FullName);
            //        CatTransactionBL.AddCommandsTransaction(sql);
            //        f.Delete();
            //    }
            //}

            DirectoryInfo dir = new DirectoryInfo(GlobalConstants.QUEUE_FILES);
            if (dir.Exists)
            {
                FileInfo[] fInfo = dir.GetFiles("mycts*.txt");
                var filesQuery = from f in fInfo
                                 orderby f.CreationTime
                                 select f;

                Byte[] mybytearray = null;

                foreach (FileInfo f in filesQuery)
                {
                    using (FileStream objfilestream = new FileStream(f.FullName, FileMode.Open, FileAccess.Read))
                    {
                        int len = (int)objfilestream.Length;
                        mybytearray = new Byte[len];
                        objfilestream.Read(mybytearray, 0, len);
                    }

                    bool result = MyCTS.Services.Contracts.Productivity.AddCommandsTransaction(mybytearray);
                    if (result)
                    {
                        f.Delete();
                    }
                }
            }
        }

        private static int _bufferSize = 16384;
        /// <summary>
        /// Lee el contenido de un archivo
        /// </summary>
        /// <param name="filename">Nobre archivo</param>
        /// <returns>Contenido archivo</returns>
        public static string GetContentFile(string filename)
        {
            if (!File.Exists(filename))
                return string.Empty;

            StringBuilder stringBuilder = new StringBuilder();
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);

                if (charsRead == 0)
                    return string.Empty;

                while (charsRead > 0)
                {
                    stringBuilder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }
            }

            return stringBuilder.ToString();

        }


        private static bool isManualCommandTransactions = false;
        public static bool IsManualCommandTransactions
        {
            get { return isManualCommandTransactions; }
            set { isManualCommandTransactions = value; }
        }

        private static List<string> currentCommandsSQL;

        public static List<string> CurrentCommandsSQL
        {
            get
            {
                if (currentCommandsSQL == null)
                    currentCommandsSQL = new List<string>();
                return currentCommandsSQL;
            }
            set
            {
                currentCommandsSQL = value;
            }
        }

        private static string sqlCommands = string.Empty;
        /// <summary>
        /// Bandera para indicar que el método BeginManualCommandsTransactions ha sido llamado
        /// </summary>
        private static bool IsActivatedManualCommandTransaction = false;

        public static void BeginManualCommandsTransactions()
        {
            return;

            //if (IsActivatedManualCommandTransaction)
            //    return;

            //IsManualCommandTransactions = true;
            //IsActivatedManualCommandTransaction = true;
        }

        public static DateTime RealDateTime
        {
            get
            {
                TimeSpan diff = DateTime.Now - Parameters.LocalDateTime;
                return Parameters.ServerDateTime.Add(diff);
            }
        }

        /// <summary>
        /// Ends the manual commands transactions.
        /// </summary>
        /// <param name="InsertExtraCommand">if set to <c>true</c> [insert extra command].</param>
        public static void EndManualCommandsTransactions(bool InsertExtraCommand)
        {
            string sql = string.Format("INSERT INTO [CommandsTransaction]([Agent],[Command], [RecLoc], [DateCreated],[AreaGUID] ) VALUES ('{0}' ,'{1}','{2}','{3}','{4}')",
              Login.Agent, "XXXXXX", Common.CurrentPNR, DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss"), Common.CurrentArea);

            CurrentCommandsSQL.Add(sql);

            EndManualCommandsTransactions();
        }

        public static void EndManualCommandsTransactions()
        {
            return;

            StringBuilder sbSQL = new StringBuilder();
            List<string> listSQL = CurrentCommandsSQL;
            string currentFileName = GlobalConstants.CurrentFileName;

            foreach (string sql in listSQL)
                sbSQL.Append(sql);

            /*****************/
            CurrentCommandsSQL.Clear();
            GlobalConstants.CurrentFileName = string.Empty;
            IsManualCommandTransactions = false;
            /*****************/

            DirectoryInfo dir = new DirectoryInfo(GlobalConstants.QUEUE_FILES);
            if (dir.Exists)
            {
                FileInfo[] fInfo = dir.GetFiles();

                foreach (FileInfo f in fInfo)
                {
                    sbSQL.Append(GetContentFile(f.FullName));
                    f.Delete();
                }
            }

            string fName = GlobalConstants.TEMP_FILES + "\\" + currentFileName;
            if (File.Exists(fName))
            {
                sbSQL.Append(GetContentFile(fName));
                File.Delete(fName);
            }

            //foreach (string sql in listSQL)
            //    sbSQL.Append(sql);

            //CurrentCommandsSQL.Clear();
            //GlobalConstants.CurrentFileName = string.Empty;
            //IsManualCommandTransactions = false;
            CatTransactionBL.AddCommandsTransaction(sbSQL.ToString());

            IsActivatedManualCommandTransaction = false;
        }


        public static bool HandleEvent(ref Message msg, Keys keyData)
        {

            if (ucEndReservation.isFlowHotel)
            {
                if (keyData == (Keys.Control | Keys.D1))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad1))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D0))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad0))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D2))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad2))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D3))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad3))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D4))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad4))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.D5))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad5))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.D6))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad6))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.D7))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad7))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.D8))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad8))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D9))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad9))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.A))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.B))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.C))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.E))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.F))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.G))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.H))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.I))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.J))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.K))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.L))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.N))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.O))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.P))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.Q))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.R))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.S))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.T))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.U))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.V))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.W))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Y))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Z))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Enter))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.Back))
                {
                    return true;
                }

                if (keyData == (Keys.Escape))
                {
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.M))
                {
                    return true;
                }



                if (keyData == Keys.Control)
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.E))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.LShiftKey | Keys.LButton))
                {
                    return true;
                }


            }


            return false;
        }


        #endregion
    }
}
