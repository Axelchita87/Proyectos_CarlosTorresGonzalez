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
    public class GetInformationRuleAppliedDAL
    {
        public List<GetInformationRuleApplied> GetInformationRuleAppliedIndex(int numberRule, bool status, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetInformationRuleAppliedResources.SP_GETINFORMATIONRULEAPPLIED);
            db.AddInParameter(dbCommand, Resources.GetInformationRuleAppliedResources.PARAM_QUERY1, DbType.Int32, numberRule);
            db.AddInParameter(dbCommand, Resources.GetInformationRuleAppliedResources.PARAM_QUERY2, DbType.Boolean, status);

            List<GetInformationRuleApplied> getInfoRuleList = new List<GetInformationRuleApplied>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _defaultFee = dr.GetOrdinal(Resources.GetInformationRuleAppliedResources.PARAM_DEFAULTFEE);
                int _defaultMount = dr.GetOrdinal(Resources.GetInformationRuleAppliedResources.PARAM_DEFAULTMOUNT);
                int _mandatory = dr.GetOrdinal(Resources.GetInformationRuleAppliedResources.PARAM_MANDATORY);
                int _value2 = dr.GetOrdinal(Resources.GetInformationRuleAppliedResources.PARAM_VALUE2);
                int _target = dr.GetOrdinal(Resources.GetInformationRuleAppliedResources.PARAM_TARGET);

                while (dr.Read())
                {
                    GetInformationRuleApplied item = new GetInformationRuleApplied();
                    item.DefaultFee = (dr[_defaultFee] == DBNull.Value) ? Types.DecimalNullValue : dr.GetDecimal(_defaultFee);
                    item.DefaultMount = (dr[_defaultMount] == DBNull.Value) ? Types.DecimalNullValue : dr.GetDecimal(_defaultMount);
                    item.Mandatory = dr.GetBoolean(_mandatory);
                    item.Value2 = (dr[_value2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_value2);
                    item.Target = (dr[_target] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_target);
                    getInfoRuleList.Add(item);
                }
                return getInfoRuleList;
            }
        }
    }
}
