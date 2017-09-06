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
    public class UpdateAuthCodeDAL
    {
        public void UpdateAuthCode(string pnr, string authCode, string tickets, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AuthCodeResources.SP_UpdateAuthCode);
            db.AddInParameter(dbCommand, Resources.AuthCodeResources.PARAM_QUERY_PNR, DbType.String, pnr);
            db.AddInParameter(dbCommand, Resources.AuthCodeResources.PARAM_QUERY_AUTH_CODE, DbType.String, authCode);
            db.AddInParameter(dbCommand, Resources.AuthCodeResources.PARAM_QUERY_TICKET, DbType.String, tickets);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
