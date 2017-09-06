using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ErrorHandlers
{
    public class VolarisDestinationNotFoundExceptionHandler :  IErrorHandler<Exception>
    {
        public IErrorHandler<Exception> Succesor { get; set; }

        public void Handle(Exception request)
        {
            
        }

        public IProcessContext<Exception> Context { get; set; }
    }
}
