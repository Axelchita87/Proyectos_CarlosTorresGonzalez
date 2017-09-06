using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Segment
{
    public class VolarisPreviousSegmentPricingRepository : IBaseRepository
    {
        #region Miembros de IBaseRepository

        public void Initialize()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private CityBL _cityService;
        /// <summary>
        /// Gets the city service.
        /// </summary>
        private CityBL CityService
        {
            get
            {
                return _cityService ?? (_cityService = new CityBL());
            }
        }
        /// <summary>
        /// Gets the full name of the city.
        /// </summary>
        /// <param name="cityCode">The city code.</param>
        /// <returns></returns>
        public string GetCityFullName(string cityCode)
        {
            var city = CityService.GetCity(cityCode);
            return city.Name;

        }

        #endregion
    }
}
