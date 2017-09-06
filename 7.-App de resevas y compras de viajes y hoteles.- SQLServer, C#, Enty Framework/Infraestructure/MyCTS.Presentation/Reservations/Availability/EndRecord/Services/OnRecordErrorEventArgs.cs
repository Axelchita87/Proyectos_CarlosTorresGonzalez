using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.Services
{
    public class OnRecordErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
    }
}
