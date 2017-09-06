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
    public class CatConfirmDKDAL
    {
        public List<ListItem> GetConfirmDK(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatConfirmDKResources.SP_GetConfirmDK);
            db.AddInParameter(dbCommand, Resources.CatConfirmDKResources.PARAM_QUERY, DbType.String, StrToSearch);


            List<ListItem> CatConfirmDKList = new List<ListItem>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _iddk = dr.GetOrdinal(Resources.CatConfirmDKResources.PARAM_IDDK);
                int _dkname = dr.GetOrdinal(Resources.CatConfirmDKResources.PARAM_DKNAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_iddk);
                    item.Text = string.Concat( dr.GetString(_iddk),' ',(dr[_dkname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_dkname));

                    CatConfirmDKList.Add(item);
                }
            }
            return CatConfirmDKList;
        }
    }
}
