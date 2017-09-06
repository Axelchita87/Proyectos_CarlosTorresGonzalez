using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ErrorHandlers
{
    public class NoSelectedDepartureFlightExceptionHandler : IErrorHandler<Exception>
    {
        #region Miembros de IErrorHandler<Exception>

        public IErrorHandler<Exception> Succesor { get; set; }

        public void Handle(Exception request)
        {
            if (request is NoDepatureFlightSelectedException)
            {
                Context.Resolve(request);

            }
            else
            {
                if (Succesor != null)
                {
                    Succesor.Handle(request);
                }
            }
        }

        public IProcessContext<Exception> Context { get; set; }

        #endregion
    }
}
