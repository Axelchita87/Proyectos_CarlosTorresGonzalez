using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation
{
    public interface IVolarisBookingConfirmationView : IBaseView
    {

        VolarisReservation Reservation { get; }
    }
}
