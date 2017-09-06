using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class CityDAL
    {

        public City GetCity(string id)
        {
            try
            {
                return this.GetCity(id, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception exe)
            {
                try
                {
                    return this.GetCity(id, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch (Exception exception)
                {
                    new EventsManager.EventsManager(EventLogEntryType.Error, exception);
                }
            }
            return new City();
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        private City GetCity(string id, string connectionString)
        {

            Database database = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dbCommand = database.GetStoredProcCommand("GetCityName");
            database.AddInParameter(dbCommand, "@cityCode", DbType.String, id);

            var city = new City();
            using (IDataReader dataReader = database.ExecuteReader(dbCommand))
            {
                int idPosition = dataReader.GetOrdinal("CatCitId");
                int namePosition = dataReader.GetOrdinal("CatCitName");
                int countryCodePosition = dataReader.GetOrdinal("CatCitCouId");
                while (dataReader.Read())
                {
                    city.ID = dataReader.GetString(idPosition);
                    city.Name = dataReader.GetString(namePosition);
                    city.CountryCode = dataReader.GetString(countryCodePosition);

                }
            }

            return city;
        }

    }
}
