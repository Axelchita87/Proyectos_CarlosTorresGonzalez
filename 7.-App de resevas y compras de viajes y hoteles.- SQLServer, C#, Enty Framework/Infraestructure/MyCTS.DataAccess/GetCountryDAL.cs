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
    public class GetCountryDAL
    {
        public string GetCountry(string Country, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCountryResources.SP_GET_COUNTRY);
            db.AddInParameter(dbCommand, Resources.GetCountryResources.PARAM_COUNTRY, DbType.String, Country);
            string country = string.Empty;
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _country = dr.GetOrdinal(Resources.GetCountryResources.PARAM_CATCOUNAME);
                    if (dr.Read())
                    {
                        country = dr.GetString(_country);
                    }
                }
            }
            catch { }
            
            return country;
        }

        public string GetCountryByCity(string city, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCountryResources.SP_GetCountryByCity);
            db.AddInParameter(dbCommand, Resources.GetCountryResources.PARAM_CITY, DbType.String, city);
            string country = string.Empty;
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _country = dr.GetOrdinal(Resources.GetCountryResources.PARAM_CATCITCOUID);
                    if (dr.Read())
                    {
                        country = dr.GetString(_country);
                    }
                }
            }
            catch { }

            return country;
        }


        
    }
}
