using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class LogTickets
    {
        public string TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public string PNRAirline { get; set; }
        public string PNRSabre { get; set; }
    }
}
