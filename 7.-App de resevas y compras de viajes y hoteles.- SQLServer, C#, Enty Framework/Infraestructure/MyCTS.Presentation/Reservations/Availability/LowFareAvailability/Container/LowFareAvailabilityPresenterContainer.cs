using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Container
{
    /// <summary>
    /// 
    /// </summary>
    public class LowFareAvailabilityPresenterContainer : IBasePresenter<ILowFareAvailabilityViewContainer, LowFareAvailabilityRepositoryContainer>
    {
        #region Miembros de IBasePresenter<LowFareAvailabilityViewContainer,LowFareAvailabilityRepositoryContainer>

        public LowFareAvailabilityPresenterContainer()
        {
        }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public ILowFareAvailabilityViewContainer View { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public LowFareAvailabilityRepositoryContainer Repository { get; set; }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        public void InitializeView()
        {

            if (View != null && View.AvailabilityRequest != null)
            {
                View.Itinerary = string.Format("{0}-{1}", View.AvailabilityRequest.DepartureStation,
                                               View.AvailabilityRequest.ArrivalStation);
                View.Date = View.Date.ToString(new CultureInfo("es-MX"));


            }
        }

        /// <summary>
        /// Updates the view.
        /// </summary>
        /// <param name="modelObject">The model object.</param>
        public void UpdateView(object modelObject)
        {

        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            InitializeView();

        }

        private List<IFlight> _flights = new List<IFlight>();
        /// <summary>
        /// Sets the fligths.
        /// </summary>
        /// <param name="flights">The flights.</param>
        public void SetFligths(List<IFlight> flights)
        {

            _flights = flights;

        }

        public void SetFlights()
        {
            View.Fligths = _flights;

        }

        public EventHandler<OnDynamicControlsBuiltEventArgs> OnDynamicControlsBuilt { get; set; }

        #endregion
    }
}
