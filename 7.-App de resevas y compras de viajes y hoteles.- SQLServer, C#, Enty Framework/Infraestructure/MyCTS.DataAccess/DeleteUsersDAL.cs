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
    public class DeleteUsersDAL
    {
        public void DeleteUsers(string Firm, string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteUsersResources.SP_DeleteUsers);
            db.AddInParameter(dbcomand, Resources.DeleteUsersResources.PARAM_QUERY, DbType.String, Firm);
            db.AddInParameter(dbcomand, Resources.DeleteUsersResources.PARAM_QUERY1, DbType.String, PCC);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
