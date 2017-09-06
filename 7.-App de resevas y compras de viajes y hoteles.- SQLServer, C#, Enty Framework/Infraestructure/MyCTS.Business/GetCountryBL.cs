using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetCountryBL
    {
        public static string GetCountry(string countrySearch)
        {
            string country = string.Empty;
            GetCountryDAL objGetCountry = new GetCountryDAL();
            try
            {
                try
                {
                    country = objGetCountry.GetCountry(countrySearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    country = objGetCountry.GetCountry(countrySearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return country;

        }

        public static string GetCountryByCity(string countrySearch)
        {
            string country = string.Empty;
            GetCountryDAL objGetCountry = new GetCountryDAL();
            try
            {
                try
                {
                    country = objGetCountry.GetCountryByCity(countrySearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    country = objGetCountry.GetCountryByCity(countrySearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return country;

        }
    }
}
