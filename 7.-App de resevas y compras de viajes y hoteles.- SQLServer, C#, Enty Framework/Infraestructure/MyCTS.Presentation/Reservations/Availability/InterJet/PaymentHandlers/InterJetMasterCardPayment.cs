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
    public class InterJetMasterCardPayment : InterJetPayment
    {

        public InterJetMasterCardPayment()
        {
            this.ValidateOwnerAddressAndPostalCode = false;
        }
        /// <summary>
        /// Pays the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public override void Pay(InterJetTicket ticket)
        {
            //if (CostumerAccountInterJet.notSeatAssing)
            //this.InterJetServiceManager.MakeReservation(ticket);
            this.InterJetServiceManager.MasterCardPayment(ticket, this.CreditCardsFields);
            ticket.PaymentForm = string.Format("CCAC{0}", this.CreditCardsFields.CreditCardNumber);
        }
    }
}
