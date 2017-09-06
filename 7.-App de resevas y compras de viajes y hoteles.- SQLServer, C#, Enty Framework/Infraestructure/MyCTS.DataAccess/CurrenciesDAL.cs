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
    public class CurrenciesDAL
    {

        //public List<Currency>

        public string GetCurrencies(string fieldName, string fieldValue)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetCurrencies");

            db.AddInParameter(dbCommand, "paramQuery", DbType.String, fieldName);
            db.AddInParameter(dbCommand, "paramValue", DbType.String, fieldValue);
            string countryid = string.Empty;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                
                while (dr.Read())
                {
                    countryid = dr["CurrencyCode"].ToString();                   
                }
            }

            return countryid;

        }
    }
}
