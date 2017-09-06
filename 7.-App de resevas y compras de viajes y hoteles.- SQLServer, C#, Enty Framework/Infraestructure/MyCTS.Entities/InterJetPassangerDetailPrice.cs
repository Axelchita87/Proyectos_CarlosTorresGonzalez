using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetPassangerDetailPrice
    {

        public decimal BasePrice
        {
            get;
            set;
        }
        public InterJetFlight Flight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IVA.
        /// </summary>
        /// <value>
        /// The IVA.
        /// </value>
        public decimal IVA
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the TUA.
        /// </summary>
        /// <value>
        /// The TUA.
        /// </value>
        public decimal TUA
        {
            get;
            set;
        }

        public decimal Discount
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets the extra taxes.
        /// </summary>
        /// <value>
        /// The extra taxes.
        ///   </value>

        public decimal ExtraTaxes
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the extra charge for infant.
        /// </summary>
        /// <value>
        /// The extra charge for infant.
        /// </value>
        public decimal ExtraChargeForInfant
        {
            
            get; 
            set;
        }


        /// <summary>
        /// Gets the total taxes.
        /// </summary>
        public decimal TotalTaxes
        {
            get { return this.TUA + this.IVA + TotalExtraTaxes; }
        }

        /// <summary>
        /// Gets the tota extra taxes.
        /// </summary>
        public decimal TotalExtraTaxes
        {
            get { return this.ExtraTaxes + ExtraChargeForInfant; }
        }



        private decimal _total;
        public decimal Total
        {
            get
            {
                this._total = this.BasePrice + this.TotalTaxes - this.Discount;
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
    }
}
