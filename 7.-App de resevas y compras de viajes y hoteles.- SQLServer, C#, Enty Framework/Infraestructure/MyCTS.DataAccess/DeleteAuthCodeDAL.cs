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
    public class DeleteAuthCodeDAL
    {
        public void DeleteAuthCode(string pnr, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AuthCodeResources.SP_DeleteAuthCode);
            db.AddInParameter(dbcomand, Resources.AuthCodeResources.PARAM_PNR, DbType.String, pnr);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
