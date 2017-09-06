using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.Contracts;
using MyCTS.Entities;
using System.Collections;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    public abstract class InterJetPayment
    {
        /// <summary>
        /// 
        /// </summary>
        private InterJetServiceManager _interJetServiceManager;

        /// <summary>
        /// Gets the inter jet service manager.
        /// </summary>
        public InterJetServiceManager InterJetServiceManager
        {
            get
            {
                return this._interJetServiceManager ?? (this._interJetServiceManager = new InterJetServiceManager());
            }
        }

        /// <summary>
        /// Gets or sets the credit cards fields.
        /// </summary>
        /// <value>
        /// The credit cards fields.
        /// </value>
        public InterJetCreditCardFields CreditCardsFields
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [validate owner address and postal code].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [validate owner address and postal code]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidateOwnerAddressAndPostalCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        /// <value>
        /// The session.
        /// </value>
        public Hashtable Session
        {
            get;
            set;
        }

        /// <summary>
        /// Pays the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public abstract void Pay(InterJetTicket ticket);
        


    }
}
