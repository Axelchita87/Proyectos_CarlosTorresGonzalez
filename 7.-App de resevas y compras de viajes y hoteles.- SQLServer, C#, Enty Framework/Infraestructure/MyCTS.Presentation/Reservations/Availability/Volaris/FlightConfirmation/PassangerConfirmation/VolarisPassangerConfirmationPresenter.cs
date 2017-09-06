using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PassangerConfirmation
{
    public class VolarisPassangerConfirmationPresenter : IBasePresenter<IVolarisPassangerConfirmationView, VolarisPassangerConfirmationRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPassangerConfirmationView,VolarisPassangerConfirmationRepository>

        public IVolarisPassangerConfirmationView View { get; set; }

        public VolarisPassangerConfirmationRepository Repository { get; set; }

        public void InitializeView()
        {

        }
        public void SetPassangers()
        {

        }
        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
