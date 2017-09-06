using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class InsertPccDAL
    {
        public void InsertPcc(string pcc, string name, string application, string type, string tool, string gds, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.InsertPccResources.SP_InsertPcc);
            db.AddInParameter(dbcommand, Resources.InsertPccResources.PARAM_CAT_PCC_ID, DbType.String, pcc);
            db.AddInParameter(dbcommand, Resources.InsertPccResources.PARAM_CAT_PCC_NAME, DbType.String, name);
            db.AddInParameter(dbcommand, Resources.InsertPccResources.PARAM_APPLICATION_ID, DbType.String, application);
            db.AddInParameter(dbcommand, Resources.InsertPccResources.PARAM_TYPE, DbType.String, type);
            db.AddInParameter(dbcommand, Resources.InsertPccResources.PARAM_TOOL, DbType.String, tool);
            db.AddInParameter(dbcommand, Resources.InsertPccResources.PARAM_GDS, DbType.String, gds);
            
            db.ExecuteReader(dbcommand);
        }
    }
}
