using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using System.ComponentModel;
using MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentHandler;
using MyCTS.Services.Contracts.Volaris.EventArguments;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.ContextSolver
{
    public class VolarisContextSolverReservationPaymentWinForms : IProcessContext<VolarisReservation>
    {
        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }
        public EventHandler OnPaymentCompleted { get; set; }

        #region Miembros de IProcessContext<VolarisReservation>

        public void Resolve(VolarisReservation reservation)
        {

            StartPaymentWorker(reservation);

        }

        private BackgroundWorker _paymentWorker;

        /// <summary>
        /// Starts the payment worker.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        private void StartPaymentWorker(VolarisReservation reservation)
        {
            _paymentWorker = new BackgroundWorker()
                                 {
                                     WorkerReportsProgress = true,
                                     WorkerSupportsCancellation = true
                                 };

            _paymentWorker.DoWork += _paymentWorker_DoWork;
            _paymentWorker.RunWorkerCompleted += _paymentWorker_RunWorkerCompleted;
            _paymentWorker.ProgressChanged += _paymentWorker_ProgressChanged;
            _paymentWorker.RunWorkerAsync(reservation);
        }



        void _paymentWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (OnPaymentCompleted != null)
                {
                    OnPaymentCompleted(sender, e);
                }
            }
            finally
            {
                _paymentWorker.Dispose();
            }
        }

        void _paymentWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var reservation = (VolarisReservation)e.Argument;
            var creditCardinfo = reservation.Payment.CreditCardInformation;
            if (PaymentFactory.ContainsKey(creditCardinfo.Type))
            {
                var payment = PaymentFactory[creditCardinfo.Type]();
                payment.ServiceManager.OnWebServiceCallStart += OnWebServiceCallStartDelegate;
                payment.ServiceManager.OnWebServiceCallCompleted += OnWebServiceCallCompletedDelegate; ;
                payment.Commit(reservation);
            }

        }

        void _paymentWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is OnWebServiceCallCompletedEventArg)
            {
                if (OnWebServiceCallCompleted != null)
                {
                    OnWebServiceCallCompleted(null, e.UserState as OnWebServiceCallCompletedEventArg);
                }
            }
            if (e.UserState is OnWebServiceCallStartEventArg)
            {
                if (OnWebServiceCallStart != null)
                {
                    OnWebServiceCallStart(null, e.UserState as OnWebServiceCallStartEventArg);

                }
            }
        }

        private void OnWebServiceCallCompletedDelegate(object sender, OnWebServiceCallCompletedEventArg e)
        {
            _paymentWorker.ReportProgress(1, e);
        }

        private void OnWebServiceCallStartDelegate(object sender, OnWebServiceCallStartEventArg e)
        {
            _paymentWorker.ReportProgress(1, e);

        }

        private Dictionary<VolarisCreditCardType, Func<VolarisPaymentHandler>> _factory;
        /// <summary>
        /// Gets the payment factory.
        /// </summary>
        private Dictionary<VolarisCreditCardType, Func<VolarisPaymentHandler>> PaymentFactory
        {
            get
            {
                return _factory ?? (_factory = new Dictionary<VolarisCreditCardType, Func<VolarisPaymentHandler>>
                                                     {
                                                         {VolarisCreditCardType.AmericanExpress, () => new VolarisAmericanExpressPaymentHandler{}},
                                                         {VolarisCreditCardType.Visa, () => new VolarisVisaPaymentHandler() },
                                                           {VolarisCreditCardType.MasterCard, () => new VolarisMasterCardPaymentHandler() }

                                                     });
            }
        }

        #endregion
    }
}
