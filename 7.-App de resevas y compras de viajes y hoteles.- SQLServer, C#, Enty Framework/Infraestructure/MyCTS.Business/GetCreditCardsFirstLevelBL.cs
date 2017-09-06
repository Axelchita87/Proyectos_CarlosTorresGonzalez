using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetCreditCardsFirstLevelBL
    {
        public static List<string> GetCreditCardsFirstLevel(string level1)
        {
            List<string> creditCard = new List<string>();
            GetCreditCardsFirstLevelDAL objGetCreditCardNumber = new GetCreditCardsFirstLevelDAL();
            
            try
            {
                try
                {
                    creditCard = objGetCreditCardNumber.GetCreditCardsFirstLevel(level1, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    creditCard = objGetCreditCardNumber.GetCreditCardsFirstLevel(level1, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return creditCard;
        }
    }
}
