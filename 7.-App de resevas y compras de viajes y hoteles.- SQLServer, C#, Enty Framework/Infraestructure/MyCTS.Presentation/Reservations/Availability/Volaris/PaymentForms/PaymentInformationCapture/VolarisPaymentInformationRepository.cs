using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentInformationCapture
{
    public class VolarisPaymentInformationRepository : IBaseRepository
    {
        #region Miembros de IBaseRepository

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private VolarisCountriesBL _countryService;
        /// <summary>
        /// Gets the country service.
        /// </summary>
        private VolarisCountriesBL CountryService
        {
            get { return _countryService ?? (_countryService = new VolarisCountriesBL()); }
        }

        public List<VolarisCountry> GetCountries()
        {

            return CountryService.GetCountries();
        }


        private VolarisStateBL _stateService;
        /// <summary>
        /// Gets the state service.
        /// </summary>
        private VolarisStateBL StateService
        {
            get
            {
                return _stateService ?? (_stateService = new VolarisStateBL());
            }
        }


        /// <summary>
        /// Gets the state by contry.
        /// </summary>
        /// <param name="countryId">The country id.</param>
        /// <returns></returns>
        public List<VolarisState> GetStateByContry(string countryId)
        {
            return StateService.GetStateByContry(countryId);
        }

        #endregion
    }
}
