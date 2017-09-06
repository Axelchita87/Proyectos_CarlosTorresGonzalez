using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.Services
{
    public class OnActionStartEventArg : EventArgs
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
