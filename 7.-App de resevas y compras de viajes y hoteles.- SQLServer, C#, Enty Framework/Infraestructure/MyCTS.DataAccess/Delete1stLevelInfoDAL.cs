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
    public class Delete1stLevelInfoDAL
    {
        public void DeleteStarLevel1Info(string Pccid, string Level1, string LineType, string Text, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Delete1stLevelInfoResources.SP_DeleteStarLevel1Info);
            db.AddInParameter(dbcomand, Resources.Delete1stLevelInfoResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Delete1stLevelInfoResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.Delete1stLevelInfoResources.PARAM_QUERY3, DbType.String, LineType);
            db.AddInParameter(dbcomand, Resources.Delete1stLevelInfoResources.PARAM_QUERY4, DbType.String, Text);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
