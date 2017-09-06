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
    public class Active2ndLevelDAL
    {
        public void ActiveStarLevel2(string Pccid, string Level1, string Level2, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Active2ndLevelResources.SP_ActiveStarLevel2);
            db.AddInParameter(dbcomand, Resources.Active2ndLevelResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Active2ndLevelResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.Active2ndLevelResources.PARAM_QUERY3, DbType.String, Level2);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
