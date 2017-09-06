using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{
    public class DeleteAirLinesFareDAL
    {
        public void DeleteAirLinesFare(string catAirLinFarId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteAirLineFareResources.SP_DeleteAirLinesFare);
            db.AddInParameter(dbcomand, Resources.DeleteAirLineFareResources.PARAM_QUERY, DbType.String, catAirLinFarId);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
