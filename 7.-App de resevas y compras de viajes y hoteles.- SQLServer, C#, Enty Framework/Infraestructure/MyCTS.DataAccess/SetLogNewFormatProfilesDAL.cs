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
    public class SetLogNewFormatProfilesDAL
    {
        public void SetLogNewFormatProfiles(string pccid, string name, string starlevel1, string starlevel2, DateTime modifiedDate, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.LogNewFormatProfilesResources.SP_SetLogNewFormatProfiles);
            db.AddInParameter(dbcommand, Resources.LogNewFormatProfilesResources.PARAM_PCC, DbType.String, pccid);
            db.AddInParameter(dbcommand, Resources.LogNewFormatProfilesResources.PARAM_USER_NAME, DbType.String, name);
            db.AddInParameter(dbcommand, Resources.LogNewFormatProfilesResources.PARAM_STARLEVEL1, DbType.String, starlevel1);
            db.AddInParameter(dbcommand, Resources.LogNewFormatProfilesResources.PARAM_STARLEVEL2, DbType.String, starlevel2);
            db.AddInParameter(dbcommand, Resources.LogNewFormatProfilesResources.PARAM_MODIFIED_DATE, DbType.DateTime, modifiedDate);
            db.ExecuteNonQuery(dbcommand);
        }

    }
}
