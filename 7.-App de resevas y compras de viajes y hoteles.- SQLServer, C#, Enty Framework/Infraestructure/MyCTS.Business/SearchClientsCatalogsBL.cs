using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SearchClientsCatalogsBL
    {
        public static List<SearchClientsCatalogs> GetSearchClientsCatalogs(string Client, string AttributeToSearch, string ValueToSearch)
        {
            List<SearchClientsCatalogs> SearchClientsCatalogsList = new List<SearchClientsCatalogs>();
            SearchClientsCatalogsDAL objSearchClientsCatalogsList = new SearchClientsCatalogsDAL();
            try
            {
                try
                {
                    SearchClientsCatalogsList = objSearchClientsCatalogsList.GetSearchClientsCatalogs(CommonENT.MYCTSDB_CONNECTION, Client,AttributeToSearch,ValueToSearch);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    SearchClientsCatalogsList = objSearchClientsCatalogsList.GetSearchClientsCatalogs(CommonENT.MYCTSDBBACKUP_CONNECTION, Client, AttributeToSearch, ValueToSearch);
                }
            }
            catch
            { }
            return SearchClientsCatalogsList;

        }
    }
}
