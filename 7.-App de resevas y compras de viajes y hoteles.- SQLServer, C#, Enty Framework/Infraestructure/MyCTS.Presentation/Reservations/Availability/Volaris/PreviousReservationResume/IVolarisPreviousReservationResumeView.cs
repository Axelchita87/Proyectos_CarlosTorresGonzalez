using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume
{
    public interface IVolarisPreviousReservationResumeView : IBaseView
    {
        void SetReservation(VolarisReservation reservation);
        void SetItinerary(VolarisItinerary itinerary);
        void SetPassanger(VolarisPassangers passangers);
        void SetReservationPrice(VolarisReservation reservation);

    }
}
