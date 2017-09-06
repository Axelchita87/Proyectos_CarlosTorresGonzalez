using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class SearchClientsCatalogsDAL
    {
        public List<SearchClientsCatalogs> GetSearchClientsCatalogs(string connectionName, string Client, string AttributeToSearch, string ValueToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SearchClientsCatalogsResources.SP_GetSearchClientsCatalogs);
            db.AddInParameter(dbCommand, Resources.SearchClientsCatalogsResources.PARAM_QUERY, DbType.String, Client);
            db.AddInParameter(dbCommand, Resources.SearchClientsCatalogsResources.PARAM_QUERY2, DbType.String, AttributeToSearch);
            db.AddInParameter(dbCommand, Resources.SearchClientsCatalogsResources.PARAM_QUERY3, DbType.String, ValueToSearch);

            List<SearchClientsCatalogs> SearchClientsCatalogsList = new List<SearchClientsCatalogs>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _result = dr.GetOrdinal(Resources.SearchClientsCatalogsResources.PARAM_RESULT);

                while (dr.Read())
                {
                    SearchClientsCatalogs item = new SearchClientsCatalogs();
                    item.Result = dr.GetString(_result);
                    SearchClientsCatalogsList.Add(item);
                }
            }

            return SearchClientsCatalogsList;

        }
    }
}
