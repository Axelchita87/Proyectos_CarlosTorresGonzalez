using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PaymentInformation
{
    public interface IVolarisPaymentInformationView : IBaseView
    {

        VolarisReservation Reservation { get; set; }

        string FullProtectedCard { get; set; }
        VolarisCreditCardType CardType { get; set; }
        decimal SubTotal { get; set; }
        decimal Taxes { get; set; }
        decimal Total { get; set; }


    }
}
