using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ClientsCatalogs_NextelCCBL
    {
        public static List<ListItem> ListCostCenter = null;
        public static List<ListItem> GetCatalog_ClientsCatalogs_NextelCC()
        {
            List<ListItem> ClientsCatalogs_NextelListCC = new List<ListItem>();
            ClientsCatalogs_NextelCCDAL objClientsCatalogs_NextelCC = new ClientsCatalogs_NextelCCDAL();
            try
            {
                try
                {
                    ClientsCatalogs_NextelListCC = objClientsCatalogs_NextelCC.GetCatalog_ClientsCatalogs_NextelCC(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ClientsCatalogs_NextelListCC = objClientsCatalogs_NextelCC.GetCatalog_ClientsCatalogs_NextelCC(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ClientsCatalogs_NextelListCC;

        }

        /// <summary>
        /// Codigo para predictivo
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetCatalog_ClientsCatalogs_NextelCC_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 4)
            {
                GetElements(ref ListCostCenter);

                //Busca por CatAirLinAlfaId
                return ListCostCenter.FindAll(delegate(ListItem li)
                { return (li.Value.StartsWith(StrToSearch)); });
            }
            else
            {
                GetElements(ref ListCostCenter);

                //Busca por CatAirLinName
                return ListCostCenter.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }

        }

        public static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                ListCostCenter = GetCatalog_ClientsCatalogs_NextelCC();
            }
        }

    }
}
