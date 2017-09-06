using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingStatus
{
    public interface IVolarisBookingStatusView : IBaseView
    {

        VolarisReservation Reservation { get; set; }

        string RecordLocator { get; set; }
        VolarisReservationStatus Status { get; set; }
        DateTime PurchaseDate { get; set; }
    }
}
