using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class VolarisCountriesDAL
    {

        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        public List<VolarisCountry> GetCountries(string connectionString)
        {
            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetVolarisCountries");
            var countries = new List<VolarisCountry>();
            using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
            {

                while (dataReader.Read())
                {

                    int idPosition = dataReader.GetOrdinal("CatCouId");
                    int namePosition = dataReader.GetOrdinal("CatCouName");
                    var country = new VolarisCountry();
                    country.Id = dataReader.GetString(idPosition);
                    country.Name = dataReader.GetString(namePosition);
                    countries.Add(country);

                }

            }
            return countries;
        }


        public List<VolarisCountry> GetCountries()
        {

            try
            {
                return GetCountries(CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                try
                {
                    return GetCountries(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch (Exception exe)
                {

                }
            }

            return new List<VolarisCountry>();
        }

        

    }
}