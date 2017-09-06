using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class FormOfPayment
    {
        public FormOfPayment()
        {
            Type = GenericFormOfPayment.None;
        }
        public string CrediCardNumber { get; set; }

        public string Name { get; set; }
        public bool IsFromCts { get; set; }
        public bool IsFromTheClient { get; set; }
        public GenericFormOfPayment Type { get; set; }

        public DateTime Expiration { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
