using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CurrenciesBL
    {

        public static string GetCurrencies(string fieldName, string fieldValue)
        {

            return new CurrenciesDAL().GetCurrencies(fieldName, fieldValue);
        }
    }
}
