using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentInformationCapture
{
    public interface IVolarisPaymentInformationCaptureView:  IBaseView
    {
        /// <summary>
        /// Gets or sets the credit card information.
        /// </summary>
        /// <value>
        /// The credit card information.
        /// </value>
        VolarisCreditCardInformation CreditCardInformation { get; set; }
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        VolarisCreditCardOwner Owner { get; set; }
    }
}
