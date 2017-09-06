using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class PaxFare
    {
        public string PaxType { get; set; }
        public List<BookingServiceCharge> ServiceCharges { get; set; }

        public PaxFare()
        {
            ServiceCharges = new List<BookingServiceCharge>();
        }

        public PaxFare(List<BookingServiceCharge> serviceCharges)
        {
            ServiceCharges = serviceCharges;
        }
    }
}
