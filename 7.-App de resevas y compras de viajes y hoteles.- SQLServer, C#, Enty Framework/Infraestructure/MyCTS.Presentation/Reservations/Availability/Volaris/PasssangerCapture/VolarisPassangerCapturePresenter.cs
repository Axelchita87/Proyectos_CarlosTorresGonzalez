using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.ContextSolver;
using MyCTS.Services.Contracts.Volaris.EventArguments;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture
{
    public class VolarisPassangerCapturePresenter : IBasePresenter<IVolarisPassangerCaptureView, VolarisPassangerCaptureRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPassangerCaptureView,VolarisPassangerCaptureRepository>

        public IProcessContext<VolarisReservation> Context { get; set; }
        public IVolarisPassangerCaptureView View { get; set; }

        public VolarisPassangerCaptureRepository Repository { get; set; }
        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }
        public EventHandler<OnReservationCompletedEventArg> OnReservationCreatedComplete { get; set; }
        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

        public void BuildDynamicControls()
        {
            Context.Resolve(View.Reservation);
        }


        public void CreateReservation(VolarisReservation reservation)
        {
            Context = new VolarisContextSolverReservationWinForms()
            {
                OnWebServiceCallStart = OnWebServiceCallStartDelegate,
                OnWebServiceCallCompleted = OnWebServiceCallCompleteDelegate,
                OnReservationCreatedComplete = OnReservationCreatedCompleteDelegate

            };


            Context.Resolve(reservation);
        }

        private void OnReservationCreatedCompleteDelegate(object sender, OnReservationCompletedEventArg e)
        {
            if(OnReservationCreatedComplete != null)
            {
                OnReservationCreatedComplete(sender, e);
            }
        }

        private void OnWebServiceCallCompleteDelegate(object sender, OnWebServiceCallCompletedEventArg e)
        {
            

            if(OnWebServiceCallCompleted != null)
            {
                OnWebServiceCallCompleted(sender, e);
            }
        }

        private void OnWebServiceCallStartDelegate(object sender, OnWebServiceCallStartEventArg e)
        {
            if(OnWebServiceCallStart != null)
            {
                OnWebServiceCallStart(sender, e);
            }
        }

        #endregion
    }
}
