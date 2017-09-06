using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class OnlineToolsQueuesDAL
    {
        public List<OnlineToolsQueues> GetOnlineToolsQueues( string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.OnlineToolsQueuesResources.SP_Get_ToolOnlineQueues);

            List<OnlineToolsQueues> listOnlineQueue = new List<OnlineToolsQueues>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    int _queue = dr.GetOrdinal(Resources.OnlineToolsQueuesResources.PARAM_QUEUES);
                    int _pcc = dr.GetOrdinal(Resources.OnlineToolsQueuesResources.PARAM_PCC);
                    int _piccode = dr.GetOrdinal(Resources.OnlineToolsQueuesResources.PARAM_PICCODE);
                    int _description = dr.GetOrdinal(Resources.OnlineToolsQueuesResources.PARAM_DESCRIPTION);

                    OnlineToolsQueues item = new OnlineToolsQueues();

                    item.Queue = (dr[_queue] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_queue);
                    item.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                    item.PicCode = (dr[_piccode] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_piccode);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    listOnlineQueue.Add(item);
                }
            }
            return listOnlineQueue;
        }
    }
}
