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
    public class LogsApplicationDAL
    {

        public void AddLogApplication(LogsApplication item, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("AddLogApplication");

            db.AddInParameter(dbCommand, "UserName", DbType.String, item.UserName);
            db.AddInParameter(dbCommand, "Firm", DbType.String, MyCTSConvert.ToDBValue(item.Firm));
            db.AddInParameter(dbCommand, "UserControlName", DbType.String, MyCTSConvert.ToDBValue(item.UserControlName));
            db.AddInParameter(dbCommand, "ErrorDescription", DbType.String, MyCTSConvert.ToDBValue(item.ErrorDescription));
            db.AddInParameter(dbCommand, "StackTrace", DbType.String, MyCTSConvert.ToDBValue(item.StackTrace));

            db.ExecuteNonQuery(dbCommand);

        }

    }
}
