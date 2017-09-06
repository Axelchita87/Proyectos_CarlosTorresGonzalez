using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class DeleteToolOnlineRulesDAL
    {
        public void DeleteRules(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteToolOnlineRulesResources.SP_DELETETOOLONLINERULES);
            db.AddInParameter(dbcomand, Resources.DeleteToolOnlineRulesResources.PARAM_QUERY, DbType.String, StrToSearch);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
