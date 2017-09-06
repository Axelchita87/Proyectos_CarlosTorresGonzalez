using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume
{
    public class VolarisPreviousItineraryResumePresenter : IBasePresenter<IVolarisPreviousItineraryResumeView, VolarisPreviousItineraryResumeRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPreviousItineraryResumeView,VolarisPreviousItineraryResumeRepository>

        public IVolarisPreviousItineraryResumeView View { get; set; }

        public VolarisPreviousItineraryResumeRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }
        public void SetItinerary(VolarisItinerary itinerary)
        {

            if (itinerary != null)
            {
                View.DepartureFlight = itinerary.Departure;
                if (itinerary.Type == ItineraryType.RoundTrip)
                {
                    View.ReturningFlight = itinerary.Return;
                }


            }


        }

        #endregion
    }
}
