
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
    public class CatStatusCodesDAL
    {
        public List<ListItem> GetStatusCodes(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatStatusCodesResource.SP_GetStatusCodes);
            db.AddInParameter(dbCommand, Resources.CatStatusCodesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatStatusCodesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catstacodcode = dr.GetOrdinal(Resources.CatStatusCodesResource.PARAM_CATSTACODCODE);
                int _catstacoddescription = dr.GetOrdinal(Resources.CatStatusCodesResource.PARAM_CATSTACODDESCRIPTION);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_catstacodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catstacodcode);
                    item.Text =string.Concat(((dr[_catstacodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catstacodcode)),' ',
                    ((dr[_catstacoddescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catstacoddescription)));
                    CatStatusCodesList.Add(item);
                }
            }

            return CatStatusCodesList;

        }
    }
}
