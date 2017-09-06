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
    public class Active1stLevelDAL
    {
        public void ActiveStarLevel1(string Pccid, string Level1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.Active1stLevelResources.SP_ActiveStarLevel1);
            db.AddInParameter(dbcomand, Resources.Active1stLevelResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.Active1stLevelResources.PARAM_QUERY2, DbType.String, Level1);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}