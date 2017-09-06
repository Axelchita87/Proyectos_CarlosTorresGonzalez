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
    public class Update2ndLevelInfoDAL
    {
        public void UpdateStarLevel2Info(string Pccid, string Level1, string Level2, string LineType, string Text, string NewText, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Update2ndLevelInfoResources.SP_UpdateStarLevel2Info);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelInfoResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelInfoResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelInfoResources.PARAM_QUERY3, DbType.String, Level2);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelInfoResources.PARAM_QUERY4, DbType.String, LineType);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelInfoResources.PARAM_QUERY5, DbType.String, Text);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelInfoResources.PARAM_QUERY6, DbType.String, NewText);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
