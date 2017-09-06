using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PaymentInformation
{
    public class VolarisPaymentInformationPresenter : IBasePresenter<IVolarisPaymentInformationView, VolarisPaymentInformationRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPaymentInformationView,VolarisPaymentInformationRepository>

        public IVolarisPaymentInformationView View { get; set; }

        public VolarisPaymentInformationRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        private VolarisReservation _reservation { get; set; }

        public void SetReservation(VolarisReservation reservation)
        {
            _reservation = reservation;
        }

        public VolarisReservation GetReservation()
        {

            return _reservation;
        }






        public void UpdateView(object modelObject)
        {

        }

        #endregion

        public void SetValues()
        {
            if(_reservation != null)
            {
                var creditCardInformation = _reservation.Payment.CreditCardInformation;

                View.FullProtectedCard = creditCardInformation.FullProtectedCard;
                View.CardType = creditCardInformation.Type;
                var itinerary = _reservation.Itinerary;

                View.SubTotal = itinerary.TotalBasePrice;
                View.Taxes = itinerary.TotalTaxes;
                View.Total = itinerary.TotalPrice;


            }
        }
    }
}
