using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetPassangerPreviousPricing
    {

        /// <summary>
        /// Gets or sets the total pax.
        /// </summary>
        /// <value>
        /// The total pax.
        /// </value>
        public int TotalPax
        {
            get; set;
        
        }

        /// <summary>
        /// Gets or sets the base price.
        /// </summary>
        /// <value>
        /// The base price.
        /// </value>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>
        /// The taxes.
        /// </value>
        public decimal Taxes { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public decimal Total
        {
            
            get
            {
                
                decimal totalBasePrice = this.BasePrice*this.TotalPax;
                decimal totalTaxes = this.Taxes * this.TotalPax;
                decimal discount = this.Discount*this.TotalPax;
                return totalBasePrice + totalTaxes - discount;
            }
        }

        public decimal Discount { get; set; }
    }
}
