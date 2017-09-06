using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.Services
{
    public class OnRecordCompletedEventArgs : EventArgs
    {

        public string Message { get; set; }
        public bool Success { get; set; }
        public string SabrePnr { get; set; }
        public bool IsInvoiced { get; set; }
    }
}
