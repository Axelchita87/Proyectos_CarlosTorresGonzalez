using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class DeleteToolOnlineQueuesDAL
    {
        public void DeleteToolOnlineQueues(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteToolOnlineQueuesResources.SP_DeleteToolOnlineQueues);
            db.AddInParameter(dbcomand, Resources.DeleteToolOnlineQueuesResources.PARAM_QUERY, DbType.String, StrToSearch);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
