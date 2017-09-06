using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetCreditCardsSecondLevelBL
    {
        public static List<string> GetCreditCardsSecondLevel(string name, string lastName, string level1)
        {
            List<string> creditCard = new List<string>();
            GetCreditCardsSecondLevelDAL objGetCreditCardNumber = new GetCreditCardsSecondLevelDAL();

            try
            {
                try
                {
                    creditCard = objGetCreditCardNumber.GetCreditCardsSecondLevel(name, lastName,level1, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    creditCard = objGetCreditCardNumber.GetCreditCardsSecondLevel(name, lastName, level1, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return creditCard;
        }
    }
}
