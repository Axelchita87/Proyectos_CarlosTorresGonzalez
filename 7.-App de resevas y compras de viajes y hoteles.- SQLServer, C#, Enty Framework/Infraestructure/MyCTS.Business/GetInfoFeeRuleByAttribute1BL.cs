using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetInfoFeeRuleByAttribute1BL
    {
        public static List<GetInfoFeeRuleByAttribute1> GetInfoFeeRule(string attribute1, int ruleNumber, int OrgId)
        {
            List<GetInfoFeeRuleByAttribute1> listInfoFeeRule = new List<GetInfoFeeRuleByAttribute1>();
            GetInfoFeeRuleByAttribute1DAL objGetInfoFeeRule = new GetInfoFeeRuleByAttribute1DAL();
            try
            {
                try
                {
                    listInfoFeeRule = objGetInfoFeeRule.GetInfoRule(attribute1, ruleNumber, OrgId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listInfoFeeRule = objGetInfoFeeRule.GetInfoRule(attribute1, ruleNumber, OrgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listInfoFeeRule;
        }
    }
}

