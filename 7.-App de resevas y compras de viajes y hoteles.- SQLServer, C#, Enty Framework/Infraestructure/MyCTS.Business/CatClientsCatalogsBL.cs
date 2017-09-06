using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatClientsCatalogsBL
    {
        public static List<ListItem> ListClientsCatalogs = null;
        public static List<ListItem> ListTemp = new List<ListItem>();

        public static List<ListItem> GetCatalog_ClientsCatalogs(string Attribute1, string RemarkLabelID)
        {
            List<ListItem> ClientsCatalogs_List = new List<ListItem>();
            CatClientsCatalogsDAL objClientsCatalogs = new CatClientsCatalogsDAL();
            try
            {
                try
                {
                    ClientsCatalogs_List = objClientsCatalogs.GetCatalog_ClientsCatalogs(CommonENT.MYCTSDB_CONNECTION, Attribute1, RemarkLabelID);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ClientsCatalogs_List = objClientsCatalogs.GetCatalog_ClientsCatalogs(CommonENT.MYCTSDBBACKUP_CONNECTION, Attribute1, RemarkLabelID);
                }
            }
            catch
            { }
            return ClientsCatalogs_List;

        }

        /// <summary>
        /// Codigo para predictivo
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetCatalog_ClientsCatalogs_Predictive(string StrToSearch, string Attribute1, string Label)
        {
            if (StrToSearch.Length < 4)
            {
                GetElements(ref ListClientsCatalogs, Attribute1, Label);

                //Busca por value
                return ListTemp.FindAll(delegate(ListItem li)
                { return (li.Value.StartsWith(StrToSearch)); });
            }
            else
            {
                GetElements(ref ListClientsCatalogs, Attribute1, Label);

                //Busca por Text2
                return ListTemp.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }

        }

        public static void GetElements(ref List<ListItem> list, string Attribute1, string LabelRemark)
        {
            if (list != null)
            {
                ListTemp.Clear();
                foreach (ListItem item in ListClientsCatalogs)
                {
                    if (item.Text3.Equals(LabelRemark))
                    {
                        ListTemp.Add(item);
                    }

                }
            }
        }

    }
}
