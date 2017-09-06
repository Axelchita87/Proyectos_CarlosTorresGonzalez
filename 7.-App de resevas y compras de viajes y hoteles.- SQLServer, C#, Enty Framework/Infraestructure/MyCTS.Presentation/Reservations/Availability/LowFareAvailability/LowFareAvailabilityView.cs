using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability
{
    public interface LowFareAvailabilityView : IBaseView
    {

        #region Miembros de IBaseView

        Flights Flights { get; set; }
        void GoToNextStep();
        void GoBack();
        bool IsValid { get; set; }
        AvailabilityRequest AvailabilityRequest { get; set; }
        Itinerary Itinerary { get; }

        #endregion
    }
}
