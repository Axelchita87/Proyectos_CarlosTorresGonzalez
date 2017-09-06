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
    public class InterJetPreviousItineraryControlHandler : InterJetUserControlHandler
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
        /// <param name="theFlight">The flight.</param>
        public void SetFlight(InterJetFlight theFlight, int seg)
        {
            Label itineraryString = this.GetLabelByName("itineraryString");
            Label departureLabel = this.GetLabelByName("departureTime");
            Label arrivalLabel = this.GetLabelByName("arrivalTime");
            Label flightNumber = this.GetLabelByName("flightNumberLabel");

            if (theFlight.FlightNumber != null)
            {
                itineraryString.Text = theFlight.IntineraryString;
                departureLabel.Text = string.Format("{0} hrs", theFlight.DepartureTime.ToString("HH:mm"));
                arrivalLabel.Text = string.Format("{0} hrs", theFlight.ArrivalDateTime.ToString("HH:mm"));
                flightNumber.Text = theFlight.FlightNumber;
            }
            else
            {
               itineraryString.Text = theFlight.Segments.GetAll()[seg].DepartureStation + "-" + theFlight.Segments.GetAll()[seg].ArrivalStation;
               departureLabel.Text = string.Format("{0} hrs", theFlight.Segments.GetAll()[seg].DepartureTime.ToString("HH:mm"));
               arrivalLabel.Text = string.Format("{0} hrs", theFlight.Segments.GetAll()[seg].ArrivalTime.ToString("HH:mm"));
               flightNumber.Text = theFlight.Segments.GetAll()[seg].ID;
            }
        }
    }
}
