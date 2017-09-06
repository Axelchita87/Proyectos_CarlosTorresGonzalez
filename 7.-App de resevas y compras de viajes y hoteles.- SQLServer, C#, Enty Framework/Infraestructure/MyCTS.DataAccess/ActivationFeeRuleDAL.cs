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
    public class ActivationFeeRuleDAL
    {
        public void ActivationFeeRule(int ruleNumber, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.ActivationFeeRuleResources.SP_ACTIVATIONFEERULE);
            db.AddInParameter(dbcomand, Resources.ActivationFeeRuleResources.PARAM_QUERY1, DbType.Int32, ruleNumber);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
