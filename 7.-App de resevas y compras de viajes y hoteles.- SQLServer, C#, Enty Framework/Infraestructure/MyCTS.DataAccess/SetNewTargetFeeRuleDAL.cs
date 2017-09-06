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
    public class SetNewTargetFeeRuleDAL
    {
        public void AddNewTargetFeeRule(int ruleNumber, int idte, string value2, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetNewTargetFeeRuleResources.SP_SETNEWTARGETFEERULE);
            db.AddInParameter(dbcomand, Resources.SetNewTargetFeeRuleResources.PARAM_QUERY1, DbType.Int32, ruleNumber);
            db.AddInParameter(dbcomand, Resources.SetNewTargetFeeRuleResources.PARAM_QUERY2, DbType.Int32, idte);
            db.AddInParameter(dbcomand, Resources.SetNewTargetFeeRuleResources.PARAM_QUERY3, DbType.String, value2);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
