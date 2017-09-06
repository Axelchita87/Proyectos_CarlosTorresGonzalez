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
    public class UpdateAirPortDAL
    {
        public void UpdateAirPort(string catAirPorCode, string catAirPorName, string catAirPorCountryId, string catAirPorCountryName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateAirPortResources.SP_UpdateAirPort);
            db.AddInParameter(dbcomand, Resources.UpdateAirPortResources.PARAM_QUERY, DbType.String, catAirPorCode);
            db.AddInParameter(dbcomand, Resources.UpdateAirPortResources.PARAM_QUERY2, DbType.String, catAirPorName);
            db.AddInParameter(dbcomand, Resources.UpdateAirPortResources.PARAM_QUERY3, DbType.String, catAirPorCountryId);
            db.AddInParameter(dbcomand, Resources.UpdateAirPortResources.PARAM_QUERY4, DbType.String, catAirPorCountryName);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
