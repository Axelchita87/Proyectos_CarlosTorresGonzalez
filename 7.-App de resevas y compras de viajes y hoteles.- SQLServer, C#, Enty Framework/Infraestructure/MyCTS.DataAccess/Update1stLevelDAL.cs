using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class Update1stLevelDAL
    {
        public void UpdateStarLevel1(string Pccid, string Level1, string NewLevel1, int processId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Update1stLevelResources.SP_UpdateStarLevel1);
            db.AddInParameter(dbcomand, Resources.Update1stLevelResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Update1stLevelResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.Update1stLevelResources.PARAM_QUERY3, DbType.String, NewLevel1);
            db.AddInParameter(dbcomand, Resources.Update1stLevelResources.PARAM_QUERY4, DbType.Int32, processId);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
