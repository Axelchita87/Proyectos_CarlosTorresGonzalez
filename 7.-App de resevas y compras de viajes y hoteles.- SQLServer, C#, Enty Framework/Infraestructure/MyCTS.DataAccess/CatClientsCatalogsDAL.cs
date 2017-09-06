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
    public class CatClientsCatalogsDAL
    {
        public List<ListItem> GetCatalog_ClientsCatalogs(string connectionName, string Attribute1, string RemarkLabelID)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatClientsCatalogsResources.SP_GetCatalog_ClientsCatalogs);
            db.AddInParameter(dbCommand, Resources.CatClientsCatalogsResources.PARAM_QUERY, DbType.String, Attribute1);
            db.AddInParameter(dbCommand, Resources.CatClientsCatalogsResources.PARAM_QUERY2, DbType.String, RemarkLabelID);

            List<ListItem> ClientsCatalogs_List = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _value = dr.GetOrdinal(Resources.CatClientsCatalogsResources.PARAM_VALUE);
                int _text = dr.GetOrdinal(Resources.CatClientsCatalogsResources.PARAM_TEXT);
                int _text2 = dr.GetOrdinal(Resources.CatClientsCatalogsResources.PARAM_TEXT2);
                int _text3 = dr.GetOrdinal(Resources.CatClientsCatalogsResources.PARAM_TEXT3);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_value] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_value);
                    item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                    item.Text2 = (dr[_text2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text2);
                    item.Text3 = (dr[_text3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text3);

                    ClientsCatalogs_List.Add(item);
                }
            }


            return ClientsCatalogs_List;
        }
    }
}
