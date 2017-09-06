using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetNewTargetFeeRuleBL
    {
        public static void AddNewTargetFeeRule(int ruleNumber, int idte, string value2)
        {
            SetNewTargetFeeRuleDAL objAddNewTarget = new SetNewTargetFeeRuleDAL();
            try
            {
                try
                {
                    objAddNewTarget.AddNewTargetFeeRule(ruleNumber, idte, value2, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAddNewTarget.AddNewTargetFeeRule(ruleNumber, idte, value2, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
