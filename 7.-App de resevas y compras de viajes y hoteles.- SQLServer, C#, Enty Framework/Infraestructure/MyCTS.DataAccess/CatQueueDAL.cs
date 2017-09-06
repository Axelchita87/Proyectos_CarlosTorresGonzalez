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
    public class CatQueueDAL
    {
        public CatQueue GetQueue(string QueueToSearch, string PCCToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatQueueResources.SP_GetQueue);
            db.AddInParameter(dbCommand, Resources.CatQueueResources.PARAM_QUERY, DbType.String, QueueToSearch);
            db.AddInParameter(dbCommand, Resources.CatQueueResources.PARAM_QUERY2, DbType.String, PCCToSearch);

           CatQueue item = new CatQueue();
           using (IDataReader dr = db.ExecuteReader(dbCommand))
           {

                int _agent = dr.GetOrdinal(Resources.CatQueueResources.PARAM_AGENT);
                int _queue = dr.GetOrdinal(Resources.CatQueueResources.PARAM_QUEUE);
                int _pcc = dr.GetOrdinal(Resources.CatQueueResources.PARAM_PCC);

                if (dr.Read())
                {
                    
                    item.Agent = (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
                    item.Queue = (dr[_queue] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_queue);
                    item.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                }
            }

            return item;

        }
    }
}
