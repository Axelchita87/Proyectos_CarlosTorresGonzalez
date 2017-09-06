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
    public class AddNewUserDAL
    {
        public void AddNewUser(string userName, string loweredUserName, string userMail, string AgentMail, string lastActivityDate,
                                string firm, string password, string familyName, string agent, string queue,
                                string pcc, string ta, string gds, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddNewUserResources.SP_AddNewUser);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY, DbType.String, userName);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY2, DbType.String, loweredUserName);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY3, DbType.String, userMail);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY4, DbType.String, lastActivityDate);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY5, DbType.String, firm);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY6, DbType.String, password);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY7, DbType.String, familyName);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY8, DbType.String, agent);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY9, DbType.String, queue);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY10, DbType.String, pcc);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY11, DbType.String, ta);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY12, DbType.String, gds);
            db.AddInParameter(dbcomand, Resources.AddNewUserResources.PARAM_QUERY13, DbType.String, AgentMail);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
