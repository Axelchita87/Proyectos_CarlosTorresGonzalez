using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing
{
    public interface VolarisPreviousPrincingView : IBaseView
    {
        VolarisReservation Reservation { get; }

        void GoToNextStep();
        void GoBack();


    }
}
