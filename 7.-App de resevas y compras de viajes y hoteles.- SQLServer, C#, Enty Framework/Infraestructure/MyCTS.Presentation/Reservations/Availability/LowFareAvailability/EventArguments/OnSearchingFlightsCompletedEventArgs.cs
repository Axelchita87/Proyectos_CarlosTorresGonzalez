using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments
{
    public class OnSearchingFlightsCompletedEventArgs : EventArgs
    {

        public Flights Flights { get; set; }
    }
}
