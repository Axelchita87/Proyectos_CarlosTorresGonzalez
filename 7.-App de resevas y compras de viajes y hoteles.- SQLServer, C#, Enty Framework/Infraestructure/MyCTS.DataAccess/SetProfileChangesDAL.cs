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
    public class SetProfileChangesDAL
    {
        public void SetProfileChanges(string pccid, string agent, string starlevel1, string starlevel2, DateTime modifiedDate, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetProfileChangesResources.SP_SetProfileChanges);
            db.AddInParameter(dbcomand, Resources.SetProfileChangesResources.PARAM_PCCID, DbType.String, pccid);
            db.AddInParameter(dbcomand, Resources.SetProfileChangesResources.PARAM_AGENT, DbType.String, agent);
            db.AddInParameter(dbcomand, Resources.SetProfileChangesResources.PARAM_STARLEVEL1, DbType.String, starlevel1);
            db.AddInParameter(dbcomand, Resources.SetProfileChangesResources.PARAM_STARLEVEL2, DbType.String, starlevel2);
            db.AddInParameter(dbcomand, Resources.SetProfileChangesResources.PARAM_MODIFIED_DATE, DbType.DateTime, modifiedDate);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
