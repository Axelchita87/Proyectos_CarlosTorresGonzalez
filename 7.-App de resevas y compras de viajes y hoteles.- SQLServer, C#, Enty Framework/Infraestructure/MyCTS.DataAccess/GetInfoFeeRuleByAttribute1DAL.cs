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
    public class GetInfoFeeRuleByAttribute1DAL
    {
        public List<GetInfoFeeRuleByAttribute1> GetInfoRule(string attribute1, int ruleNumber, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetInfoFeeRuleByAttribute1Resources.SP_GETINFOFEERULEBYATTRIBUTE1);
            db.AddInParameter(dbCommand, Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_QUERY1, DbType.String, attribute1);
            db.AddInParameter(dbCommand, Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_QUERY2, DbType.Int32, ruleNumber);
            db.AddInParameter(dbCommand, Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_ORG_ID, DbType.Int32, OrgId);

            List<GetInfoFeeRuleByAttribute1> listGetInfoFeeRule = new List<GetInfoFeeRuleByAttribute1>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _attribute1 = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_QUERY1);
                int _ruleNumber = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_RULENUMBER);
                int _priority = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_PRIORITY);
                int _description = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_DESCRIPTION);
                int _defaultFee = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_DEFAULTFEE);
                int _defaultMount = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_DEFAULTMOUNT);
                int _mandatory = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_MANDATORY);
                int _activationState = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_ACTIVATIONSTATE);
                int _startDate = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_STARTDATE);
                int _expirationDate = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_EXPIRATIONDATE);
                int _agent = dr.GetOrdinal(Resources.GetInfoFeeRuleByAttribute1Resources.PARAM_CREATEDBYAGENT);

                try
                {
                    while (dr.Read())
                    {
                        GetInfoFeeRuleByAttribute1 item = new GetInfoFeeRuleByAttribute1();
                        item.Attribute1 = dr.GetString(_attribute1);
                        item.RuleNumber = dr.GetInt32(_ruleNumber);
                        item.Priority = dr.GetInt32(_priority);
                        item.Description = dr.GetString(_description);
                        item.DefaultFee = dr.GetDecimal(_defaultFee);
                        item.DefaultMount = dr.GetDecimal(_defaultMount);
                        item.Mandatory = dr.GetBoolean(_mandatory);
                        item.ActivationSatate = dr.GetBoolean(_activationState);
                        item.StartDate = (dr[_startDate] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_startDate);
                        item.ExpirationDate = (dr[_expirationDate] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_expirationDate);
                        item.Agent = dr.GetString(_agent);
                        listGetInfoFeeRule.Add(item);
                    }
                }
                catch { }
                return listGetInfoFeeRule;
            }
        }
    }
}

