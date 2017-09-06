using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.ReservationPreviewExpander
{
    public class VolarisReservationExpanderPresenter : IBasePresenter<VolarisReservationExpanderView, VolarisReservationExpanderRepository>
    {
        #region Miembros de IBasePresenter<VolarisReservationExpanderView,VolarisReservationExpanderRepository>

        public VolarisReservationExpanderView View { get; set; }

        public VolarisReservationExpanderRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
