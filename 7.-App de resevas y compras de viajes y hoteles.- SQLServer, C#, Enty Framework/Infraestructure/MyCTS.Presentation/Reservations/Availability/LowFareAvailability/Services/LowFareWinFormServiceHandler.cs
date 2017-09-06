using System;
using System.Collections.Generic;
using MyCTS.Entities;
using System.ComponentModel;
using System.Threading;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class LowFareWinFormServiceHandler : Base.IServiceHandler<Flights>
    {
        private static Object thisLock = new Object();


        public EventHandler TestOnComplete { get; set; }
        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        public AvailabilityRequest Request { get; set; }
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public IService<Flights> Service { get; set; }

        /// <summary>
        /// Calls the service.
        /// </summary>
        /// <returns></returns>
        public void CallService()
        {
            TriggerWorker();
        }


        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _triggerWorker;
        /// <summary>
        /// Triggers the worker.
        /// </summary>
        private void TriggerWorker()
        {
            _triggerWorker = new BackgroundWorker();
            _triggerWorker.DoWork += _triggerWorker_DoWork;
            _triggerWorker.RunWorkerCompleted += _triggerWorker_RunWorkerCompleted;
            _triggerWorker.RunWorkerAsync();
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
                CallWebServices();
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
            Thread.Sleep(900);
        }


        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _webServiceWorker;
        /// <summary>
        /// Calls the web services.
        /// </summary>
        private void CallWebServices()
        {

            _webServiceWorker = new BackgroundWorker()
                                    {
                                        WorkerReportsProgress = true
                                    };
            _webServiceWorker.ProgressChanged += _webServiceWorker_ProgressChanged;
            _webServiceWorker.DoWork += _WebServiceWorker_DoWork;
            _webServiceWorker.RunWorkerCompleted += _WebServiceWorker_RunWorkerCompleted;
            _webServiceWorker.RunWorkerAsync(Request);
        }

        void _webServiceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is OnNewServiceCalledEventArgs)
            {
                if (OnNewServiceCall != null)
                {
                    OnNewServiceCall(this, e.UserState as OnNewServiceCalledEventArgs);
                }
            }




        }

        void _WebServiceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (OnSearchingFlightsComplete != null)
                {
                    OnSearchingFlightsComplete(this, new OnSearchingFlightsCompletedEventArgs
                                                        {
                                                            Flights = (Flights)e.Result
                                                        });

                }
            }
            finally
            {
                _webServiceWorker.Dispose();
            }
        }

        void _WebServiceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
                var request = (AvailabilityRequest)e.Argument;
                string activeFlag = ParameterBL.GetParameterValue("ActiveVolarisFlow").Values;
                if (!string.IsNullOrEmpty(activeFlag))
                {

                    if (activeFlag.Equals("Active") || activeFlag.Equals("All") || activeFlag.Contains(Login.Agent))
                    {
                        Service = new LowFareAvailabilityService()
                                  {
                                      AvailabilityRequest = request,
                                      AvailabilityServices = new List<IAvailabilitySearchable>()
                                                         {
                                                             new VolarisAvailability(),
                                                             new InterJetAvailability()
                                                         },
                                      DepartureServices = new List<IAvailabilitySearchable>()
                                                         {
                                                             new VolarisAvailability(),
                                                             new InterJetAvailability()
                                                         },
                                      OnNewServiceCall = OnNewServiceCallDelegate,
                                  };
                    }
                    else
                    {
                        Service = new LowFareAvailabilityService()
                        {
                            AvailabilityRequest = request,
                            AvailabilityServices = new List<IAvailabilitySearchable>()
                                                         {                                                             
                                                             new InterJetAvailability()
                                                         },
                            DepartureServices = new List<IAvailabilitySearchable>()
                                                         {                                                             
                                                             new InterJetAvailability()
                                                         },
                            OnNewServiceCall = OnNewServiceCallDelegate,


                        };
                    }
                }
                else
                {
                    Service = new LowFareAvailabilityService()
                    {
                        AvailabilityRequest = request,
                        AvailabilityServices = new List<IAvailabilitySearchable>()
                                                         {                                                             
                                                             new InterJetAvailability()
                                                         },
                        DepartureServices = new List<IAvailabilitySearchable>()
                                                         {                                                             
                                                             new InterJetAvailability()
                                                         },
                        OnNewServiceCall = OnNewServiceCallDelegate,


                    };
                }

                lock (thisLock)
                {
                    var flights = Service.Call();
                    e.Result = flights;
                }
        }

        private void OnNewServiceCallDelegate(object sender, OnNewServiceCalledEventArgs e)
        {
            _webServiceWorker.ReportProgress(1, e);
        }


        public EventHandler<OnSearchingFlightsCompletedEventArgs> OnSearchingFlightsComplete { get; set; }
        /// <summary>
        /// Gets or sets the on new service call.
        /// </summary>
        /// <value>
        /// The on new service call.
        /// </value>
        public EventHandler<OnNewServiceCalledEventArgs> OnNewServiceCall { get; set; }
        /// <summary>
        /// Gets or sets the on web service error calling.
        /// </summary>
        /// <value>
        /// The on web service error calling.
        /// </value>
        public EventHandler<OnWebServiceErrorEventArgs> OnWebServiceErrorCalling { get; set; }



    }
}
