using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetUniversalAirTravelPlanPayment : InterJetPayment
    {
        /// <summary>
        /// Pays the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public override void Pay(MyCTS.Entities.InterJetTicket ticket)
        {
            //if (CostumerAccountInterJet.notSeatAssing)
            //this.InterJetServiceManager.MakeReservation(ticket);
            this.CreditCardsFields.SecurityCodeNumber = "111";
            this.InterJetServiceManager.UniversalAirTravelPlanPayment(ticket, this.CreditCardsFields);
            ticket.PaymentForm = string.Format("CCTP{0}", this.CreditCardsFields.CreditCardNumber);

        }
    }
}
