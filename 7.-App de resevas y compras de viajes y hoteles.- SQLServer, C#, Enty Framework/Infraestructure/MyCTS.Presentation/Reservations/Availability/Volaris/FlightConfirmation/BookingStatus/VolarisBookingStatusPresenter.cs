using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingStatus
{
    public class VolarisBookingStatusPresenter : IBasePresenter<IVolarisBookingStatusView, VolarisBookingStatusRepository>
    {
        

        public IVolarisBookingStatusView View { get; set; }

        public VolarisBookingStatusRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }


        public void SetBookingStatus()
        {
            if(View != null && View.Reservation != null)
            {

                View.RecordLocator = View.Reservation.RecordLocator.Record.ToUpper();
                View.PurchaseDate = View.Reservation.RecordLocator.Created;
                View.Status = View.Reservation.Status;

            }
        }
    }
}
