using System.Globalization;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Builder
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisPreviousPrincingDynamicControlBuilder : IDynamicBuilder<Control>
    {
        #region Miembros de IDynamicBuilder<Control>

        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        /// <value>
        /// The reservation.
        /// </value>
        public VolarisReservation Reservation { get; set; }
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Control Build()
        {
            var table = new TableLayoutPanel
                            {
                                AutoSize = true
                            };



            if (Reservation.Itinerary.Type == ItineraryType.RoundTrip)
            {
                var returningFlightControl = new ucVolarisPreviousFlightPricing();
                returningFlightControl.Title = "Regreso";
                returningFlightControl.SetFlight(Reservation.Itinerary.Return);
                table.Controls.Add(returningFlightControl, 0, 0);
            }

            var departureFlightControl = new ucVolarisPreviousFlightPricing();
            departureFlightControl.SetFlight(Reservation.Itinerary.Departure);
            table.Controls.Add(departureFlightControl, 0, 0);



            var pricingControl = new ucTotalPricing
                                     {
                                         Dock = DockStyle.Right,
                                         TotalToPay = Reservation.Itinerary.TotalPrice
                                     };
            table.Controls.Add(pricingControl);

            return table;
        }

        #endregion
    }
}
