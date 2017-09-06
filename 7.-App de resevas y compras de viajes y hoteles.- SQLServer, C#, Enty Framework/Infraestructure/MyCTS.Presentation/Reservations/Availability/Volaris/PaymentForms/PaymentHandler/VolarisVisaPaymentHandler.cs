using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentHandler
{
    public class VolarisVisaPaymentHandler : VolarisPaymentHandler
    {
        public override void Commit(VolarisReservation reservation)
        {
            ServiceManager.VisaPayment(reservation);
        }
    }
}
