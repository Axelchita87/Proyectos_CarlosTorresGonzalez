using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CurrencyCountryBL
    {
        public static List<CurrencyCountry> GetCurrencyCountry(string fieldName, string fieldName2, string fieldValue)
        {
            List<CurrencyCountry> listCurrencyCountry = new List<CurrencyCountry>();
            CurrencyCountryDAL objCurrencyCountry = new CurrencyCountryDAL();
            try
            {
                try
                {
                    listCurrencyCountry = objCurrencyCountry.GetCurrencyCountry(fieldName, fieldName2, fieldValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listCurrencyCountry = objCurrencyCountry.GetCurrencyCountry(fieldName, fieldName2, fieldValue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listCurrencyCountry;

        }
    }
}
