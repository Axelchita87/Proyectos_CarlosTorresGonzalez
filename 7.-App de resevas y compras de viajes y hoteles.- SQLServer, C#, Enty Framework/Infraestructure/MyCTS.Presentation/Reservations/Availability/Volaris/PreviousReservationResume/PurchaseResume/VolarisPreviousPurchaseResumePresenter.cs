using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PurchaseResume
{
    public class VolarisPreviousPurchaseResumePresenter : IBasePresenter<IVolarisPreviousPurchaseResumeView, VolarisPreviousPurchaseResumeRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPreviousPurchaseResumeView,VolarisPreviousPurchaseResumeRepository>

        public IVolarisPreviousPurchaseResumeView View { get; set; }

        public VolarisPreviousPurchaseResumeRepository Repository { get; set; }

        public void InitializeView()
        {

        }
        public void SetReservation(VolarisReservation reservation)
        {

            View.Price = reservation.Itinerary.TotalBasePrice;
            View.Tax = reservation.Itinerary.TotalTaxes;
            View.TotalToPay = reservation.Itinerary.TotalPrice;


        }


        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
