using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ContextSolvers
{
    public class NoSelectedReturningFlightWinFormProcessContext : IProcessContext<Exception>
    {
        #region Miembros de IProcessContext<Exception>

        public void Resolve(Exception objectContext)
        {
            string messageToShow = objectContext.Message;
            MessageBox.Show(messageToShow, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion
    }
}
