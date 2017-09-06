using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.EventArguments
{
    public class AssignChargeOfServiceEventArgs : EventArgs
    {
        public AssignChargeOfServiceEventArgs()
        {
            FormOfPayment = new FormOfPayment();
        }

        public IPassanger Passanger
        {
            get;
            set;
        }

        public FormOfPayment FormOfPayment { get; set; }
        public decimal Amount { get; set; }

        public bool IsChargeFromCreditCard { get; set; }
        public bool IsChargeFromCash { get; set; }

        public CreditCardInfo DatosTarjeta { get; set; } 
    }
}
