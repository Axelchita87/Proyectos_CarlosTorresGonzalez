using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisPayment
    {
        public VolarisPayment()
        {
            CreditCardInformation = new VolarisCreditCardInformation();
            Owner = new VolarisCreditCardOwner();
            Status = VolarisPaymentStatus.Unkown;
            HistoricalRemarks = new List<string>();
            ManualApprovalCode = "";
        }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public VolarisPaymentStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the credit card information.
        /// </summary>
        /// <value>
        /// The credit card information.
        /// </value>
        public VolarisCreditCardInformation CreditCardInformation { get; set; }
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public VolarisCreditCardOwner Owner { get; set; }

        public List<string> HistoricalRemarks { get; set; }

        public string ManualApprovalCode { get; set; }

        public bool HasBeenApproved { get; set; }

    }
}
