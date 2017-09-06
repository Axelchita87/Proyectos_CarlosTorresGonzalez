using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.EventArguments
{
   public class OnWebServiceCallCompletedEventArg : EventArgs
    {



       public bool Success { get; set; }
       public string ErrorMessage { get; set; }
    }
}
