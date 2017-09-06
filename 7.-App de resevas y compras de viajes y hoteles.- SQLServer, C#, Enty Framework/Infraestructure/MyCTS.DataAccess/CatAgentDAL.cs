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
    public class CatAgentDAL
    {
        public CatAgent GetSingleAgent(string FirmToSearch, string PCCToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatAgentResources.SP_GetAgent);
            db.AddInParameter(dbCommand, Resources.CatAgentResources.PARAM_QUERY, DbType.String, FirmToSearch);
            db.AddInParameter(dbCommand, Resources.CatAgentResources.PARAM_QUERY2, DbType.String, PCCToSearch);

            CatAgent item = new CatAgent();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _agent = dr.GetOrdinal(Resources.CatAgentResources.PARAM_AGENT);
                
                if (dr.Read())
                {
                    item.Agent = (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
                }
            }

            return item;

        }

    }
}
