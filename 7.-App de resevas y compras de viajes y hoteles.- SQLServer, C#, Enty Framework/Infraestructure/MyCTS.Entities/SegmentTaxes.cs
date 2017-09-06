using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class SegmentTaxes
    {
        public decimal IVAAdult { get; set; }
        public decimal TUAAdult { get; set; }
        public decimal DiscountAdult { get; set; }
        public decimal OtrosImpuestosAdult { get; set; }
        public decimal TarifaBaseAdult { get; set; }

        public decimal IVAChild { get; set; }
        public decimal TUAChild { get; set; }
        public decimal DiscountChild { get; set; }
        public decimal OtrosImpuestosChild { get; set; }
        public decimal TarifaBaseChild { get; set; }
    }
}
