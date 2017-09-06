using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.ContextSolver;
using MyCTS.Services.Contracts.Volaris.EventArguments;


namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisPaymentFormPresenter : IBasePresenter<IVolarisPaymentFormView, VolarisPaymentFormRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPaymentFormView,VolarisPaymentFormRepository>

        public IVolarisPaymentFormView View { get; set; }

        public VolarisPaymentFormRepository Repository { get; set; }

        private IProcessContext<VolarisReservation> Context { get; set; }


        public void InitializeView()
        {

        }

        public void CreateReservation(VolarisReservation reservation)
        {

            Context = new VolarisContextSolverReservationWinForms()
                          {
                              OnWebServiceCallStart = OnWebServiceCallStart,
                              OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                              OnReservationCreatedCompleted = OnReservationCreatedCompleted

                          };


            Context.Resolve(reservation);
        }

        public void MakePayment(VolarisReservation reservation)
        {
            Context = null;
            Context = new VolarisContextSolverReservationPaymentWinForms()
                          {
                              OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                              OnWebServiceCallStart = OnWebServiceCallStart,
                              OnPaymentCompleted = OnPaymentCompleted
                          };
            Context.Resolve(reservation);
        }

        private void OnPaymentCompleted(object sender, EventArgs e)
        {
            if (OnPaymentComplete != null)
            {
                OnPaymentComplete(sender, e);
            }
        }

        private void OnReservationCreatedCompleted(object sender, EventArgs e)
        {
            if (OnReservationCompleted != null)
            {
                OnReservationCompleted(sender, e);
            }
        }

        /// <summary>
        /// Called when [web service call completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallCompleted(object sender, OnWebServiceCallCompletedEventArg e)
        {
            if (OnWebServiceCallCompletedDelegate != null)
            {

                OnWebServiceCallCompletedDelegate(sender, e);
            }
        }

        /// <summary>
        /// Called when [web service call start].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallStart(object sender, OnWebServiceCallStartEventArg e)
        {
            if (OnWebServiceCallStartDelegate != null)
            {
                OnWebServiceCallStartDelegate(sender, e);
            }
        }

        public void UpdateView(object modelObject)
        {

        }

        /// <summary>
        /// Gets or sets the on web service call start delegate.
        /// </summary>
        /// <value>
        /// The on web service call start delegate.
        /// </value>
        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStartDelegate { get; set; }
        /// <summary>
        /// Gets or sets the on web service call completed delegate.
        /// </summary>
        /// <value>
        /// The on web service call completed delegate.
        /// </value>
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompletedDelegate { get; set; }

        public EventHandler OnReservationCompleted { get; set; }

        public EventHandler OnPaymentComplete { get; set; }
        #endregion
    }
}
