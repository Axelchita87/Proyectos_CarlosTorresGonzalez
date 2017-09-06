using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Exceptions
{
    public class DestinationNotFoundException : Exception
    {

        public DestinationNotFoundException(string msg)
            : base(msg)
        {

        }
    }
}
