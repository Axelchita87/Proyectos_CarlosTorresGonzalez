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
    public class EnableDisableFirmDAL
    {
        public void EnableDisableFirm(string Firm, string PCC, int Active, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.EnableDisableFirmResources.SP_spEnableDisableFirm);
            db.AddInParameter(dbcomand, Resources.EnableDisableFirmResources.PARAM_QUERY, DbType.String, Firm);
            db.AddInParameter(dbcomand, Resources.EnableDisableFirmResources.PARAM_QUERY2, DbType.String, PCC);
            db.AddInParameter(dbcomand, Resources.EnableDisableFirmResources.PARAM_QUERY1, DbType.String, Active);
            db.ExecuteNonQuery(dbcomand);
        }

    }
}
