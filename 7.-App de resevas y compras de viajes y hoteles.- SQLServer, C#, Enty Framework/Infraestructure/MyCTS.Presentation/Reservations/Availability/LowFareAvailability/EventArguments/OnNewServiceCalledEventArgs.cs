using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments
{
    public class OnNewServiceCalledEventArgs : EventArgs
    {
        public string MessageToSend { get; set; }
        public string Company { get; set; }
    }
}
