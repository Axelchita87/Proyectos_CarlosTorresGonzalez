using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume.FlightResume
{
    public interface IVolarisPreviousFlightResumeView : IBaseView
    {
        void SetFlight(VolarisFlight flight);
        string SegmentItinerary { get; set; }
        string DateOfFlight { get; set; }
        string TypeOfFlight { get; set; }
    }
}
