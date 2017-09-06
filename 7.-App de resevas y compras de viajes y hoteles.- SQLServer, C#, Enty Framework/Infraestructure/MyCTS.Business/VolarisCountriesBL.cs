using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class VolarisCountriesBL
    {

        private VolarisCountriesDAL _dataAccess;
        private VolarisCountriesDAL DataAccess
        {
            get { return _dataAccess ?? (_dataAccess = new VolarisCountriesDAL()); }
        }
        /// <returns></returns>
        public List<VolarisCountry> GetCountries()
        {
            return DataAccess.GetCountries();
        }

        public static List<VolarisCountry> GetAllContries()
        {
            List<VolarisCountry> CountriesList = new List<VolarisCountry>();
            VolarisCountriesDAL objCountries = new VolarisCountriesDAL();
            try
            {
                CountriesList = objCountries.GetCountries(CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                CountriesList = objCountries.GetCountries(CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return CountriesList;
        }

    }
}
