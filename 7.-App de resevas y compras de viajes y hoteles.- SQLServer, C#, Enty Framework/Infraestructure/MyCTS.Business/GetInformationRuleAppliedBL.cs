using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class GetInformationRuleAppliedBL
    {
        public static List<GetInformationRuleApplied> GetInfoRule(int numberRule, bool status)
        {
            List<GetInformationRuleApplied> listGetInfoRuleApplied = new List<GetInformationRuleApplied>();
            GetInformationRuleAppliedDAL objInfoRule = new GetInformationRuleAppliedDAL();
            try
            {
                try
                {
                    listGetInfoRuleApplied = objInfoRule.GetInformationRuleAppliedIndex(numberRule, status, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listGetInfoRuleApplied = objInfoRule.GetInformationRuleAppliedIndex(numberRule, status, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listGetInfoRuleApplied;
        }
    }
}
