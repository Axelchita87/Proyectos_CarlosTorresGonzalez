using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class AdditionalAccountingLine
    {
        public decimal Amount { get; set; }
        public decimal Iva { get; set; }
        public string Description { get; set; }
        public int jorney { get; set; } 
    }
}
