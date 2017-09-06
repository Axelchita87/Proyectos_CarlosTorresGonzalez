using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class DeletePccDAL
    {
        public void DeletePcc(string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeletePccsResources.SP_DeletePccs);
            db.AddInParameter(dbcomand, Resources.DeletePccsResources.PARAM_QUERY, DbType.String, pcc);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
