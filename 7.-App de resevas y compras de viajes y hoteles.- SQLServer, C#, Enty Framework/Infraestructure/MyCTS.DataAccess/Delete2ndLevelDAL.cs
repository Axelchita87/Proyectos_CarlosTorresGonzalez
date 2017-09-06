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
    public class Delete2ndLevelDAL
    {
        public void Delete2ndLevel(string secondStarName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteProfilesResources.SP_Delete2ndLevelProfile);
            db.AddInParameter(dbcomand, Resources.DeleteProfilesResources.PARAM_2ND_LEVEL_PROFILE_NAME, DbType.String, secondStarName);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
