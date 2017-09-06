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
    public class InterJetVisaPayment : InterJetPayment
    {
        /// <summary>
        /// Pays the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public override void Pay(InterJetTicket ticket)
        {
            //if (CostumerAccountInterJet.notSeatAssing)
            //this.InterJetServiceManager.MakeReservation(ticket);
            this.InterJetServiceManager.VisaMasterCardPayment(ticket, this.CreditCardsFields);
            ticket.PaymentForm = string.Format("CCVI{0}", this.CreditCardsFields.CreditCardNumber);
        }

    }
}
