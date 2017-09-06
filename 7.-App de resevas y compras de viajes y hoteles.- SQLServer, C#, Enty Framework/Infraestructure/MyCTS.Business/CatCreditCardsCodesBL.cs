using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;
namespace MyCTS.Business
{
    public class CatCreditCardsCodesBL
    {
        public static List<CatCreditCardsCodes> GetCreditCardsCodes(string StrToSearch)
        {
            List<CatCreditCardsCodes> CatCreditCardsCodesList = new List<CatCreditCardsCodes>();
            CatCreditCardsCodesDAL objCreditCardsCodes = new CatCreditCardsCodesDAL();
            try
            {
                try
                {
                    CatCreditCardsCodesList = objCreditCardsCodes.GetCreditCardsCodes(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatCreditCardsCodesList = objCreditCardsCodes.GetCreditCardsCodes(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch { }
            return CatCreditCardsCodesList;
        }

        public static List<ListItem> GetFOPCTSList()
        {
            List<ListItem> CatFOPCTSListList = new List<ListItem>();
            CatCreditCardsCodesDAL objCreditCardsCodes = new CatCreditCardsCodesDAL();
            try
            {
                try
                {
                    CatFOPCTSListList = objCreditCardsCodes.GetFOPCTS(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatFOPCTSListList = objCreditCardsCodes.GetFOPCTS(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch { }
            return CatFOPCTSListList;
        }

        public static List<ListItem> GetFOPCTSListSinFoPTP()
        {
            List<ListItem> CatFOPCTSListList = new List<ListItem>();
            CatCreditCardsCodesDAL objCreditCardsCodes = new CatCreditCardsCodesDAL();
            try
            {
                try
                {
                    CatFOPCTSListList = objCreditCardsCodes.GetFOPCTSSinFoPTP(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatFOPCTSListList = objCreditCardsCodes.GetFOPCTSSinFoPTP(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch { }
            return CatFOPCTSListList;
        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CREDITCARDSCODES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {

                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatCreCarCodCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatCreCarCodCode + ' ' + CatCreCarCodName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatCreCarCodName                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetCreditCardsCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListCreditCardsCodesMin);

                return ObjectsBL.ListCreditCardsCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListCreditCardsCodesMaj);

                return ObjectsBL.ListCreditCardsCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }

        }

        public static List<ListItem> GetFormPaymentCTS_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 5)
            {
                GetElementsFOPCTS(ref ObjectsBL.ListFormPaymentCTS);

                return ObjectsBL.ListFormPaymentCTS.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElementsFOPCTS(ref ObjectsBL.ListFormPaymentCTS);

                return ObjectsBL.ListFormPaymentCTS.FindAll(delegate(ListItem li)
                { return (li.Text.StartsWith(StrToSearch)); });
            }
        }

        private static void GetElementsFOPCTS(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = GetFOPCTSList();
            }

        }
    }
}
