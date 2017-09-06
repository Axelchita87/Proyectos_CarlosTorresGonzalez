using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class NoSelectedFlightException : Exception
    {
        public NoSelectedFlightException(string message)
            : base(message)
        {
            ErrorCode = ErrorCode.NoSelectedFlight;
        }


        public ErrorCode ErrorCode { get; set; }
    }
}
