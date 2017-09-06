using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Builder;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation.Builder;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation.ContextBuilder;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation
{
    public class VolarisBookingConfirmationPresenter : IBasePresenter<IVolarisBookingConfirmationView,VolarisBookingConfirmationRepository>
    {
        #region Miembros de IBasePresenter<IVolarisBookingConfirmationView,VolarisBookingConfirmationRepository>


        private IProcessContext<VolarisReservation> ContextSolver { get; set; }
        public IVolarisBookingConfirmationView View { get; set; }

        public VolarisBookingConfirmationRepository Repository { get; set; }

        public void InitializeView()
        {
           
        }
        public void CreateBookingConfirmation()
        {
            ContextSolver = new VolarisContextSolverBookingConfirmationWinForms
                                {
                                    OnCompleted = OnCompleted
                                };
            ContextSolver.Resolve(View.Reservation);
        }

        private void OnCompleted(object sender, EventArgs eventArgs)
        {
            if(OnComplete != null)
            {
                OnComplete(sender, eventArgs);
            }
        }


        public EventHandler OnComplete { get; set; }
        public void UpdateView(object modelObject)
        {
            
        }

        #endregion
    }
}
