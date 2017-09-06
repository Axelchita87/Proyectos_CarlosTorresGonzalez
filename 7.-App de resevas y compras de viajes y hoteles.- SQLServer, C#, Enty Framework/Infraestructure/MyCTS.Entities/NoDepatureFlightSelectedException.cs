using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class NoDepatureFlightSelectedException : Exception
    {
        public NoDepatureFlightSelectedException(string message)
            : base(message)
        { }

    }
}
