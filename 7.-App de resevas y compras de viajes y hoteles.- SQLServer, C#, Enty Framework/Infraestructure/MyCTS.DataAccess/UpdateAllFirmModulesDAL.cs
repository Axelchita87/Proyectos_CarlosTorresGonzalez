using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class UpdateAllFirmModulesDAL
    {

        public void UpdateTA(string ta, string type, string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UpdateAllFirmModulesResources.SP_UpdateTA);
            db.AddInParameter(dbCommand, Resources.UpdateAllFirmModulesResources.PARAM_TA, DbType.String, ta);
            db.AddInParameter(dbCommand, Resources.UpdateAllFirmModulesResources.PARAM_TYPE, DbType.String, type);
            db.AddInParameter(dbCommand, Resources.UpdateAllFirmModulesResources.PARAM_PCC, DbType.String, pcc);
            db.ExecuteNonQuery(dbCommand);
        }


        public void UpdateIATA(string iata, string office, string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UpdateAllFirmModulesResources.SP_UpdateIATA);
            db.AddInParameter(dbCommand, Resources.UpdateAllFirmModulesResources.PARAM_IATA, DbType.String, iata);
            db.AddInParameter(dbCommand, Resources.UpdateAllFirmModulesResources.PARAM_OFFICE, DbType.String, office);
            db.AddInParameter(dbCommand, Resources.UpdateAllFirmModulesResources.PARAM_PCC, DbType.String, pcc);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
