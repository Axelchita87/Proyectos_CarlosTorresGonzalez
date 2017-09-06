using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using System.ComponentModel;
using MyCTS.Services.Contracts.Volaris;
using MyCTS.Services.Contracts.Volaris.EventArguments;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.ContextSolver
{
    public class VolarisContextSolverReservationWinForms : IProcessContext<VolarisReservation>
    {
        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }
        public EventHandler OnReservationCreatedCompleted { get; set; }
        public EventHandler<OnReservationCompletedEventArg> OnReservationCreatedComplete { get; set; }
        #region Miembros de IProcessContext<VolarisReservation>

        public void Resolve(VolarisReservation reservation)
        {
            StartTriggerWorker(reservation);
        }

        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _triggerWorker;
        /// <summary>
        /// Starts the trigger worker.
        /// </summary>
        private void StartTriggerWorker(VolarisReservation reservation)
        {
            _triggerWorker = new BackgroundWorker()
                                 {
                                     WorkerReportsProgress = true
                                 };
            _triggerWorker.DoWork += _triggerWorker_DoWork;
            _triggerWorker.RunWorkerCompleted += _triggerWorker_RunWorkerCompleted;
            _triggerWorker.RunWorkerAsync(reservation);
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _triggerWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void _triggerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var reservation = (VolarisReservation)e.Result;
                StartReservationWorker(reservation);
            }
            finally
            {
                _triggerWorker.Dispose();

            }

        }

        /// <summary>
        /// Handles the DoWork event of the _triggerWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void _triggerWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            var reservation = (VolarisReservation)e.Argument;
            System.Threading.Thread.Sleep(600);
            e.Result = reservation;
        }


        private BackgroundWorker _reservationWorker;

        /// <summary>
        /// Starts the reservation worker.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        private void StartReservationWorker(VolarisReservation reservation)
        {
            _reservationWorker = new BackgroundWorker()
                                     {
                                         WorkerReportsProgress = true,WorkerSupportsCancellation = true
                                     };
            _reservationWorker.DoWork += _reservationWorker_DoWork;
            _reservationWorker.ProgressChanged += _reservationWorker_ProgressChanged;
            _reservationWorker.RunWorkerCompleted += _reservationWorker_RunWorkerCompleted;
            _reservationWorker.RunWorkerAsync(reservation);
        }

        /// <summary>
        /// Handles the ProgressChanged event of the _reservationWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        void _reservationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _reservationWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void _reservationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                
                if (!e.Cancelled)
                {
                    if (OnReservationCreatedComplete != null)
                    {
                        OnReservationCreatedComplete(null, new OnReservationCompletedEventArg());
                    }
                }
            }
            finally
            {

                _reservationWorker.Dispose();

            }
        }



        /// <summary>
        /// Handles the DoWork event of the _reservationWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void _reservationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var reservation = (VolarisReservation)e.Argument;
            var volarisServiceManager = new VolarisServiceManager
                                            {
                                                OnWebServiceCallStart = OnWebServiceCallStartDelegate,
                                                OnWebServiceCallCompleted = OnWebServiceCallCompletedDelegate,
                                                OnReservationCreatedCompleted = OnReservationCreatedCompletedDelegate

                                            };
            volarisServiceManager.CreateReservation(reservation);

            if(_reservationWorker.CancellationPending)
            {
                e.Cancel = true;
            }

            


        }

        /// <summary>
        /// Called when [reservation created completed delegate].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnReservationCreatedCompletedDelegate(object sender, EventArgs eventArgs)
        {
            if (OnReservationCreatedCompleted != null)
            {
                OnReservationCreatedCompleted(sender, eventArgs);
            }
        }

        /// <summary>
        /// Called when [web service call completed delegate].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallCompletedDelegate(object sender, OnWebServiceCallCompletedEventArg e)
        {
        

                if (e.Success)
                {
                    _reservationWorker.ReportProgress(1, new OnWebServiceCallCompletedEventArg
                                                             {
                                                                 Success = e.Success
                                                             });
                }
                else
                {
                    
                    _reservationWorker.ReportProgress(1, new OnWebServiceCallCompletedEventArg
                    {
                        ErrorMessage = e.ErrorMessage,
                        Success = e.Success
                    });
                   
                    _reservationWorker.CancelAsync();
                }
            

        }

        /// <summary>
        /// Called when [web service call start delegate].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallStartDelegate(object sender, OnWebServiceCallStartEventArg e)
        {
            if (OnWebServiceCallStart != null)
            {
                _reservationWorker.ReportProgress(1, new OnWebServiceCallStartEventArg
                                                        {
                                                            Message = e.Message
                                                        });
            }
        }


        #endregion



    }
}
