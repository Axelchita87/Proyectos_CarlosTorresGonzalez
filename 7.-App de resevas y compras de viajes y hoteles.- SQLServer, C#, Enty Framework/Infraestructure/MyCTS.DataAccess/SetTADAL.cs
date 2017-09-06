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
    public class SetTADAL
    {
        public void SetTea(string firm, string ta, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.SetTAResources.SP_SET_TA);
            db.AddInParameter(dbcommand, Resources.SetTAResources.PARAM_FIRM, DbType.String, firm);
            db.AddInParameter(dbcommand, Resources.SetTAResources.PARAM_TA, DbType.String, ta);
            try
            {
                db.ExecuteNonQuery(dbcommand);
            }
            catch { }
        }
    }
}
