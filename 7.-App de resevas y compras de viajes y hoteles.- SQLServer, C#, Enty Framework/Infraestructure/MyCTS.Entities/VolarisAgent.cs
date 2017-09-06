using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisAgent
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Queue { get; set; }
        public bool RecievedEmail { get; set; }
        public VolarisReservation Reservation { get; set; }
        public string Pcc { get; set; }
        public string Firm { get; set; }
        public string Email { get; set; }

    }
}
