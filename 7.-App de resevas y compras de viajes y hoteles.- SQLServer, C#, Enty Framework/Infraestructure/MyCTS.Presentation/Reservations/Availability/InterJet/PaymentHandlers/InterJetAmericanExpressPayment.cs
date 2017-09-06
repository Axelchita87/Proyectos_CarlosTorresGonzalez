using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAmericanExpressPayment : InterJetPayment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterJetAmericanExpressPayment"/> class.
        /// </summary>
        public InterJetAmericanExpressPayment()
        {
            this.ValidateOwnerAddressAndPostalCode = true;
        }



        /// <summary>
        /// Pays the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public override void Pay(InterJetTicket ticket)
        {
            //if (CostumerAccountInterJet.notSeatAssing)
            //this.InterJetServiceManager.MakeReservation(ticket);
            this.InterJetServiceManager.AmericanExpressPayment(ticket, this.CreditCardsFields);
            ticket.PaymentForm = string.Format("CCAX{0}", this.CreditCardsFields.CreditCardNumber);

        }

    }
}
