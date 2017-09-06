using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Segment
{
    public interface VolarisPreviousSegmentPrincingView : IBaseView
    {
        void SetSegment(VolarisSegment segment);
        string FlightNumber { get; set; }
        string DateOfDeparture { get; set; }
        string DepartureStation { get; set; }
        string ArrivalStation { get; set; }
        string DepartureTime { get; set; }
        string ArrivalTime { get; set; }
        string DepartureStationToolTip { set; }
        string ArrivalStationToolTip { set; }

    }
}
