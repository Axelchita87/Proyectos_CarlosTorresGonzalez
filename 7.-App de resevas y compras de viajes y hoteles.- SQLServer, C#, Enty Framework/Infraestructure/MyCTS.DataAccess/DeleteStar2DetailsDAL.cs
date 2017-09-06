using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.DataAccess.Resources;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
     public class DeleteStar2DetailsDAL
    {
        public void DeleteS2Details(string id , string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(DeleteStar2DetailsResources.SP_DeleteStar2Details);

            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Id, DbType.String, id); 
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
