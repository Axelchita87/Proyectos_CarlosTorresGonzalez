using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class CurrencyCountryDAL
    {
        public List<CurrencyCountry> GetCurrencyCountry(string fieldName, string fieldName2, string fieldValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CurrencyCountryResource.SP_GetCurrencyCountry);
            db.AddInParameter(dbCommand, Resources.CurrencyCountryResource.PARAM_QUERY, DbType.String, fieldName);
            db.AddInParameter(dbCommand, Resources.CurrencyCountryResource.PARAM_QUERY2, DbType.String, fieldName2);    
            db.AddInParameter(dbCommand, Resources.CurrencyCountryResource.PARAM_VALUE, DbType.String, fieldValue);

            List<CurrencyCountry> listCurrencyCountry = new List<CurrencyCountry>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _currencycode = dr.GetOrdinal(Resources.CurrencyCountryResource.PARAM_CURRENCYCODE);
                int _currencyname = dr.GetOrdinal(Resources.CurrencyCountryResource.PARAM_CURRENCYNAME);
                int _countryid = dr.GetOrdinal(Resources.CurrencyCountryResource.PARAM_COUNTRYID);
                int _countryname = dr.GetOrdinal(Resources.CurrencyCountryResource.PARAM_COUNTRYNAME);
                while (dr.Read())
                {
                    CurrencyCountry item = new CurrencyCountry();
                    item.CurrencyCode = dr.GetString(_currencycode);
                    item.CurrencyName = dr.GetString(_currencyname);
                    item.CountryID = dr.GetString(_countryid);
                    item.CountryName = dr.GetString(_countryname);
                    listCurrencyCountry.Add(item);
                }
            }

            return listCurrencyCountry;
        }
    }
}
