using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.AvailabilitySearchPanel
{
    public interface ILowFareAvailabilitySearchView : IBaseView
    {

        AvailabilityRequest Request { get; set; }
    }
}
