using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetCreditCardNumberBL
    {
        public static string GetCreditCardNumber(string CreditCardNumber)
        {
            string creditCardNumber = string.Empty;
            GetCreditCardNumberDAL objGetCreditCardNumber = new GetCreditCardNumberDAL();
            try
            {
                try
                {
                    creditCardNumber = objGetCreditCardNumber.GetCreditCardNumber(CreditCardNumber, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    creditCardNumber = objGetCreditCardNumber.GetCreditCardNumber(CreditCardNumber, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return creditCardNumber;

        }
    }
}