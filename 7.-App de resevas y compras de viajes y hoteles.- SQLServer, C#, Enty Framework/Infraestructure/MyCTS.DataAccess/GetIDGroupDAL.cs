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
    public class GetIDGroupDAL
    {
        public List<ListItem> GetIDGroup(string strToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetIDGroup");
            db.AddInParameter(dbCommand, "StrToSearch", DbType.String, strToSearch);

            List<ListItem> idGroupList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idGroup = dr.GetOrdinal("IDGroup");
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_idGroup);
                    item.Text = dr.GetString(_idGroup);
                    idGroupList.Add(item);
                }
            }
            return idGroupList;
        }
    }
}
