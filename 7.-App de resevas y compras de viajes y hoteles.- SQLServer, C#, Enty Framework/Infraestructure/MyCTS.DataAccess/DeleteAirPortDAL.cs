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
    public class DeleteAirPortDAL
    {
        public void DeleteAirPorts(string catAirPorCode, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteAirPortResources.SP_DeleteAirPort);
            db.AddInParameter(dbcomand, Resources.DeleteAirPortResources.PARAM_QUERY, DbType.String, catAirPorCode);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
