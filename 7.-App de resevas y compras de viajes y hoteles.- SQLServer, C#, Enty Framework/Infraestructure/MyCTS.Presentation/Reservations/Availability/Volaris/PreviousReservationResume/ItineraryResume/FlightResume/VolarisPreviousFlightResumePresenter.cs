using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume.FlightResume
{
    public class VolarisPreviousFlightResumePresenter : IBasePresenter<IVolarisPreviousFlightResumeView, VolarisPreviousFlightResumeRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPreviousFlightResumeView,VolarisPreviousFlightResumeRepository>

        public IVolarisPreviousFlightResumeView View { get; set; }

        public VolarisPreviousFlightResumeRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void SetFlight(MyCTS.Entities.VolarisFlight flight)
        {
            if (flight != null)
            {

                View.SegmentItinerary = flight.SegmentItineraryString;
                View.DateOfFlight = flight.DepartureTime.ToString("ddd dd,MMM yyyy", new CultureInfo("es-mx"));
                View.TypeOfFlight = "salida";
            }

        }

        public void UpdateView(object modelObject)
        {
        }

        #endregion
    }
}
