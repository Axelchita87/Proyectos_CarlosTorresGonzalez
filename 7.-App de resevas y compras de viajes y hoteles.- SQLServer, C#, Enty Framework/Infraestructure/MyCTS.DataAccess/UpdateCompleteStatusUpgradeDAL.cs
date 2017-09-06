using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class UpdateCompleteStatusUpgradeDAL
    {
        public void UpdateCompleteStatusUpgrade(Guid UserId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpgradeFilesResources.SP_UPDATECOMPLETESTATUSUPGRADE);
            db.AddInParameter(dbcomand, Resources.UpgradeFilesResources.PARAM_USERID, DbType.Guid, UserId);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
