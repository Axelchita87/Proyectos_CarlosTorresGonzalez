using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyCTS.Presentation.Reservations.Availability.InterJet.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class DeclinedCreditCardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeclinedCreditCardException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public DeclinedCreditCardException(string msg)
            : base(msg)
        {

        }

    }
}
