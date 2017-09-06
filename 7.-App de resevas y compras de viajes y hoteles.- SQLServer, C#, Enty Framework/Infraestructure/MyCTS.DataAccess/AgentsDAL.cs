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
    public class AgentsDAL
    {
        public List<ListItem> GetAgents(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AgentsResources.SP_GetAgents);
            db.AddInParameter(dbCommand, Resources.AgentsResources.PARAM_QUERY, DbType.String, StrToSearch);


            List<ListItem> CatAgentsList = new List<ListItem>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _agent = dr.GetOrdinal(Resources.AgentsResources.PARAM_AGENT);
                int _familyname = dr.GetOrdinal(Resources.AgentsResources.PARAM_FAMILYNAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_agent);
                    item.Text = string.Concat(dr.GetString(_agent), ' ', (dr[_familyname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_familyname));

                    CatAgentsList.Add(item);
                }
            }
            return CatAgentsList;
        }
    }
}
