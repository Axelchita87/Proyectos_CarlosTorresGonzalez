using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetClientCreditCardNumberBL
    {
        public static ClientCreditCard GetClientCreditCardNumber(string CreditCardNumber, string Attribute1)
        {
            ClientCreditCard creditCardNumber =new ClientCreditCard();
            GetClientCreditCardNumberDAL objGetCreditCardNumber = new GetClientCreditCardNumberDAL();
            try
            {
                try
                {
                    creditCardNumber = objGetCreditCardNumber.GetClientCreditCardNumber(CreditCardNumber, Attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    creditCardNumber = objGetCreditCardNumber.GetClientCreditCardNumber(CreditCardNumber, Attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return creditCardNumber;
        }

        
        
        public static string GetClientCreditCardNumber(string CreditCardNumber)
        {
            string creditCardNumber = string.Empty;
            GetClientCreditCardNumberDAL objGetCreditCardNumber = new GetClientCreditCardNumberDAL();
            try
            {
                try
                {
                    creditCardNumber = objGetCreditCardNumber.GetClientCreditCardNumber(CreditCardNumber, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    creditCardNumber = objGetCreditCardNumber.GetClientCreditCardNumber(CreditCardNumber, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return creditCardNumber;

        }


        public static ClientCreditCard GetClientCreditCardNumberByClient(string Attribute1)
        {
            ClientCreditCard creditCardNumber = new ClientCreditCard();
            GetClientCreditCardNumberDAL objGetCreditCardNumber = new GetClientCreditCardNumberDAL();
            try
            {
                try
                {
                    creditCardNumber = objGetCreditCardNumber.GetClientCreditCardNumberByClient(Attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    creditCardNumber = objGetCreditCardNumber.GetClientCreditCardNumberByClient(Attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return creditCardNumber;
        }
    }
}
