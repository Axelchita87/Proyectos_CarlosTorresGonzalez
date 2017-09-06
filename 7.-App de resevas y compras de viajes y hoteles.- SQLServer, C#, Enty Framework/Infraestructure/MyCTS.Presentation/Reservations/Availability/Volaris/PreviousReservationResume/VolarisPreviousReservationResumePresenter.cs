using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume
{
    public class VolarisPreviousReservationResumePresenter : IBasePresenter<IVolarisPreviousReservationResumeView, VolarisPreviousReservationResumeRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPreviousReservationResumeView,VolarisPreviousReservationResumeRepository>

        public IVolarisPreviousReservationResumeView View { get; set; }

        public VolarisPreviousReservationResumeRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }
        public void SetReservation(VolarisReservation reservation)
        {
            View.SetItinerary(reservation.Itinerary);
            View.SetPassanger(reservation.Passangers);
            View.SetReservationPrice(reservation);

        }
        #endregion
    }
}
