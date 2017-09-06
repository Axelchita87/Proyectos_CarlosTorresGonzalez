using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentHandler
{
    public class VolarisMasterCardPaymentHandler : VolarisPaymentHandler
    {
        public override void Commit(VolarisReservation reservation)
        {
            ServiceManager.MasterCardPayment(reservation);
        }
    }
}
