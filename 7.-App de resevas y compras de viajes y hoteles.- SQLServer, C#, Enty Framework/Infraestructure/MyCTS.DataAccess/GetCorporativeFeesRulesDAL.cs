using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class GetCorporativeFeesRulesDAL
    {
        public List<GetCorporativeFeesRules> GetCorporativeFeesRulesIndex(string location_dk, string attribute1, double quantity, string te1, string te2,
            string te3, string te4, string te5, string te6, string te7, string te8, string te9, string te10, string te11, string te12,
            string te13, string te14, string te15, string te16, string te17, string te18, string te19, string te20, string te21, string te23, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCorporativeFeesRules.SP_GetCorporativeFeesRules);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY_DK, DbType.String, location_dk);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERYATTRIBUTE1, DbType.String, attribute1);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY_QUANTITY, DbType.Double, quantity);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY1, DbType.String, te1);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY2, DbType.String, te2);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY3, DbType.String, te3);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY4, DbType.String, te4);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY5, DbType.String, te5);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY6, DbType.String, te6);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY7, DbType.String, te7);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY8, DbType.String, te8);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY9, DbType.String, te9);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY10, DbType.String, te10);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY11, DbType.String, te11);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY12, DbType.String, te12);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY13, DbType.String, te13);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY14, DbType.String, te14);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY15, DbType.String, te15);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY16, DbType.String, te16);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY17, DbType.String, te17);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY18, DbType.String, te18);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY19, DbType.String, te19);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY20, DbType.String, te20);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY21, DbType.String, te21);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeesRules.PARAM_QUERY23, DbType.String, te23);

            List<GetCorporativeFeesRules> getCorporativeFeesRulesList = new List<GetCorporativeFeesRules>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.FieldCount <= 0) return getCorporativeFeesRulesList;
                else
                {
                    int _cantidadCalculada = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_CANTIDAD_CALCULADA);
                    int _ruleNumber = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_RULENUMBER);
                    int _priority = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_PRIORITY);
                    //int _extendedDescription = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_EXTENDEDDESCRIPTION);
                    int _mandatory = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_MANDATORY);
                    int _activationState = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_ACTIVATIONSTATE);
                    int _startDate = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_STARTDATE);
                    int _expirationDate = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_EXPIRATIONDATE);
                    int _timeRange = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_TIMERANGE);
                    int _baseFare = dr.GetOrdinal(Resources.GetCorporativeFeesRules.PARAM_BASEFARE);

                    while (dr.Read())
                    {
                        GetCorporativeFeesRules item = new GetCorporativeFeesRules
                                                           {
                                                               CantidadCalculada = dr.GetDecimal(_cantidadCalculada),
                                                               RuleNumber = dr.GetInt32(_ruleNumber),
                                                               Priority = (dr[_priority] == DBNull.Value)
                                                                              ? Types.IntegerNullValue
                                                                              : dr.GetInt32(_priority),
                                                               Mandatory = dr.GetBoolean(_mandatory),
                                                               ActivationState = dr.GetBoolean(_activationState),
                                                               StartDate = (dr[_startDate] == DBNull.Value)
                                                                               ? Types.DateNullValue
                                                                               : dr.GetDateTime(_startDate),
                                                               ExpirationDate = (dr[_expirationDate] == DBNull.Value)
                                                                                    ? Types.DateNullValue
                                                                                    : dr.GetDateTime(_expirationDate),
                                                               TimeRange = (dr[_timeRange] == DBNull.Value)
                                                                               ? Types.StringNullValue
                                                                               : dr.GetString(_timeRange),
                                                               BaseFare = (dr[_baseFare] == DBNull.Value)
                                                                              ? Types.StringNullValue
                                                                              : dr.GetString(_baseFare)
                                                           };
                        //item.ExtendedDescription = dr.GetString(_extendedDescription);
                        getCorporativeFeesRulesList.Add(item);
                    }
                }
            }
            return getCorporativeFeesRulesList;
        }
    }
}