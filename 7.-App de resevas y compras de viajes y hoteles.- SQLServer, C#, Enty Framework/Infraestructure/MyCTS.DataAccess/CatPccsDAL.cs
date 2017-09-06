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
    public class CatPccsDAL
    {
        public List<ListItem> GetPccs(string StrToSearch, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatPccsResources.SP_GetPccs);
            db.AddInParameter(dbCommand, Resources.CatPccsResources.PARAM_QUERY1, DbType.String, StrToSearch);
            db.AddInParameter(dbCommand, Resources.CatPccsResources.PARAM_ORG_ID, DbType.Int32, OrgId);
            List<ListItem> listCatPccs = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catpccsid = dr.GetOrdinal(Resources.CatPccsResources.PARAM_CATPCCID);
                int _catpccsname = dr.GetOrdinal(Resources.CatPccsResources.PARAM_CATPCCNAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catpccsid);
                    item.Text = string.Concat(dr.GetString(_catpccsid), ' ', ((dr[_catpccsname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catpccsname)));
                    listCatPccs.Add(item);
                }
            }
            return listCatPccs;
        }
    }
}
