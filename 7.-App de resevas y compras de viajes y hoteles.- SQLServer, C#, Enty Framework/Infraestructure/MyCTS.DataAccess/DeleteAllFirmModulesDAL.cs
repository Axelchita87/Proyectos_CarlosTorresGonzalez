using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class DeleteAllFirmModulesDAL
    {
        public void DeleteTA(string ta, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteAllFirmModulesResources.SP_DeleteTA);
            db.AddInParameter(dbcomand, Resources.DeleteAllFirmModulesResources.PARAM_TA, DbType.String, ta);
            db.ExecuteNonQuery(dbcomand);
        }

        public void DeleteIATA(string iata, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteAllFirmModulesResources.SP_DeleteIATA);
            db.AddInParameter(dbcomand, Resources.DeleteAllFirmModulesResources.PARAM_IATA, DbType.String, iata);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
