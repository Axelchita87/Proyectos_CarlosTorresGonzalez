using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ErrorHandlers
{
    public class NoSelectedReturningFlightExceptionHandler : IErrorHandler<Exception>
    {
        #region Miembros de IErrorHandler<Exception>

        public IErrorHandler<Exception> Succesor { get; set; }

        public void Handle(Exception request)
        {
            if (request is NoReturningFlightSelectedException)
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

        #endregion

        #region Miembros de IErrorHandler<Exception>


        public IProcessContext<Exception> Context { get; set; }

        #endregion
    }
}
