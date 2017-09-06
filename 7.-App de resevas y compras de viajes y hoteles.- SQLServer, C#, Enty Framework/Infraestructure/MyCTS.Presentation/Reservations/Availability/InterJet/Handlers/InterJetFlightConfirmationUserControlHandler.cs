using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFlightConfirmationUserControlHandler : InterJetUserControlHandler
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(InterJetFlight flight)
        {
            Label departureLabel = this.GetLabelByName("departureStationLabel");
            departureLabel.Text = flight.DepartureStation;

            Label arrivalLabel = this.GetLabelByName("arrivalStationLabel");
            arrivalLabel.Text = flight.ArrivalStation;

            Label segmentLabel = this.GetLabelByName("segmentLabel");
            segmentLabel.Text = flight.IntineraryString;

            Label flightNumberLabel = this.GetLabelByName("flightNumberLabel");
            flightNumberLabel.Text = flight.FlightNumber;

            Label dateTimeLabel = this.GetLabelByName("dateTimeLabel");
            dateTimeLabel.Text = flight.DepartureTime.ToString("dd/MM/yyyy");

            Label fligthTimeLabel = this.GetLabelByName("fligthTimeLabel");
            fligthTimeLabel.Text = string.Format("{0}-{1}", flight.Departure, flight.ArrivalDateTime.ToString("hh:mm"));
        }

    }
}
