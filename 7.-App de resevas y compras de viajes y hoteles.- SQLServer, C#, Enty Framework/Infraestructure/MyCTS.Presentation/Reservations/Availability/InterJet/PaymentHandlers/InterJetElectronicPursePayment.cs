using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    public class InterJetElectronicPursePayment : InterJetPayment
    {

        public override void Pay(InterJetTicket ticket)
        {
            //if (CostumerAccountInterJet.notSeatAssing)
            //this.InterJetServiceManager.MakeReservation(ticket);
            this.InterJetServiceManager.ElectronicPursePayment(ticket, this.CreditCardsFields);
            ticket.PaymentForm = string.Format("CCGA{0}", this.CreditCardsFields.CreditCardNumber);
        }
    }
}
