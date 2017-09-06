using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments
{
    public class OnWebServiceErrorEventArgs : EventArgs
    {

        public Exception Error { get; set; }
    }
}
