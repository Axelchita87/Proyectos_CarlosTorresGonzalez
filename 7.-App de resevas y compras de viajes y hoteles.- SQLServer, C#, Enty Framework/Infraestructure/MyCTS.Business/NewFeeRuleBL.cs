using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class NewFeeRuleBL
    {
        public static List<SetNewFeeRule> SetNewFeeRule(string attribute1, int priority, string description,
            string extendedDescription, decimal defaultFee, decimal defaultMount, bool mandatory,
            bool activationState, string startDate, string expirationDate, string agent)
        {
            List<SetNewFeeRule> listRuleNumber = new List<SetNewFeeRule>();
            DateTime dtStartDate;
            if (!DateTime.TryParse(startDate, out dtStartDate))
                dtStartDate = Components.NullableHelper.Types.DateNullValue;
            DateTime dtExpirationDate;
            if (!DateTime.TryParse(expirationDate, out dtExpirationDate))
                dtExpirationDate = Components.NullableHelper.Types.DateNullValue;

            SetNewFeeRuleDAL objList = new SetNewFeeRuleDAL();
            try
            {
                try
                {
                    listRuleNumber = objList.AddNewFeeRule(attribute1, priority, description,
                        extendedDescription, defaultFee, defaultMount, mandatory, activationState,
                        dtStartDate, dtExpirationDate, agent, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listRuleNumber = objList.AddNewFeeRule(attribute1, priority, description,
                        extendedDescription, defaultFee, defaultMount, mandatory, activationState,
                        dtStartDate, dtExpirationDate, agent, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listRuleNumber;
        }
    }
}
