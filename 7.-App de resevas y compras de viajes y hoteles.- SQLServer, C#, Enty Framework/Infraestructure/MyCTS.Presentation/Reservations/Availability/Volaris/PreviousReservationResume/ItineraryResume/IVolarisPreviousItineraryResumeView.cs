using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume
{
    public interface IVolarisPreviousItineraryResumeView : IBaseView
    {
        /// <summary>
        /// Sets the itinerary.
        /// </summary>
        /// <param name="itinerary">The itinerary.</param>
        void SetItinerary(VolarisItinerary itinerary);

        VolarisFlight DepartureFlight { get; set; }
        VolarisFlight ReturningFlight { get; set; }

    }
}
