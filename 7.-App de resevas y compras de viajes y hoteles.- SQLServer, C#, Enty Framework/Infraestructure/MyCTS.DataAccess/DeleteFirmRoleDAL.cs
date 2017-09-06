using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class DeleteFirmRoleDAL
    {
        public void DeleteFirmRole(string UserName, string RoleName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteFirmRoleResources.SP_DeleteFirmRole);
            db.AddInParameter(dbcomand, Resources.DeleteFirmRoleResources.PARAM_QUERY, DbType.String, UserName);
            db.AddInParameter(dbcomand, Resources.DeleteFirmRoleResources.PARAM_QUERY1, DbType.String, RoleName);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
