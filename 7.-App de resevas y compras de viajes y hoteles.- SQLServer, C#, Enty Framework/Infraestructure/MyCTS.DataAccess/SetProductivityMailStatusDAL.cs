using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace MyCTS.DataAccess
{
    public class SetProductivityMailStatusDAL
    {
        public void SetProductivityMailStatus(string Firm, string Pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetProductivityMailStatusResources.SP_SetProductivityMailStatus);
            db.AddInParameter(dbcomand, Resources.SetProductivityMailStatusResources.PARAM_QUERY_FIRM, DbType.String, Firm);
            db.AddInParameter(dbcomand, Resources.SetProductivityMailStatusResources.PARAM_QUERY_PCC, DbType.String, Pcc);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
