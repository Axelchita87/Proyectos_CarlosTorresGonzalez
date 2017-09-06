using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public partial class BookingServiceCharge
    {
        public string ChargeCode { get; set; }

        public string TicketCode { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }

        public string ChargeDetail { get; set; }

        public string ForeignCurrencyCode { get; set; }

        public decimal ForeignAmount { get; set; }

        public ChargeType ChargeType { get; set; }

        public CollectType CollectType { get; set; }
    }
}
