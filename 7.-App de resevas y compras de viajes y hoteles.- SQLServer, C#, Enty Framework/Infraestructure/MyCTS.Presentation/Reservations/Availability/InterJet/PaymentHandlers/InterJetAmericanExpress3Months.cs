using System;
using System.Collections.Generic;
using System.Linq;
using MyCTS.Entities;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAmericanExpress3Months : InterJetPayment
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InterJetAmericanExpress3Months"/> class.
        /// </summary>
        public InterJetAmericanExpress3Months()
        {

            this.ValidateOwnerAddressAndPostalCode = true;
        }
        /// <summary>
        /// Pays the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public override void Pay(InterJetTicket ticket)
        {
            //if(CostumerAccountInterJet.notSeatAssing)
            //this.InterJetServiceManager.MakeReservation(ticket);
            this.InterJetServiceManager.AmericanExpress3Payment(ticket, this.CreditCardsFields);
            ticket.PaymentForm = string.Format("CCA3{0}", this.CreditCardsFields.CreditCardNumber);
        }
    }
}
