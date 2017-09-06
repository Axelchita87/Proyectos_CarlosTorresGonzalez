using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetHelper
    {

        public static InterJetTicket Ticket { get; set; }

        public static  void DestroyTicket()
        {
            Ticket = null;
        }
    }
}
