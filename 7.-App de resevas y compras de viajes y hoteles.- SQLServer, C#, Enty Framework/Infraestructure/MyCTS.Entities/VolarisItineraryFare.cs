using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisItineraryFare
    {

        public decimal TotalAmount { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal TotalBasePrice { get; set; }
        public decimal Iva { get; set; }
        public decimal Tua { get; set; }
        public decimal ExtraTaxes { get; set; }

        public decimal IVAMonto11 { get; set; }
        public decimal IVA11 { get; set; }

        public decimal IVAMonto16 { get; set; }
        public decimal IVA16 { get; set; }
    }
}
