using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class AssignQueueFirmDAL
    {
        public void AssignQueueFirm(string newQueue, string agent, string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AssignQueueFirmResources.SP_AssignQueueFirm);
            db.AddInParameter(dbCommand, Resources.AssignQueueFirmResources.PARAM_NEW_QUEUE, DbType.String, newQueue);
            db.AddInParameter(dbCommand, Resources.AssignQueueFirmResources.PARAM_AGENT, DbType.String, agent);
            db.AddInParameter(dbCommand, Resources.AssignQueueFirmResources.PARAM_PCC, DbType.String, pcc);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
