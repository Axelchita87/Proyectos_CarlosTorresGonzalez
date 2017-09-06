using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class ActivationFeeRuleBL
    {
        public static void ActivationFeeRule(int ruleNumber)
        {
            ActivationFeeRuleDAL objActivation = new ActivationFeeRuleDAL();
            {
                try
                {
                    try
                    {
                        objActivation.ActivationFeeRule(ruleNumber, CommonENT.MYCTSDB_CONNECTION);
                    }
                    catch (Exception ex)
                    {
                        new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                        objActivation.ActivationFeeRule(ruleNumber, CommonENT.MYCTSDBBACKUP_CONNECTION);
                    }
                }
                catch { }
            }
        }
    }
}
