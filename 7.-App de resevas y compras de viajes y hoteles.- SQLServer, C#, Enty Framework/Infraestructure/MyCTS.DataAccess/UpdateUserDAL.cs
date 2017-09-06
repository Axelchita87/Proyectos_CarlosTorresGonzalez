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
    public class UpdateUserDAL
    {
        public void UpdateUser(string Firm, string PCC, string CodeAgent, string UserName, string LoweredUserName, 
                               string UserId,string UserMail, string TA, string Queue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateUserResources.SP_UpdateUser);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY, DbType.String, CodeAgent);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY2, DbType.String, UserName);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY3, DbType.String, LoweredUserName);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY4, DbType.String, Firm);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY5, DbType.String, PCC);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY6, DbType.String, UserMail);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY7, DbType.String, TA);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY8, DbType.String, Queue);
            db.AddInParameter(dbcomand, Resources.UpdateUserResources.PARAM_QUERY9, DbType.String, UserId);

            db.ExecuteNonQuery(dbcomand);
        }

    }
}
