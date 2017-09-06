using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class CatRolesDAL
    {
        public List<ListItem> GetCatRoles(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatRolesResources.SP_GetCatRoles);
            List<ListItem> listCatRoles = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _rolename = dr.GetOrdinal(Resources.CatRolesResources.PARAM_ROLENAME);
                int _description = dr.GetOrdinal(Resources.CatRolesResources.PARAM_DESCRIPTION);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_rolename] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rolename) + " " + ((dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description));
                    listCatRoles.Add(item);
                }
            }
            return listCatRoles;
        }

    }
}
