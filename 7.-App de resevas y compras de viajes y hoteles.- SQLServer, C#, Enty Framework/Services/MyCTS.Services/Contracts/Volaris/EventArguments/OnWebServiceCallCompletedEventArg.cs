using System;

namespace MyCTS.Services.Contracts.Volaris.EventArguments
{
   public class OnWebServiceCallCompletedEventArg : EventArgs
    {



       public bool Success { get; set; }
       public string ErrorMessage { get; set; }
    }
}
