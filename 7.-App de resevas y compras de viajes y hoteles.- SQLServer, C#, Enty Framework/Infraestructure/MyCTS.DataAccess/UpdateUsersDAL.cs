using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class UpdateUsersDAL
    {
        public void UpdateUsers(string Firm, string PCC, string CodeAgent, string UserName, string LoweredUserName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateUsersResources.SP_UpdateUsers);
            db.AddInParameter(dbcomand, Resources.UpdateUsersResources.PARAM_QUERY, DbType.String, CodeAgent);
            db.AddInParameter(dbcomand, Resources.UpdateUsersResources.PARAM_QUERY2, DbType.String, UserName);
            db.AddInParameter(dbcomand, Resources.UpdateUsersResources.PARAM_QUERY3, DbType.String, LoweredUserName);
            db.AddInParameter(dbcomand, Resources.UpdateUsersResources.PARAM_QUERY4, DbType.String, Firm);
            db.AddInParameter(dbcomand, Resources.UpdateUsersResources.PARAM_QUERY5, DbType.String, PCC);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
