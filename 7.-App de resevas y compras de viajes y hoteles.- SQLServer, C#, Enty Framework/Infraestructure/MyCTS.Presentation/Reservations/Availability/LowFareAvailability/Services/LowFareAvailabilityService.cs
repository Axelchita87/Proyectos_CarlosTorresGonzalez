using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments;
using MyCTS.Services.Contracts;
using MyCTS.Business;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Helpers;
using MyCTS.Services.Contracts.Volaris;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Services
{
    public class LowFareAvailabilityService : IService<Flights>
    {


        private List<IAvailabilitySearchable> _departureServices;
        public List<IAvailabilitySearchable> DepartureServices
        {
            get { return _departureServices; }
            set { _departureServices = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<IAvailabilitySearchable> _availabilityServices;
        public List<IAvailabilitySearchable> AvailabilityServices
        {
            get { return _availabilityServices; }
            set { _availabilityServices = value; }
        }
        /// <summary>
        /// Adds the availability service.
        /// </summary>
        /// <param name="service">The service.</param>
        public void AddAvailabilityService(IAvailabilitySearchable service)
        {
            _availabilityServices.Add(service);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LowFareAvailabilityService"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public LowFareAvailabilityService(AvailabilityRequest request)
        {
            AvailabilityRequest = request;
            _availabilityServices = new List<IAvailabilitySearchable>();
            _departureServices = new List<IAvailabilitySearchable>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LowFareAvailabilityService"/> class.
        /// </summary>
        public LowFareAvailabilityService()
        {
            AvailabilityRequest = new AvailabilityRequest();
            _availabilityServices = new List<IAvailabilitySearchable>();
        }
        #region Miembros de IService<Flights>

        /// <summary>
        /// Calls this instance.
        /// </summary>
        /// <returns></returns>
        public Flights Call()
        {

            var flights = new Flights();
            var departureFlights = new List<IFlight>();
            var returningFlights = new List<IFlight>();
            if (OnNewServiceCall != null)
            {

                OnNewServiceCall(this, new OnNewServiceCalledEventArgs
                                          {
                                              Company = "",
                                              MessageToSend = "Buscando vuelos espere por favor... "
                                          });
            }
            var listener = new LowFareAvailabilitProcessListener();
            foreach (var availabilitySearchable in _availabilityServices)
            {
                listener.Increment();
                availabilitySearchable.Request = AvailabilityRequest;
                var departureWorkerWorker = new BackgroundWorker();
                departureWorkerWorker.DoWork += (sender, arg) =>
                                            {
                                                var service = (IAvailabilitySearchable)arg.Argument;
                                                arg.Result = service.Call();
                                            };
                departureWorkerWorker.RunWorkerCompleted += (sender, args) =>
                                                        {
                                                            listener.Decrement();
                                                            if (args.Error == null)
                                                            {
                                                                lock (departureFlights)
                                                                {
                                                                    var flight = args.Result ?? new List<IFlight>();
                                                                    departureFlights.AddRange((List<IFlight>)flight);
                                                                }
                                                            }

                                                        };

                departureWorkerWorker.RunWorkerAsync(availabilitySearchable);


            }

            #region roundTrip
            if (AvailabilityRequest.Type == AvailabilityRequestType.RoundTrip)
            {

                foreach (var departureService in _departureServices)
                {
                    listener.Increment();
                    departureService.Request = AvailabilityRequest.GetAvailabilityForRoundTrip();
                    var returningWorkerWorker = new BackgroundWorker();
                    returningWorkerWorker.DoWork += (sender, arg) =>
                                                        {
                                                            var service = (IAvailabilitySearchable)arg.Argument;
                                                            arg.Result = service.Call();
                                                        };
                    returningWorkerWorker.RunWorkerCompleted += (sender, args) =>
                                                                    {
                                                                        listener.Decrement();
                                                                        if (args.Error == null)
                                                                        {
                                                                            lock (returningFlights)
                                                                            {
                                                                                var flight = args.Result ??
                                                                                             new List<IFlight>();

                                                                                returningFlights.AddRange(
                                                                                    (List<IFlight>)flight);
                                                                            }
                                                                        }

                                                                    };

                    returningWorkerWorker.RunWorkerAsync(departureService);
                }
            }

            #endregion



            while (!listener.HasRuningProcess)
            {
                Thread.Sleep(30);
            }

            // si es interjet cuando es el OwnerCompany 
            IEnumerable<IFlight> consultaIdaInterjet = from vuelosIdaInterjet in departureFlights
                               where vuelosIdaInterjet.OwnerCompany == "InterJet"
                               select vuelosIdaInterjet;

            flights.AddDeparture(consultaIdaInterjet.ToList());


            IEnumerable<IFlight> consultaRegresoInterjet = from vuelosRegresoInterjet in returningFlights
                                                   where vuelosRegresoInterjet.OwnerCompany == "InterJet"
                                                   select vuelosRegresoInterjet;

            flights.AddReturning(consultaRegresoInterjet.ToList());

            // si es volaris cuando es el OwnerCompany 

            IEnumerable<IFlight> consultaIdaVolaris = from vuelosIdaVolaris in departureFlights
                                                      where vuelosIdaVolaris.OwnerCompany == "Volaris" && vuelosIdaVolaris.IsSingleTrip == true
                                                      select vuelosIdaVolaris;

            flights.AddDeparture(consultaIdaVolaris.ToList());

            IEnumerable<IFlight> consultaRegresoVolaris = from vuelosRegresoVolaris in departureFlights
                                                          where vuelosRegresoVolaris.OwnerCompany == "Volaris" && vuelosRegresoVolaris.IsSingleTrip == false
                                                          select vuelosRegresoVolaris;

            flights.AddReturning(consultaRegresoVolaris.ToList());

            return flights;

            //var flights = new Flights();
            //foreach (var availabilitySearchable in _availabilityServices)
            //{
            //    try
            //    {
            //        if (OnNewServiceCall != null)
            //        {

            //            OnNewServiceCall(this, new OnNewServiceCalledEventArgs
            //                                      {
            //                                          Company = availabilitySearchable.CompanyName,
            //                                          MessageToSend = string.Format("Buscando vuelos con {0}", availabilitySearchable.CompanyName)
            //                                      });
            //        }

            //        availabilitySearchable.Request = AvailabilityRequest;
            //        var result = availabilitySearchable.Call();

            //        if (result != null && result.Any())
            //        {
            //            flights.AddDeparture(result);
            //        }
            //        if (AvailabilityRequest.Type == AvailabilityRequestType.RoundTrip)
            //        {
            //            if (OnNewServiceCall != null)
            //            {

            //                OnNewServiceCall(this, new OnNewServiceCalledEventArgs
            //                {
            //                    Company = availabilitySearchable.CompanyName,
            //                    MessageToSend = string.Format("Buscando vuelos con {0}", availabilitySearchable.CompanyName)
            //                });
            //            }

            //            availabilitySearchable.Request = AvailabilityRequest.GetAvailabilityForRoundTrip();
            //            var returnings = availabilitySearchable.Call();
            //            if (returnings != null && returnings.Any())
            //            {
            //                flights.AddReturning(returnings);
            //            }

            //        }
            //    }
            //    catch (Exception exe)
            //    {
            //        if (OnWebServiceErrorCalling != null)
            //        {
            //            OnWebServiceErrorCalling(this, new OnWebServiceErrorEventArgs
            //                                              {
            //                                                  Error = exe
            //                                              });
            //        }
            //    }

            //}

            //return flights;

        }


        /// <summary>
        /// Gets or sets the availability request.
        /// </summary>
        /// <value>
        /// The availability request.
        /// </value>
        public AvailabilityRequest AvailabilityRequest { get; set; }

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


        #endregion
    }
}
