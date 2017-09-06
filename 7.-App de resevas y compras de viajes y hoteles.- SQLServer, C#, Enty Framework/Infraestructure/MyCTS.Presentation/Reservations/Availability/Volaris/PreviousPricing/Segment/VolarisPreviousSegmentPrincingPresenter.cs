using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Segment
{
    public class VolarisPreviousSegmentPrincingPresenter : IBasePresenter<VolarisPreviousSegmentPrincingView, VolarisPreviousSegmentPricingRepository>
    {
        #region Miembros de IBasePresenter<VolarisPreviousSegmentPrincingView,VolarisPreviousSegmentPricingRepository>

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public VolarisPreviousSegmentPrincingView View { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public VolarisPreviousSegmentPricingRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        /// <summary>
        /// Updates the view.
        /// </summary>
        /// <param name="modelObject">The model object.</param>
        public void UpdateView(object modelObject)
        {

        }


        public void SetSegment(VolarisSegment segment)
        {
            SetFlightNumber(segment);
            SetItinerary(segment);
            SetDepartureDate(segment);
            SetDepartureTime(segment);
            SetArrivalTime(segment);

        }

        /// <summary>
        /// Sets the flight number.
        /// </summary>
        /// <param name="segment">The segment.</param>
        private void SetFlightNumber(VolarisSegment segment)
        {
            const string volarisCode = "Y4";
            View.FlightNumber = string.Format("{0} {1}", volarisCode, segment.ID);

        }

        /// <summary>
        /// Sets the itinerary.
        /// </summary>
        /// <param name="segment">The segment.</param>
        private void SetItinerary(VolarisSegment segment)
        {
            var departureItinerarySegment = GetItineraryString(segment.DepartureStation);
            View.DepartureStationToolTip = departureItinerarySegment;
            View.DepartureStation = segment.DepartureStation;
            var arrivalItinerarySegment = GetItineraryString(segment.ArrivalStation);
            View.ArrivalStationToolTip = arrivalItinerarySegment;
            View.ArrivalStation = segment.ArrivalStation;
        }

        /// <summary>
        /// Gets the itinerary string.
        /// </summary>
        /// <param name="station">The station.</param>
        /// <returns></returns>
        private string GetItineraryString(string station)
        {

            return string.Format("{0}({1})", Repository.GetCityFullName(station), station);
        }

        /// <summary>
        /// Sets the departure date.
        /// </summary>
        /// <param name="segment">The segment.</param>
        private void SetDepartureDate(VolarisSegment segment)
        {
            View.DateOfDeparture = segment.DepartureTime.ToString("dddd dd MMMM,yyyy", new CultureInfo("es-MX")).ToUpper();
        }
        /// <summary>
        /// Sets the departure time.
        /// </summary>
        /// <param name="segment">The segment.</param>
        private void SetDepartureTime(VolarisSegment segment)
        {
            string departure = segment.DepartureTime.ToString("HH:mm", new CultureInfo("es-MX"));
            View.DepartureTime = string.Format("{0} hrs", departure);
        }

        /// <summary>
        /// Sets the arrival time.
        /// </summary>
        /// <param name="segment">The segment.</param>
        private void SetArrivalTime(VolarisSegment segment)
        {
            string arrival = segment.ArrivalTime.ToString("HH:mm", new CultureInfo("es-MX"));
            View.ArrivalTime = string.Format("{0} hrs", arrival);
        }

        #endregion
    }
}
