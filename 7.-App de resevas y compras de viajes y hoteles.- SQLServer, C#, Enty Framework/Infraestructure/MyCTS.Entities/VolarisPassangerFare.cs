using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisPassangerFare
    {

        public VolarisPassangerFare()
        {
            Iva = new VolarisPassangerTax();
            Tua = new VolarisPassangerTax();
            Extra = new VolarisPassangerTax();
            BasePrice = new VolarisPassangerBasePrice();
            Discount = new VolarisPassangerDiscount();
            PassangerType = VolarisPassangerType.None;
            MontoIVA11 = new VolarisPassangerTax();
            IVA11 = new VolarisPassangerTax();
            MontoIVA16 = new VolarisPassangerTax();
            IVA16 = new VolarisPassangerTax();

        }

        public decimal TotalTaxes { get; set; }

        public decimal Total { get; set; }

        public VolarisPassangerType PassangerType { get; set; }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the iva.
        /// </summary>
        /// <value>
        /// The iva.
        /// </value>
        public VolarisPassangerTax Iva { get; set; }

        /// <summary>
        /// Gets or sets the tua.
        /// </summary>
        /// <value>
        /// The tua.
        /// </value>
        public VolarisPassangerTax Tua { get; set; }

        /// <summary>
        /// Gets or sets the extra.
        /// </summary>
        /// <value>
        /// The extra.
        /// </value>
        public VolarisPassangerTax Extra { get; set; }
        /// <summary>
        /// Gets or sets the base price.
        /// </summary>
        /// <value>
        /// The base price.
        /// </value>
        public VolarisPassangerBasePrice BasePrice { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>
        /// The discount.
        /// </value>
        public VolarisPassangerDiscount Discount { get; set; }

        public VolarisPassangerTax MontoIVA11 {get; set; }
        public VolarisPassangerTax IVA11 { get; set; }
        public VolarisPassangerTax MontoIVA16 { get; set; }
        public VolarisPassangerTax IVA16 { get; set; }

    }
}
