using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PurchaseResume
{
    public interface IVolarisPreviousPurchaseResumeView : IBaseView
    {
        void SetReservation(VolarisReservation reservation);
        decimal Price { get; set; }
        decimal Tax { get; set; }
        decimal TotalToPay { get; set; }

    }
}
