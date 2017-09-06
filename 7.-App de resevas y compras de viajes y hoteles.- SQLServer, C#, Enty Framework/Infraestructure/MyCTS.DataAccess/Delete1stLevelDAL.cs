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
    public class Delete1stLevelDAL
    {
        public void Delete1stLevel(string pcc, string firstStarName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteProfilesResources.SP_Delete1stLevelProfile);
            db.AddInParameter(dbcomand, Resources.DeleteProfilesResources.PARAM_1ST_LEVEL_PROFILE_NAME, DbType.String, firstStarName);
            db.AddInParameter(dbcomand, Resources.DeleteProfilesResources.PARAM_PCC, DbType.String, pcc);
            db.ExecuteNonQuery(dbcomand);
 
        }
    }
}
