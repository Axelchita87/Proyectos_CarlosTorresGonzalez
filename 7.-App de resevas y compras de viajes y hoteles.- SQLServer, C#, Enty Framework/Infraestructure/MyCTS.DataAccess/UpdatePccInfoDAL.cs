using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class UpdatePccInfoDAL
    {
        public void UpdatePcc(string pcc, string name, string application, string type, string tool,string gds, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.UpdatePccInfoResources.SP_UpdatePcc);
            db.AddInParameter(dbcommand, Resources.UpdatePccInfoResources.PARAM_PCC, DbType.String, pcc);
            db.AddInParameter(dbcommand, Resources.UpdatePccInfoResources.PARAM_CAT_PCC_NAME, DbType.String, name);
            db.AddInParameter(dbcommand, Resources.UpdatePccInfoResources.PARAM_APPLICATION_ID, DbType.String, application);
            db.AddInParameter(dbcommand, Resources.UpdatePccInfoResources.PARAM_TYPE, DbType.String, type);
            db.AddInParameter(dbcommand, Resources.UpdatePccInfoResources.PARAM_TOOL, DbType.String, tool);
            db.AddInParameter(dbcommand, Resources.UpdatePccInfoResources.PARAM_GDS, DbType.String, gds);
            db.ExecuteReader(dbcommand);
        }
    }
}
