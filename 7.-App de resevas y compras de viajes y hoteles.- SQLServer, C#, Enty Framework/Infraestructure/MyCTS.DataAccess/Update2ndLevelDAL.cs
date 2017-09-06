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
    public class Update2ndLevelDAL
    {
        public void UpdateStarLevel2(string Pccid, string Level1, string Level2, string NewLevel2, string Email, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Update2ndLevelResources.SP_UpdateStarLevel2);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelResources.PARAM_QUERY3, DbType.String, Level2);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelResources.PARAM_QUERY4, DbType.String, NewLevel2);
            db.AddInParameter(dbcomand, Resources.Update2ndLevelResources.PARAM_EMAIL, DbType.String, Email);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
