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
    public class SetNewFeeRuleDAL
    {
        public List<SetNewFeeRule> AddNewFeeRule(string attribute1, int priority, string description,
            string extendedDescription, decimal defaultFee, decimal defaultMount, bool mandatory,
            bool activationState, DateTime startDate, DateTime expirationDate, string agente, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetNewFeeRuleResources.SP_SETNEWFEERULE);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY1, DbType.String, attribute1);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY2, DbType.Int32, priority);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY3, DbType.String, description);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY4, DbType.String, extendedDescription);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY5, DbType.Decimal, defaultFee);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY6, DbType.Decimal, defaultMount);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY7, DbType.Boolean, mandatory);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY8, DbType.Boolean, activationState);
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY9, DbType.DateTime, MyCTSConvert.ToDBValue(startDate));
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY10, DbType.DateTime, MyCTSConvert.ToDBValue(expirationDate));
            db.AddInParameter(dbcomand, Resources.SetNewFeeRuleResources.PARAM_QUERY11, DbType.String, agente);

            List<SetNewFeeRule> listNewFeeRule = new List<SetNewFeeRule>();
            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {
                int _idRuleNumber = dr.GetOrdinal(Resources.SetNewFeeRuleResources.PARAM_IDRULENUMBER);
                while (dr.Read())
                {
                    SetNewFeeRule item = new SetNewFeeRule();
                    item.IDRuleNumber = dr.GetInt32(_idRuleNumber);
                    listNewFeeRule.Add(item);
                }
                return listNewFeeRule;
            }

        }
    }
}
