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
    public class SetAllFirmModulesDAL
    {
        public void SetTA(string type, string pcc, string ta, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetAllFirmModulesResources.SP_InsertTA);
            db.AddInParameter(dbcomand, Resources.SetAllFirmModulesResources.PARAM_TYPE, DbType.String, type);
            db.AddInParameter(dbcomand, Resources.SetAllFirmModulesResources.PARAM_PCC, DbType.String, pcc);
            db.AddInParameter(dbcomand, Resources.SetAllFirmModulesResources.PARAM_TA, DbType.String, ta);
            db.ExecuteNonQuery(dbcomand);
        }

        public void SetIATA(string iata, string office, string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetAllFirmModulesResources.SP_InsertIATA);
            db.AddInParameter(dbcomand, Resources.SetAllFirmModulesResources.PARAM_IATA, DbType.String, iata);
            db.AddInParameter(dbcomand, Resources.SetAllFirmModulesResources.PARAM_OFFICE, DbType.String, office);
            db.AddInParameter(dbcomand, Resources.SetAllFirmModulesResources.PARAM_PCC, DbType.String, pcc);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
