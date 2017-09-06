using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Flight
{
    public interface VolarisPreviousFlightPrincingView : IBaseView
    {

        void SetFlight(VolarisFlight flight);
        bool ShowOnlySegments { get; set; }

    }
}
