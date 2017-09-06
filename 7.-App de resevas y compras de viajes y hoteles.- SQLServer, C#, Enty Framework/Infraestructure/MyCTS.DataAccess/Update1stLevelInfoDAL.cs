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
    public class Update1stLevelInfoDAL
    {
        public void UpdateStarLevel1Info(string Pccid, string Level1, string LineType, string Text, string NewText, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Update1stLevelInfoResources.SP_UpdateStarLevel1Info);
            db.AddInParameter(dbcomand, Resources.Update1stLevelInfoResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Update1stLevelInfoResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.Update1stLevelInfoResources.PARAM_QUERY3, DbType.String, LineType);
            db.AddInParameter(dbcomand, Resources.Update1stLevelInfoResources.PARAM_QUERY4, DbType.String, Text);
            db.AddInParameter(dbcomand, Resources.Update1stLevelInfoResources.PARAM_QUERY5, DbType.String, NewText);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
