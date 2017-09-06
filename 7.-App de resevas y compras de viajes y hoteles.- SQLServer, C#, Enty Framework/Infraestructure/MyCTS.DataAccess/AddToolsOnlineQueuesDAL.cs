using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class AddToolsOnlineQueuesDAL
    {
        public void AddToolsOnlineQueues(AddToolsOnlineQueues queue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddToolsOnlineQueuesResources.SP_AddToolOnlineQueues);
            db.AddInParameter(dbcomand, Resources.AddToolsOnlineQueuesResources.PARAM_QUEUES, DbType.Int32,queue.Queue);
            db.AddInParameter(dbcomand, Resources.AddToolsOnlineQueuesResources.PARAM_PCC, DbType.String, queue.PCC);
            db.AddInParameter(dbcomand, Resources.AddToolsOnlineQueuesResources.PARAM_PICCODE, DbType.Int32, queue.PicCode);
            db.AddInParameter(dbcomand, Resources.AddToolsOnlineQueuesResources.PARAM_DESCRIPTION, DbType.String, queue.Descripcion);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
