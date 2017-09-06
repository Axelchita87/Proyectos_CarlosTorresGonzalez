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
    public class AgentPCCDAL
    {
        public AgentPCC GetAgentPCC(string Agent, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AgentPCCResources.SP_GetAgentPCC);
            db.AddInParameter(dbCommand, Resources.AgentPCCResources.PARAM_QUERY, DbType.String, Agent);


            AgentPCC item = new AgentPCC();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _pcc = dr.GetOrdinal(Resources.AgentPCCResources.PARAM_PCC);


                while (dr.Read())
                {
                    item.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                }
            }
            return item;
        }

    }
}
