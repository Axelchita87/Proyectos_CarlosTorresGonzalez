using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using MyCTS.Entities;
using MyCTS.Services.Contracts.Volaris;
using MyCTS.Business;
using MyCTS.Services.APIInterJet;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.SessionManager;
using bookingManager=MyCTS.Services.BookingManager;
using MyCTS.Services.ContentManager;
using AvailabilityRequest = MyCTS.Services.BookingManager.AvailabilityRequest;
#else
using MyCTS.Services.SessionManagerTest;
using bookingManager = MyCTS.Services.BookingManager;
using MyCTS.Services.ContentManager;
using AvailabilityRequest = MyCTS.Services.BookingManager.AvailabilityRequest;
#endif

namespace MyCTS.Services.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetServiceManager
    {

        bookingManager.TripAvailabilityResponse tripPrueba = new bookingManager.TripAvailabilityResponse();
        #region Web Services Clients


        /// <summary>
        /// Gets or sets the agent email.
        /// </summary>
        /// <value>
        /// The agent email.
        /// </value>
        public static string AgentEmail
        {
            get;
            set;

        }

#if (VOLARIS_PRODUCTION)
        /// <summary>
        /// Creates the session manager.
        /// </summary>
        /// <returns></returns>
        private IJSessionManagerClient CreateSessionManager()
        {

            return new IJSessionManagerClient();
        }
#else
        /// <summary>
        /// Creates the session manager.
        /// </summary>
        /// <returns></returns>
        private SessionManagerClient CreateSessionManager()
        {

            return new SessionManagerClient();
        }
#endif

#if (VOLARIS_PRODUCTION)
        /// <summary>
        /// Creates the booking manager.
        /// </summary>
        /// <returns></returns>
        private bookingManager.IJBookingManagerClient CreateBookingManager()
        {

            return new bookingManager.IJBookingManagerClient();
        }

#else
        /// <summary>
        /// Creates the booking manager.
        /// </summary>
        /// <returns></returns>
        private bookingManager.BookingManagerClient CreateBookingManager()
        {

            return new bookingManager.BookingManagerClient();
        }

#endif

#if (VOLARIS_PRODUCTION)
        /// <summary>
        /// Creates the content manager.
        /// </summary>
        /// <returns></returns>
        private IJContentManagerClient CreateContentManager()
        {
            return new IJContentManagerClient();
        }
#else
        /// <summary>
        /// Creates the content manager.
        /// </summary>
        /// <returns></returns>
        private ContentManagerClient CreateContentManager()
        {
            return new ContentManagerClient();
        }
#endif




        #endregion

        #region  Propierties


        /// <summary>
        /// Almacena el token de session entregado por el servicio.
        /// </summary>
        private static string _signature;

        /// <summary>
        /// Obtiene el token de session para consumir los servicios.
        /// </summary>
        public static string Signature
        {
            //get
            //{
            //    if (string.IsNullOrEmpty(_signature))
            //    {
            //        _signature = InterJetSessionManagerClient.GetSessionID();
            //    }
            //    return _signature;

            //}
            //set
            //{
            //    _signature = value;
            get;
            set;

        }

        /// <summary>
        /// Obtieneel numero de contrato.
        /// </summary>
        private static int Contract
        {
            get
            {
                return 340;
            }
        }



        #endregion

        #region Constans
        private static readonly string INTERJET_CONNECTION_NOT_FOUND = @"InterJet no cuenta con los siguientes destinos {0} - {1}, por favor seleccione otro.";
        private static readonly string INTERJET_TIME_OUT = "Ocurrio un problema al contactar con el servidor, por favor vuelva a intentar.";
        #endregion

        private int seg = 0;
        private static string taxes;

        private static int Segments;

        #region Public Methods

        /// <summary>
        /// Establece una session para el consumo de servicios.
        /// </summary>
        public void StartSession()
        {

            var sessionManager = this.CreateSessionManager();
            try
            {
                var requestData = new LogonRequestData();
                if (!string.IsNullOrEmpty(CostumerAccountInterJet.Email))
                {
                    requestData = this.GetLogonRequest(CostumerAccountInterJet.Email.ToLower(), CostumerAccountInterJet.Password, "");

                }
                else
                {
                    requestData = this.GetLogonRequest("webapi@corporatetravel.com", "cst2011", "RCTS");
                }

                if (!IsSessionAlive)
                {
                    Serializer.Serialize("StartSession", requestData);

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(requestData.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\LogonRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, requestData);
                    //file.Close();


                    Signature = sessionManager.Logon(InterJetServiceManager.Contract, requestData);

                    //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(Signature.GetType());
                    //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\LogonResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer1.Serialize(file1, Signature);
                    //file1.Close();


                    sessionManager.Close();
                }
            }
            catch (Exception exception)
            {
                try
                {
                    sessionManager.Abort();

                    LowFareAirLinesErrorLogger.Instance.Log(new LowFareAirLinesError
                    {
                        Agent = "N/A",
                        Date = DateTime.Now,
                        AirLine = LowFareAirLinesErrorLogger.InterJet,
                        ErrorMessage = exception.Message,
                        ServiceName = "InterJet OpenSession"
                    });

                }
                catch
                {
                    throw new TimeoutException("");
                }
                throw;

            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is session alive.
        /// </summary>
        /// <value>
        ///       <c>true</c> if this instance is session alive; otherwise, <c>false</c>.
        /// </value>
        private bool IsSessionAlive
        {
            get
            {
                var bookingClient = this.CreateBookingManager();
                try
                {
                    var tripAvailabilityRequest = new bookingManager.TripAvailabilityRequest
                    {
                        AvailabilityRequests = this.GetAvailabilityRequests()
                    };

                    bookingClient.GetAvailability(Contract, Signature, tripAvailabilityRequest);
                    bookingClient.Close();

                }
                catch (Exception exception)
                {
                    try
                    {
                        bookingClient.Abort();
                        bookingClient.Abort();
                        LowFareAirLinesErrorLogger.Instance.Log(new LowFareAirLinesError
                        {
                            Agent = "",
                            Date = DateTime.Now,
                            AirLine = LowFareAirLinesErrorLogger.InterJet,
                            ErrorMessage = exception.Message,
                            ServiceName = "AvailabilityInterJet"
                        });
                        return false;
                    }
                    catch
                    {
                        throw new TimeoutException("");
                    }


                }

                return true;
            }
        }

        /// <summary>
        /// Gets the logon request.
        /// </summary>
        /// <returns></returns>
        private LogonRequestData GetLogonRequest(string agentName, string password, string roleCode)
        {

#if (VOLARIS_PRODUCTION)
            var requestData = new LogonRequestData
            {
                DomainCode = "WWW",
                AgentName = agentName,
                Password = password,      // production
                LocationCode = "WEB",
                RoleCode = roleCode
            };
            return requestData;
#else
            var requestData = new LogonRequestData
            {
                DomainCode = "WWW",
                AgentName = "webapi@corporatetravel.com",
                Password = "cst2011",  //Test                
                LocationCode = "WEB",
                RoleCode = ""
            };
            return requestData; 
#endif

        }

        /// <summary>
        /// Cierra la session con el servidor.
        /// </summary>
        public void EndSession()
        {

            var sessionBooking = this.CreateSessionManager();
            try
            {

                if (this.IsSessionAlive)
                {
                    sessionBooking.Open();
                    sessionBooking.Logout(InterJetServiceManager.Contract, Signature);
                    Signature = "";
                    sessionBooking.Close();
                }
            }
            catch (Exception exception)
            {
                try
                {
                    sessionBooking.Abort();
                    LowFareAirLinesErrorLogger.Instance.Log(new LowFareAirLinesError
                    {
                        Agent = "N/A",
                        Date = DateTime.Now,
                        AirLine = LowFareAirLinesErrorLogger.InterJet,
                        ErrorMessage = exception.Message,
                        ServiceName = "InterJetssion OpenSession"
                    });


                }
                catch
                {
                    throw new TimeoutException("");
                }
                throw;

            }
        }

        public List<MyCTS.Entities.InterJetFlight> GetAvailability(Entities.AvailabilityRequest request)
        {
            //SALIDA = CUN
            //DESTINO = SAT


            //Tomar ruta es directo?
            //Si
            //Pedir disponibilidad de ruta
            //NO
            //Buscar todas las salidas de SALIDA hacia destinos ={"MEX","GDL"}
            //Por cada destino en destinos
            //   Pedir disponibilidad de SALIDA hacia DESTINO
            //   sí SALIDA tiene disponiblidad hasta DESTINO,
            //   almacenar segmento de salida

            // Por cada dest en destinos ={"MEX,"GDL"}
            //    Pedir disponiblidad dest hacia DESTINO
            //    Si dest tiene disponbilidad hacia DESTINO
            //    almacenar segmento de transbordo.

            // Es vuelo con escalas
            return GetDirectFligths(request, "", "");

            //if (InterJetFlightController.IsInterJetRoute(request.DepartureStation, request.ArrivalStation))
            //{
            //    if (InterJetFlightController.IsDirectFlight(request.DepartureStation, request.ArrivalStation))
            //    {
            //        return GetDirectFligths(request, "", "");
            //    }

            //    return GetScaleFlighst(request);
            //}
            //return new List<InterJetFlight>();

        }

        /// <summary>
        /// Gets the scale flighst.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private List<MyCTS.Entities.InterJetFlight> GetScaleFlighst(Entities.AvailabilityRequest request)
        {

            var destinations = InterJetFlightController.GetDestination(request.DepartureStation);
            var firstScalesFlights = new List<MyCTS.Entities.InterJetFlight>();
            var secondScalesFlights = new List<MyCTS.Entities.InterJetFlight>();
            foreach (var destination in destinations)
            {
                firstScalesFlights.AddRange(this.GetDirectFligths(request, "", destination));
            }
            foreach (var destination in destinations)
            {

                secondScalesFlights.AddRange(this.GetDirectFligths(request, destination, request.ArrivalStation));
            }
            var interJetFlights = new List<MyCTS.Entities.InterJetFlight>();
            if (firstScalesFlights.Any() && secondScalesFlights.Any())
            {
                foreach (var firstScale in firstScalesFlights)
                {
                    var matchedFlights = secondScalesFlights
                        .Where(s => (s.DepartureTime - firstScale.ArrivalTime).TotalHours > 1 &&
                                    (s.DepartureTime - firstScale.ArrivalTime).TotalHours < 4 &&
                                    firstScale.ArrivalStation.Equals(s.DepartureStation));
                    if (matchedFlights.Any())
                    {
                        foreach (var matchedFlight in matchedFlights)
                        {
                            var newInterJetFlight = new MyCTS.Entities.InterJetFlight
                            {
                                ArrivalStation = request.ArrivalStation,
                                DepartureStation = request.DepartureStation,
                                DepartureTime = firstScale.DepartureTime,
                                ArrivalTime = matchedFlight.ArrivalDateTime,
                                ID = "N/A",
                                OwnerCompany = "InterJet",
                                BasePrice =
                                    Convert.ToDecimal(firstScale.BasePrice) +
                                    Convert.ToDecimal(firstScale.BasePrice)

                            };
                            newInterJetFlight.Segments.Add(new MyCTS.Entities.InterJetSegment
                            {
                                DepartureStation = firstScale.DepartureStation,
                                ArrivalStation = firstScale.ArrivalStation,
                                DepartureTime = firstScale.DepartureTime,
                                ArrivalTime = firstScale.ArrivalDateTime,
                                Information = firstScale.Information,
                                ID = firstScale.ID,
                                Flight = firstScale
                            });
                            newInterJetFlight.Segments.Add(new MyCTS.Entities.InterJetSegment
                            {
                                DepartureStation = matchedFlight.DepartureStation,
                                ArrivalStation = matchedFlight.ArrivalStation,
                                DepartureTime = matchedFlight.DepartureTime,
                                ArrivalTime = matchedFlight.ArrivalDateTime,
                                Information = matchedFlight.Information,
                                ID = matchedFlight.ID,
                                Flight = matchedFlight
                            });

                            interJetFlights.Add(newInterJetFlight);

                        }
                    }

                }

                return interJetFlights;
            }



            return new List<MyCTS.Entities.InterJetFlight>();
        }

        private List<MyCTS.Entities.InterJetFlight> GetDirectFligths(Entities.AvailabilityRequest request, string newDeparture, string newArrival)
        {
            if (!IsSessionAlive)
            {
                this.StartSession();
            }
            // var bookingClient = this.CreateBookingManager();
            try
            {
                List<APIInterJet.PaxPriceType> p = new List<APIInterJet.PaxPriceType>();
                p.Add(new APIInterJet.PaxPriceType
                {
                    PaxType = "ADT",
                    PaxDiscountCode = "INET"

                });

                APIInterJet.AvailabilityRequest aReq = new APIInterJet.AvailabilityRequest
                {
                    ArrivalStation = request.ArrivalStation,
                    DepartureStation = request.DepartureStation,
                    EndDate = Convert.ToDateTime(request.DepartureDateTime),
                    BeginDate = Convert.ToDateTime(request.DepartureDateTime),
                    FlightType = APIInterJet.FlightType.All,
                    PaxCount = 1,
                    Dow = APIInterJet.DOW.Daily,
                    CurrencyCode = "MXN",
                    DisplayCurrencyCode = "MXN",
                    AvailabilityType = APIInterJet.AvailabilityType.Default,
                    MaximumConnectingFlights = 10,
                    AvailabilityFilter = APIInterJet.AvailabilityFilter.Default,
                    FareClassControl = APIInterJet.FareClassControl.Default,
                    MinimumFarePrice = 0,
                    MaximumFarePrice = 0,
                    SSRCollectionsMode = APIInterJet.SSRCollectionsMode.Segment,

                    InboundOutbound = APIInterJet.InboundOutbound.None,
                    NightsStay = 0,
                    IncludeAllotments = true,
                    IncludeTaxesAndFees = true,
                    FareRuleFilter = APIInterJet.FareRuleFilter.Default,
                    LoyaltyFilter = APIInterJet.LoyaltyFilter.MonetaryOnly,
                    PaxResidentCountry = "MX",
                    PaxPriceTypes = p
                };

                List<APIInterJet.AvailabilityRequest> lstAReq = new List<APIInterJet.AvailabilityRequest>();
                lstAReq.Add(aReq);
                lstAReq[0].LoyaltyFilter = APIInterJet.LoyaltyFilter.MonetaryOnly;

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(lstAReq.GetType());
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\Resp\getAvailabitlyRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file, lstAReq);
                //file.Close();

                APIInterJet.InterJetClient client = new InterJetClient();
                APIInterJet.TripAvailabilityResponse res = client.GetAvailability(Contract, Signature, lstAReq, IsInternational(request.DepartureStation, request.ArrivalStation));

                //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(res.Schedules[0][0].Journeys[0].GetType());
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\resp\getAvaRes " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer1.Serialize(file1, res.Schedules[0][0].Journeys[0]);
                //file1.Close();

                client.Close();

                //tripPrueba = tripAvailabilityResponse;

                //Serializer.Serialize("AvailabilityResponse", tripAvailabilityResponse);
                //bookingClient.Close();
                List<MyCTS.Entities.InterJetFlight> flights = new List<Entities.InterJetFlight>();
                flights.Clear();
                flights = GetInterJetFlights(res);//trae 8 //trae 9

                foreach (var flight in flights)
                {
                    if (flight != null)
                    {
                        if (Segments == 1)
                        {
                            flight.OwnerCompany = "InterJet";
                            flight.Segments.Add(new MyCTS.Entities.InterJetSegment
                            {
                                DepartureStation = flight.DepartureStation,
                                ArrivalStation = flight.ArrivalStation,
                                DepartureTime = flight.DepartureTime,
                                ArrivalTime = flight.ArrivalDateTime,
                                ID = flight.FlightNumber,
                                Information = flight.Information,
                                Flight = flight

                            });
                        }
                    }
                }

                return flights;
            }
            catch (Exception exception)
            {
                try
                {
                    //bookingClient.Abort();
                    LowFareAirLinesErrorLogger.Instance.Log(new LowFareAirLinesError
                    {
                        Agent = "",
                        Date = DateTime.Now,
                        AirLine = LowFareAirLinesErrorLogger.InterJet,
                        ErrorMessage = exception.Message,
                        ServiceName = "AvailabilityInterJet"
                    });

                    return new List<MyCTS.Entities.InterJetFlight>();

                }
                catch
                {
                    throw new TimeoutException("");
                }

                throw;
            }
        }

        private bool IsInternational(string departure, string arrival)
        {
            bool isInternational = false;
            GetNationalRoutes nationalDeparture = new GetNationalRoutes();
            GetNationalRoutes nationalArrival = new GetNationalRoutes();
            nationalDeparture = GetNationalRoutesBL.NationalRoutes(departure);
            nationalArrival = GetNationalRoutesBL.NationalRoutes(arrival);
            if (nationalArrival.CatCitCoudId.ToString().Trim() == "MX" && nationalDeparture.CatCitCoudId.ToString().Trim() == "MX")
            {
                isInternational = true;
            }
            return isInternational;
        }

        /// <summary>
        /// Obtiene la disponibilidad de vuelos.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public InterJetFlightsAvailability GetAvailability(InterJetAvailabilityUserInput userInput)
        {

            this.StartSession();
            var bookingClient = this.CreateBookingManager();
            try
            {
                var interJetFlights = new InterJetFlightsAvailability();

                var request = this.GetTripAvailabilityRequest(userInput);

                Serializer.Serialize("AvailabilityRequest", request);
                bookingManager.TripAvailabilityResponse tripAvailabilityResponse = bookingClient.GetAvailability(
                    Contract, Signature, request);
                Serializer.Serialize("AvailabilityResponse", tripAvailabilityResponse);
                interJetFlights = new InterJetFlightsAvailability();
                interJetFlights.AddDepartureFlight(this.GetInterJetFlights(tripAvailabilityResponse));
                bookingClient.Close();
                return interJetFlights;
            }
            catch (Exception exception)
            {
                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");
                }

                throw;
            }


        }


        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Obtiene las entidades de vuelo.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        private List<MyCTS.Entities.InterJetFlight> GetInterJetFlights(bookingManager.TripAvailabilityResponse response)
        {
            // Se Obtienen los vuelos
            var journeys = (from schedule in response.Schedules.SelectMany(schedule => schedule)
                            from journeyDateMarket in schedule.Journeys
                            select journeyDateMarket
                           ).ToList();

            var interJetFlights = new List<MyCTS.Entities.InterJetFlight>();
            for (int i = 0; i < journeys.Count; i++)
            {
                if (journeys[i].Segments.Length == 1)
                {
                    Segments = journeys[i].Segments.Length;

                    interJetFlights = (from segment in journeys
                                       where
                                       (segment.Segments[0].Fares.Any()
                                        )
                                       select new MyCTS.Entities.InterJetFlight
                                       {
                                           IsInternational = segment.Segments[0].International,
                                           ArrivalDateTime = segment.Segments[0].STA,
                                           ArrivalTime = segment.Segments[0].STA,
                                           DepartureTime = segment.Segments[0].STD,
                                           Information = new MyCTS.Entities.InterJetFlightInformation
                                           {

                                               ArrivalStation = segment.Segments[0].ArrivalStation,
                                               DepartureStation = segment.Segments[0].DepartureStation,
                                               Arrival = segment.Segments[0].STA,
                                               Departure = segment.Segments[0].STD,
                                               FlightNumber = segment.Segments[0].FlightDesignator.FlightNumber,
                                               Price = this.GetSegmentPrice(segment.Segments[0]),
                                               JourneySellKey = segment.JourneySellKey,
                                               FareSellKey = this.GetFareSellKey(segment.Segments[0]),
                                               FlightDesignator = this.GetFlightDesignator(segment.Segments[0]),
                                               Fare = this.GetFare(segment.Segments[0]),
                                               ClassOfService = GetClassOfService(segment.Segments[0])
                                           },
                                           BasePrice = Convert.ToDecimal(this.GetSegmentPrice(segment.Segments[0]))


                                       }).ToList();
                }
                else
                {
                    Segments = journeys[i].Segments.Length;
                    interJetFlights = (from segment in journeys
                                       where
                                       (segment.Segments[0].Fares.Any()
                                        )
                                       select new MyCTS.Entities.InterJetFlight
                                       {
                                           IsInternational = segment.Segments[0].International,
                                           ArrivalStation = segment.Segments[1].ArrivalStation,
                                           DepartureStation = segment.Segments[0].DepartureStation,
                                           DepartureTime = segment.Segments[0].STD,
                                           ArrivalTime = segment.Segments[1].STA,
                                           ID = "N/A",
                                           OwnerCompany = "InterJet",
                                           BasePrice =
                                           Convert.ToDecimal(this.GetSegmentPrice(segment.Segments[0])) +
                                           Convert.ToDecimal(this.GetSegmentPrice(segment.Segments[1]))

                                       }).ToList();
                    for (int b = 0; b < interJetFlights.Count; b++)
                    {
                        for (int c = 0; c < journeys[b].Segments.Length; c++)
                        {
                            interJetFlights[b].Segments.Add(new MyCTS.Entities.InterJetSegment
                            {

                                DepartureStation = journeys[b].Segments[c].DepartureStation,
                                ArrivalStation = journeys[b].Segments[c].ArrivalStation,
                                DepartureTime = journeys[b].Segments[c].STD,
                                ArrivalTime = journeys[b].Segments[c].STA,

                                Information = new MyCTS.Entities.InterJetFlightInformation
                                {
                                    ArrivalStation = journeys[b].Segments[c].ArrivalStation,
                                    DepartureStation = journeys[b].Segments[c].DepartureStation,
                                    Arrival = journeys[b].Segments[c].STA,
                                    Departure = journeys[b].Segments[c].STD,
                                    FlightNumber = journeys[b].Segments[c].FlightDesignator.FlightNumber,
                                    Price = this.GetSegmentPrice(journeys[b].Segments[c]),
                                    JourneySellKey = journeys[b].JourneySellKey,
                                    FareSellKey = this.GetFareSellKey(journeys[b].Segments[c]),
                                    FlightDesignator = this.GetFlightDesignator(journeys[b].Segments[c]),
                                    Fare = this.GetFare(journeys[b].Segments[c]),
                                    ClassOfService = GetClassOfService(journeys[b].Segments[c])
                                },
                                ID = journeys[b].Segments[c].FlightDesignator.FlightNumber,
                                Flight = interJetFlights[b]
                            });
                        }
                    }
                    break;
                }
            }

            return interJetFlights;
        }

        private List<MyCTS.Entities.InterJetFlight> GetInterJetFlights(APIInterJet.TripAvailabilityResponse response)
        {
            // Se Obtienen los vuelos
            var journeys = (from schedule in response.Schedules.SelectMany(schedule => schedule)
                            from journeyDateMarket in schedule.Journeys
                            select journeyDateMarket
                           ).ToList();

            var interJetFlights = new List<MyCTS.Entities.InterJetFlight>();
            interJetFlights.Clear();

            for (int i = 0; i < journeys.Count; i++)
            {
                bool addFlight = true;
                int x = journeys[i].Segments[0].Legs[0].LegInfo.Capacity;
                int y = journeys[i].Segments[0].Legs[0].LegInfo.Sold;
                int z= x-y;

                if (z == 0)
                {
                    addFlight = false;
                }

                if (addFlight)
                {
                    if (journeys[i].Segments.Count == 1)
                    {
                        Segments = journeys[i].Segments.Count;

                        for (int jj = 0; jj < 4; jj++)
                        {
                            if (jj < journeys[i].Segments[0].Fares.Count)
                            {
                                List<APIInterJet.Fare> lstFare = new List<APIInterJet.Fare>();
                                if (journeys[i].Segments[0].Fares.Count > 0 && journeys[i].Segments[0].Fares != null)
                                {
                                    lstFare = journeys[i].Segments[0].Fares;
                                    MyCTS.Entities.InterJetFlight f = new MyCTS.Entities.InterJetFlight
                                    {
                                        IsInternational = journeys[i].Segments[0].International,
                                        ArrivalDateTime = journeys[i].Segments[0].STA,
                                        ArrivalTime = journeys[i].Segments[0].STA,
                                        DepartureTime = journeys[i].Segments[0].STD,
                                        Information = new MyCTS.Entities.InterJetFlightInformation
                                        {

                                            ArrivalStation = journeys[i].Segments[0].ArrivalStation,
                                            DepartureStation = journeys[i].Segments[0].DepartureStation,
                                            Arrival = journeys[i].Segments[0].STA,
                                            Departure = journeys[i].Segments[0].STD,
                                            FlightNumber = journeys[i].Segments[0].FlightDesignator.FlightNumber,
                                            Price = this.GetSegmentPriceSpecial(journeys[i].Segments[0], jj),
                                            JourneySellKey = journeys[i].JourneySellKey,
                                            FareSellKey = this.GetFareSellKey(journeys[i].Segments[0], jj),
                                            FlightDesignator = this.GetFlightDesignator(journeys[i].Segments[0]),
                                            Fare = this.GetFare(journeys[i].Segments[0], jj), //this.GetFare(journeys[i].Segments[0]),
                                            ClassOfService = GetClassOfService(journeys[i].Segments[0], jj)
                                        },
                                        BasePrice = Convert.ToDecimal(this.GetSegmentPriceSpecial(journeys[i].Segments[0], jj)),
                                        Class = journeys[i].Segments[0].Fares[jj].ClassOfService
                                    };
                                    if (f.BasePrice != 0)
                                        interJetFlights.Add(f);
                                }
                            }
                        }
                    }
                    else
                    {
                        Segments = journeys[i].Segments.Count;
                        List<string> classSegment = new List<string>();

                        for (int h = 0; h < 4; h++)
                        {
                            if (h < journeys[i].Segments[0].Fares.Count)
                            {
                                classSegment.Add(journeys[i].Segments[0].Fares[h].ClassOfService + "/" + journeys[i].Segments[1].Fares[h].ClassOfService);

                            }
                        }

                        //List<string> listClass = classSegment.Distinct().ToList();


                        for (int jj = 0; jj < 4; jj++)
                        {
                            bool exist = false;

                            MyCTS.Entities.InterJetFlight f = new MyCTS.Entities.InterJetFlight
                            {
                                IsInternational = journeys[i].Segments[0].International,
                                ArrivalStation = journeys[i].Segments[1].ArrivalStation,
                                DepartureStation = journeys[i].Segments[0].DepartureStation,
                                DepartureTime = journeys[i].Segments[0].STD,
                                ArrivalTime = journeys[i].Segments[1].STA,
                                ID = "N/A",
                                OwnerCompany = "InterJet"
                            };

                            for (int c = 0; c < journeys[i].Segments.Count; c++)
                            {

                                if (jj < journeys[i].Segments[c].Fares.Count)
                                {
                                    exist = true;
                                    f.Class = classSegment[jj];
                                    f.BasePrice = Convert.ToDecimal(this.GetSegmentPriceSpecial(journeys[i].Segments[0], jj)) +
                                        Convert.ToDecimal(this.GetSegmentPriceSpecial(journeys[i].Segments[1], jj));

                                    f.Segments.Add(new MyCTS.Entities.InterJetSegment
                                    {

                                        DepartureStation = journeys[i].Segments[c].DepartureStation,
                                        ArrivalStation = journeys[i].Segments[c].ArrivalStation,
                                        DepartureTime = journeys[i].Segments[c].STD,
                                        ArrivalTime = journeys[i].Segments[c].STA,

                                        Information = new MyCTS.Entities.InterJetFlightInformation
                                        {
                                            ArrivalStation = journeys[i].Segments[c].ArrivalStation,
                                            DepartureStation = journeys[i].Segments[c].DepartureStation,
                                            Arrival = journeys[i].Segments[c].STA,
                                            Departure = journeys[i].Segments[c].STD,
                                            FlightNumber = journeys[i].Segments[c].FlightDesignator.FlightNumber,
                                            Price = this.GetSegmentPrice(journeys[i].Segments[c]),
                                            JourneySellKey = journeys[i].JourneySellKey,
                                            FareSellKey = this.GetFareSellKey(journeys[i].Segments[c], jj),
                                            FlightDesignator = this.GetFlightDesignator(journeys[i].Segments[c]),
                                            Fare = this.GetFare(journeys[i].Segments[c], jj),
                                            ClassOfService = GetClassOfService(journeys[i].Segments[c], jj)
                                        },
                                        ID = journeys[i].Segments[c].FlightDesignator.FlightNumber,
                                        Flight = f

                                    });
                                }
                            }
                            if (exist)
                                interJetFlights.Add(f);
                        }
                    }
                }
            }

            return interJetFlights;
        }

        private string GetSegmentPriceSpecial(APIInterJet.Segment segment, int i)
        {
            if (segment.Fares != null && segment.Fares.Count != 0)
            {
                if (segment.Fares.Count > i)
                {
                    APIInterJet.Fare fare = segment.Fares[i];
                    if (fare != null)
                    {

                        APIInterJet.PaxFare paxFare = fare.PaxFares.FirstOrDefault();
                        if (paxFare != null)
                        {
                            APIInterJet.BookingServiceCharge1 serviceCharge = paxFare.ServiceCharges.FirstOrDefault();
                            if (serviceCharge != null)
                            {
                                //return serviceCharge.Amount.ToString(CultureInfo.InvariantCulture);
                                return string.Format("{0:0.00}", serviceCharge.Amount);
                            }
                        }
                    }
                }
            }

            return "0.0";
        }

        private string GetClassOfService(bookingManager.Segment segment)
        {

            if (segment.Fares.Any())
            {
                var fare = segment.Fares.FirstOrDefault();

                if (fare != null)
                {

                    return fare.ClassOfService;
                }


            }
            return "Y";
        }

        private string GetClassOfService(APIInterJet.Segment segment, int f)
        {

            if (segment.Fares.Any())
            {
                var fare = segment.Fares[f].ClassOfService;

                if (fare != null)
                {

                    return fare;
                }


            }
            return "Y";
        }

        /// <summary>
        /// Gets the fare rule.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <returns></returns>
        public string GetFareRule(MyCTS.Entities.InterJetFlight flight)
        {

            var contentManager = this.CreateContentManager();

            try
            {
                var requestFareRule = new FareRuleRequestData
                {
                    CarrierCode = InterJetConstant.CarrierCode,
                    CultureCode = "MX",
                    ClassOfService = flight.Fare.ClassOfService,
                    FareBasisCode = flight.Fare.FareBasisCode
                };

                Serializer.Serialize("GetFareRuleRequest", requestFareRule);
#if (VOLARIS_PRODUCTION)
                FareRuleInfo response = contentManager.GetFareRule(Contract, Signature, requestFareRule);
#else
                FareRuleInfo response = contentManager.GetFareRuleInfo(Contract, Signature, requestFareRule);
#endif
                Serializer.Serialize("GetFareRuleResponse", response);
                string data = System.Text.Encoding.UTF8.GetString(response.Data).Replace("fs22", "fs15");
                contentManager.Close();
                return data;
            }
            catch (Exception exception)
            {
                try
                {
                    contentManager.Abort();

                }
                catch
                {
                    throw new TimeoutException("");
                }
                throw;

            }
        }

        /// <summary>
        /// Gets the fare sell key.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <returns></returns>
        private string GetFareSellKey(bookingManager.Segment segment)
        {
            if (segment != null)
            {
                bookingManager.Fare fare = segment.Fares.FirstOrDefault();
                if (fare != null)
                {
                    return fare.FareSellKey;
                }
            }
            return string.Empty;

        }

        private string GetFareSellKey(APIInterJet.Segment segment)
        {
            if (segment != null)
            {
                APIInterJet.Fare fare = segment.Fares.FirstOrDefault();
                if (fare != null)
                {
                    return fare.FareSellKey;
                }
            }
            return string.Empty;

        }

        private string GetFareSellKey(APIInterJet.Segment segment, int i)
        {
            if (segment != null)
            {
                if (segment.Fares.Count > i)
                {
                    APIInterJet.Fare fare = segment.Fares[i];
                    if (fare != null)
                    {
                        return fare.FareSellKey;
                    }
                }

            }

            return string.Empty;

        }


        /// <summary>
        /// Obtiene la tarifa necesaria de interjet.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        private MyCTS.Entities.InterJetFare GetFare(bookingManager.Segment segment)
        {
            var fare = new MyCTS.Entities.InterJetFare();

            bookingManager.Fare originalFare = segment.Fares.FirstOrDefault();
            if (originalFare != null)
            {
                fare.CarrierCode = originalFare.CarrierCode;
                fare.ClassOfService = originalFare.ClassOfService;
                fare.ClassType = originalFare.ClassType;
                fare.FareBasisCode = originalFare.FareBasisCode;
                fare.FareClassOfService = originalFare.FareClassOfService;
                fare.FareSequence = originalFare.FareSequence;
                fare.RuleNumber = originalFare.RuleNumber;
                fare.RuleTariff = originalFare.RuleTariff;
            }
            return fare;
        }

        private MyCTS.Entities.InterJetFare GetFare(APIInterJet.Segment segment, int element)
        {
            var fare = new MyCTS.Entities.InterJetFare();

            APIInterJet.Fare originalFare = segment.Fares[element];
            if (originalFare != null)
            {
                fare.CarrierCode = originalFare.CarrierCode;
                fare.ClassOfService = originalFare.ClassOfService;
                fare.ClassType = originalFare.ClassType;
                fare.FareBasisCode = originalFare.FareBasisCode;
                fare.FareClassOfService = originalFare.FareClassOfService;
                fare.FareSequence = originalFare.FareSequence;
                fare.RuleNumber = originalFare.RuleNumber;
                fare.RuleTariff = originalFare.RuleTariff;
            }
            return fare;
        }

        /// <summary>
        /// Obtiene el designador  de vuelos de un segmento.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        private MyCTS.Entities.InterJetFlightDesignator GetFlightDesignator(bookingManager.Segment segment)
        {
            var flightDesignator = new MyCTS.Entities.InterJetFlightDesignator
            {
                FlightNumber = segment.FlightDesignator.FlightNumber,
                CarrierCode = segment.FlightDesignator.CarrierCode
            };
            return flightDesignator;
        }

        private MyCTS.Entities.InterJetFlightDesignator GetFlightDesignator(APIInterJet.Segment segment)
        {
            var flightDesignator = new MyCTS.Entities.InterJetFlightDesignator
            {
                FlightNumber = segment.FlightDesignator.FlightNumber,
                CarrierCode = segment.FlightDesignator.CarrierCode
            };
            return flightDesignator;
        }

        /// <summary>
        /// Obtiene el precio del vuelo que se encuentra en el segmento.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        private string GetSegmentPrice(bookingManager.Segment segment)
        {
            bookingManager.Fare fare = segment.Fares.FirstOrDefault();
            if (fare != null)
            {

                bookingManager.PaxFare paxFare = fare.PaxFares.FirstOrDefault();
                if (paxFare != null)
                {
                    bookingManager.BookingServiceCharge serviceCharge = paxFare.ServiceCharges.FirstOrDefault();
                    if (serviceCharge != null)
                    {
                        //return serviceCharge.Amount.ToString(CultureInfo.InvariantCulture);
                        return string.Format("{0:0.00}", serviceCharge.Amount);
                    }
                }
            }

            return "0.0";
        }

        private string GetSegmentPrice(APIInterJet.Segment segment)
        {
            APIInterJet.Fare fare = segment.Fares.FirstOrDefault();
            if (fare != null)
            {

                APIInterJet.PaxFare paxFare = fare.PaxFares.FirstOrDefault();
                if (paxFare != null)
                {
                    APIInterJet.BookingServiceCharge1 serviceCharge = paxFare.ServiceCharges.FirstOrDefault();
                    if (serviceCharge != null)
                    {
                        //return serviceCharge.Amount.ToString(CultureInfo.InvariantCulture);
                        return string.Format("{0:0.00}", serviceCharge.Amount);
                    }
                }
            }

            return "0.0";
        }

        /// <summary>
        /// Obtiene una peticion de disponiilidad
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        private bookingManager.TripAvailabilityRequest GetTripAvailabilityRequest(InterJetAvailabilityUserInput userInput)
        {
            var tripAvailabilityRequest = new bookingManager.TripAvailabilityRequest
            {
                AvailabilityRequests = this.GetAvailabilityRequests(userInput)
            };
            return tripAvailabilityRequest;
        }


        /// <summary>
        /// Obtiene la peticiones de disponibilidad con los parametros completos.
        /// </summary>//aqui empieza
        /// <param name="userInput">The user input.</param>
        /// <returns></returns>
        private AvailabilityRequest[] GetAvailabilityRequests(InterJetAvailabilityUserInput userInput)
        {
            AvailabilityRequest availabilityRequest = this.GetAvailabilityRequestWithDefaultParameters();

            if (userInput.IsInternationalItinerary)
            {
                availabilityRequest.CarrierCode = InterJetConstant.CarrierCodeInternational;
            }
            availabilityRequest.ArrivalStation = userInput.ArrivalStation;
            availabilityRequest.DepartureStation = userInput.DepartureStation;
            availabilityRequest.BeginDate = userInput.BeginDate;
            availabilityRequest.EndDate = userInput.BeginDate;
            availabilityRequest.PaxPriceTypes = this.GetPaxPriceTypes(userInput);

            availabilityRequest.PaxCount = userInput.PassangerCount;
            availabilityRequest.IncludeTaxesAndFees = true;
            availabilityRequest.MaximumConnectingFlights = 3;
            availabilityRequest.InboundOutbound = bookingManager.InboundOutbound.Both;
            availabilityRequest.IncludeAllotments = true;
            var availabilityRequests = new List<AvailabilityRequest>
                                           {
                                               availabilityRequest
                                           };
            return availabilityRequests.ToArray();
        }


        /// <summary>
        /// Gets the availability requests.
        /// </summary>
        /// <returns></returns>
        private AvailabilityRequest[] GetAvailabilityRequests()
        {
            AvailabilityRequest availabilityRequest = this.GetAvailabilityRequestWithDefaultParameters();


            availabilityRequest.CarrierCode = InterJetConstant.CarrierCode;

            availabilityRequest.ArrivalStation = "MEX";
            availabilityRequest.DepartureStation = "CUN";
            availabilityRequest.BeginDate = DateTime.Now.AddDays(5);
            availabilityRequest.EndDate = DateTime.Now.AddDays(5);
            availabilityRequest.PaxPriceTypes = new[]
                                                    {
                                                        new bookingManager.PaxPriceType
                                                            {
                                                                PaxType = "ADT"
                                                            }
                                                    };

            availabilityRequest.PaxCount = 1;

            var availabilityRequests = new List<AvailabilityRequest>
                                           {
                                               availabilityRequest
                                           };
            return availabilityRequests.ToArray();
        }

        /// <summary>
        /// Obtiene los precios por tipo depasajeros.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        /// <returns></returns>
        private bookingManager.PaxPriceType[] GetPaxPriceTypes(InterJetAvailabilityUserInput userInput)
        {
            var passangerPriceTypes = new List<bookingManager.PaxPriceType>();
            if (userInput.HasAdultsPassangers)
            {
                passangerPriceTypes.AddRange(this.GetPaxPriceTypes("ADT", userInput.AdultsPassangers));
            }

            if (userInput.HasChildrenPassangers)
            {
                passangerPriceTypes.AddRange(this.GetPaxPriceTypes("CHD", userInput.ChildsPassangers));
            }
            if (userInput.HasSeniorsPassangers)
            {
                passangerPriceTypes.AddRange(this.GetPaxPriceTypes("SRC", userInput.SeniorsPassangers));
            }
            return passangerPriceTypes.ToArray();


        }

        /// <summary>
        /// Obtiene le precio por tipos de pasajeros.
        /// </summary>
        /// <param name="paxType"></param>
        /// <param name="numbersOfPassangers"></param>
        /// <returns></returns>
        private IEnumerable<bookingManager.PaxPriceType> GetPaxPriceTypes(string paxType, int numbersOfPassangers)
        {
            var passangerTypes = new List<bookingManager.PaxPriceType>();
            for (int passangerCount = 0; passangerCount < numbersOfPassangers; passangerCount++)
            {
                var passangerType = new bookingManager.PaxPriceType
                {
                    PaxType = paxType
                };
                passangerTypes.Add(passangerType);
                passangerType.PaxDiscountCode = "INET";

            }

            return passangerTypes;
        }

        /// <summary>
        /// Obtiene una instancia de una availability Request con los parametros por default
        /// </summary>
        /// <returns></returns>
        private AvailabilityRequest GetAvailabilityRequestWithDefaultParameters()
        {
            string[] fareType;

            fareType = InterJetConstant.FareTypes;

            var availabilityRequest = new AvailabilityRequest
            {
                CarrierCode = InterJetConstant.CarrierCode,
                CurrencyCode = InterJetConstant.CurrencyCode,
                FlightType = bookingManager.FlightType.All,
                Dow = bookingManager.DOW.Daily,
                AvailabilityType = bookingManager.AvailabilityType.Default,
                AvailabilityFilter = bookingManager.AvailabilityFilter.Default,
                FareClassControl = bookingManager.FareClassControl.LowestFareClass,
                FareTypes = fareType,
                IncludeTaxesAndFees = true,

            };

            return availabilityRequest;

        }

        /// <summary>
        /// Obtiene los precios por tipo de pasajeros.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private bookingManager.PaxPriceType[] GetPaxPricesTypeFormTicket(MyCTS.Entities.InterJetTicket ticket)
        {
            var paxPriceType = new List<bookingManager.PaxPriceType>();
            if (ticket.Passangers.HasAdults)
            {
                paxPriceType.AddRange(this.GetPaxPriceTypes("ADT", ticket.Passangers.TotalAdults));
            }

            if (ticket.Passangers.HasChildren)
            {
                paxPriceType.AddRange(this.GetPaxPriceTypes("CHD", ticket.Passangers.TotalChildren));
            }

            if (ticket.Passangers.HasSeniorAdult)
            {
                paxPriceType.AddRange(this.GetPaxPriceTypes("SRC", ticket.Passangers.TotalSenior));
            }
            return paxPriceType.ToArray();
        }

        /// <summary>
        /// Obtiene la información especifica por tipo de pasajero..
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private bookingManager.PassengerTypeInfo[] GetPaxTypeInfoFromTicket(MyCTS.Entities.InterJetTicket ticket)
        {
            var types = new List<bookingManager.PassengerTypeInfo>();

            if (ticket.Passangers.HasAdults)
            {
                types.AddRange(this.GetPaxTypeInfo("ADT", ticket.Passangers.TotalAdults));
            }

            if (ticket.Passangers.HasChildren)
            {
                types.AddRange(this.GetPaxTypeInfo("CHD", ticket.Passangers.TotalChildren));
            }

            if (ticket.Passangers.HasSeniorAdult)
            {
                types.AddRange(this.GetPaxTypeInfo("SRC", ticket.Passangers.TotalSenior));
            }
            return types.ToArray();
        }

        /// <summary>
        /// Obtiene los informacion de los tipos de pasajeros.
        /// </summary>
        /// <param name="paxType"></param>
        /// <param name="totalOfPasanger"></param>
        /// <returns></returns>
        private IEnumerable<bookingManager.PassengerTypeInfo> GetPaxTypeInfo(string paxType, int totalOfPasanger)
        {
            var passangersType = new List<bookingManager.PassengerTypeInfo>();
            for (int paxIndex = 0; paxIndex < totalOfPasanger; paxIndex++)
            {
                var type = new bookingManager.PassengerTypeInfo
                {
                    PaxType = paxType,

                };
                passangersType.Add(type);
            }
            return passangersType;

        }

        /// <summary>
        /// Obtiene el contacto de interjet de un ticket.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private bookingManager.BookingContact[] GetInterJetContactFromTicket(MyCTS.Entities.InterJetTicket ticket)
        {
            MyCTS.Entities.InterJetContact contact = ticket.Contact;

            var fiscalContact = new bookingManager.BookingContact
            {
                CompanyName = "Corporate Travel Service",
                AddressLine1 = "Jaime Balmes 11",
                AddressLine2 = "Torre C Piso 9",
                AddressLine3 = "Colonia Polanco",
                City = "Mexico",
                CountryCode = "MX",
                CultureCode = "es-MX",
                DistributionOption = bookingManager.DistributionOption.Email,
                EmailAddress = AgentEmail,
                PostalCode = "11510",
                ProvinceState = "MX",
                WorkPhone = "5585252222",
                Fax = "",
                TypeCode = "P",
                HomePhone = "5585252222",
                Names = new bookingManager.BookingName[]
                                                    {
                                                        new bookingManager.BookingName
                                                            {
                                                                FirstName = "Corporate Travel Service",
                                                                LastName = "Corporate Travel Service",
                                                                Title = "MRS",
                                                            }
                                                    }


            };


            var bookingContact = new bookingManager.BookingContact
            {
                Names = this.GetBookingNameFromContact(contact),
                AddressLine1 = ticket.Contact.Address1,
                AddressLine2 = ticket.Contact.Address2,
                AddressLine3 = ticket.Contact.Address3,
                City = contact.City,
                EmailAddress = contact.Email,
                Fax = contact.Fax,
                HomePhone = contact.PrimaryTelephone,
                WorkPhone = contact.CellPhone,
                OtherPhone = contact.AlternTelephone,
                PostalCode = contact.PostalCode,
                ProvinceState = contact.State,
                DistributionOption = bookingManager.DistributionOption.Email
            };
            bookingContact.City = contact.City;
            bookingContact.CultureCode = "es-MX";
            bookingContact.CountryCode = "MX";
            bookingContact.TypeCode = "D";

            return new[] { fiscalContact, bookingContact };
        }

        /// <summary>
        /// Obtiene el el nombre del contacto.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        private bookingManager.BookingName[] GetBookingNameFromContact(MyCTS.Entities.InterJetContact contact)
        {
            var bookingName = new bookingManager.BookingName { FirstName = contact.Name, LastName = contact.LastName, Title = contact.Title };
            return new[] { bookingName };

        }

        /// <summary>
        /// Gets the special service.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        private bookingManager.SSRRequest GetSpecialServicePreviousPricing(InterJetAvailabilityUserInput userInput, MyCTS.Entities.InterJetFlight flight)
        {
            var request = new bookingManager.SSRRequest();
            var segmentRequests = new List<bookingManager.SegmentSSRRequest>();


            var ssrRequest = new bookingManager.SegmentSSRRequest
            {
                ArrivalStation = flight.ArrivalStation,
                DepartureStation = flight.DepartureStation,
                FlightDesignator = new bookingManager.FlightDesignator
                {

                    CarrierCode =
                        flight.FlightDesignator.CarrierCode,
                    FlightNumber = flight.FlightNumber
                },
                STD = flight.DepartureTime,
                PaxSSRs = this.GetSpecialService(userInput, flight, 0)

            };
            segmentRequests.Add(ssrRequest);
            request.SegmentSSRRequests = segmentRequests.ToArray();
            return request;
        }

        private bookingManager.SSRRequest GetSpecialServicePreviousPricingTest(InterJetAvailabilityUserInput userInput, IEnumerable<MyCTS.Entities.InterJetFlight> flights)
        {
            var request = new bookingManager.SSRRequest();
            var segmentRequests = new List<bookingManager.SegmentSSRRequest>();
            int f = 0;
            foreach (var flight in flights)
            {
                if (flight != null && Segments == 1)
                {
                    var ssrRequest = new bookingManager.SegmentSSRRequest
                    {
                        ArrivalStation = flight.ArrivalStation,
                        DepartureStation = flight.DepartureStation,
                        FlightDesignator = new bookingManager.FlightDesignator
                        {

                            CarrierCode =
                                flight.FlightDesignator.CarrierCode,
                            FlightNumber = flight.FlightNumber
                        },
                        STD = flight.DepartureTime,
                        PaxSSRs = this.GetSpecialService(userInput, flight, 0)

                    };
                    segmentRequests.Add(ssrRequest);
                }
                else
                {
                    for (int i = 0; i < Segments; i++)
                    {
                        var ssrRequest = new bookingManager.SegmentSSRRequest
                        {
                            ArrivalStation = ((Entities.InterJetSegment)flights.ToList()[f].Segments.GetAll()[i]).Information.ArrivalStation,
                            DepartureStation = ((Entities.InterJetSegment)flights.ToList()[f].Segments.GetAll()[i]).Information.DepartureStation,
                            FlightDesignator = new bookingManager.FlightDesignator
                            {

                                CarrierCode =
                                    ((Entities.InterJetSegment)flights.ToList()[f].Segments.GetAll()[i]).Information.FlightDesignator.CarrierCode,
                                FlightNumber = ((Entities.InterJetSegment)flights.ToList()[f].Segments.GetAll()[i]).Information.FlightDesignator.FlightNumber
                            },
                            STD = ((Entities.InterJetSegment)flights.ToList()[f].Segments.GetAll()[i]).Information.Departure,
                            PaxSSRs = this.GetSpecialService(userInput, flight, i)

                        };
                        segmentRequests.Add(ssrRequest);

                    }
                    f = f + 1;
                }
            }
            f = 0;
            request.SegmentSSRRequests = segmentRequests.ToArray();
            return request;
        }

        /// <summary>
        /// Gets the special service.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        /// <returns></returns>
        private bookingManager.PaxSSR[] GetSpecialService(InterJetAvailabilityUserInput userInput, MyCTS.Entities.InterJetFlight flight, int seg)
        {

            var paxes = new List<bookingManager.PaxSSR>();

            if (flight != null && Segments == 1)
            {
                for (int paxCount = 0; paxCount < userInput.InfantsPassangers; paxCount++)
                {
                    var paxSSR = new bookingManager.PaxSSR
                    {
                        ActionStatusCode = "NN",
                        DepartureStation = flight.DepartureStation,
                        ArrivalStation = flight.ArrivalStation,
                        PassengerNumber = (short)paxCount,
                        SSRCode = "INF",
                        FeeCode = "INF",
                        Note = "true",
                        SSRDetail = "true",
                        SSRNumber = (short)paxCount,
                        SSRValue = (short)paxCount

                    };
                    paxes.Add(paxSSR);
                }
            }
            else
            {
                for (int paxCount = 0; paxCount < userInput.InfantsPassangers; paxCount++)
                {
                    var paxSSR = new bookingManager.PaxSSR
                    {
                        ActionStatusCode = "NN",
                        DepartureStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[seg]).Information.DepartureStation,
                        ArrivalStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[seg]).Information.ArrivalStation,
                        PassengerNumber = (short)paxCount,
                        SSRCode = "INF",
                        FeeCode = "INF",
                        Note = "true",
                        SSRDetail = "true",
                        SSRNumber = (short)paxCount,
                        SSRValue = (short)paxCount

                    };
                    paxes.Add(paxSSR);
                  
                }
            }

            return paxes.ToArray();

        }

        /// <summary>
        /// Gets the special service.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        private bookingManager.SSRRequest GetSpecialService(MyCTS.Entities.InterJetTicket ticket, bool IsInternational)
        {
            var request = new bookingManager.SSRRequest();
            var segmentRequests = new List<bookingManager.SegmentSSRRequest>();
            foreach (MyCTS.Entities.InterJetFlight flight in ticket.Flights.GetAllFlights().Where(f => f.IsInternational == IsInternational))
            {
                if (flight.HasInfants)
                {
                    if (flight.Segments.GetAll().Count == 1)
                    {
                        var ssrRequest = new bookingManager.SegmentSSRRequest
                        {
                            ArrivalStation = flight.ArrivalStation,
                            DepartureStation = flight.DepartureStation,
                            FlightDesignator = new bookingManager.FlightDesignator
                            {

                                CarrierCode =
                                    flight.FlightDesignator.CarrierCode,
                                FlightNumber = flight.FlightNumber
                            },
                            STD = flight.DepartureTime,
                            PaxSSRs = this.GetSpecialService(ticket, flight,0)

                        };
                        segmentRequests.Add(ssrRequest);
                    }
                    else
                    {
                        for (int i = 0; i < flight.Segments.GetAll().Count; i++)
                        {
                            var ssrRequest = new bookingManager.SegmentSSRRequest
                            {
                                ArrivalStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.ArrivalStation,
                                DepartureStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.DepartureStation,
                                FlightDesignator = new bookingManager.FlightDesignator
                                {

                                    CarrierCode =
                                        ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.FlightDesignator.CarrierCode,
                                    FlightNumber = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.FlightDesignator.FlightNumber
                                },
                                STD = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.Departure,
                                PaxSSRs = this.GetSpecialService(ticket, flight,i)

                            };
                            segmentRequests.Add(ssrRequest);
                        }
                    }
                }
            }
            request.SegmentSSRRequests = segmentRequests.ToArray();
            return request;
        }

        /// <summary>
        /// Gets the special service.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        private bookingManager.SSRRequest GetSpecialService(MyCTS.Entities.InterJetTicket ticket)
        {
            var request = new bookingManager.SSRRequest();
            var segmentRequests = new List<bookingManager.SegmentSSRRequest>();
            foreach (MyCTS.Entities.InterJetFlight flight in ticket.Flights.GetAllFlights())
            {
                if (flight != null && Segments == 1)
                {
                    if (flight.HasInfants)
                    {
                        var ssrRequest = new bookingManager.SegmentSSRRequest
                        {
                            ArrivalStation = flight.ArrivalStation,
                            DepartureStation = flight.DepartureStation,
                            FlightDesignator = new bookingManager.FlightDesignator
                            {

                                CarrierCode =
                                    flight.FlightDesignator.CarrierCode,
                                FlightNumber = flight.FlightNumber
                            },
                            STD = flight.DepartureTime,
                            PaxSSRs = this.GetSpecialService(ticket, flight,0)

                        };
                        segmentRequests.Add(ssrRequest);

                    }
                }
                else
                {
                    if (flight.HasInfants)
                    {
                        for (int i = 0; i < flight.Segments.GetAll().Count; i++)
                        {
                            var ssrRequest = new bookingManager.SegmentSSRRequest
                            {
                                ArrivalStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.ArrivalStation,
                                DepartureStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.DepartureStation,
                                FlightDesignator = new bookingManager.FlightDesignator
                                {

                                    CarrierCode =
                                    ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.FlightDesignator.CarrierCode,
                                    FlightNumber =
                                    ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.FlightDesignator.FlightNumber
                                },
                                STD = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.Departure,
                                PaxSSRs = this.GetSpecialService(ticket, flight, i)

                            };
                            segmentRequests.Add(ssrRequest);
                        }
                    }
                }
            }
            request.SegmentSSRRequests = segmentRequests.ToArray();
            return request;
        }

        /// <summary>
        /// Gets the special service.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        /// <returns></returns>
        private bookingManager.PaxSSR[] GetSpecialService(MyCTS.Entities.InterJetTicket ticket, MyCTS.Entities.InterJetFlight flight, int i)
        {

            var paxes = new List<bookingManager.PaxSSR>();
            short paxCount = 0;
            foreach (var pax in ticket.Passangers.GetPassengerWithInfantsAssigned())
            {
                if (flight.Segments.GetAll().Count < 2)
                {
                    var paxSSR = new bookingManager.PaxSSR
                    {
                        ActionStatusCode = "NN",
                        DepartureStation = flight.DepartureStation,
                        ArrivalStation = flight.ArrivalStation,
                        PassengerNumber = Convert.ToInt16(pax.InternalID),
                        SSRCode = "INF",
                        SSRNumber = 0,
                        SSRValue = 0

                    };
                    paxCount += 1;
                    paxes.Add(paxSSR);

                }
                else
                {
                    var paxSSR = new bookingManager.PaxSSR
                    {
                        ActionStatusCode = "NN",
                        DepartureStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.DepartureStation,
                        ArrivalStation = ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.ArrivalStation,
                        PassengerNumber = Convert.ToInt16(pax.InternalID),
                        SSRCode = "INF",
                        SSRNumber = 0,
                        SSRValue=0
                    };
                    paxCount += 1;
                    paxes.Add(paxSSR);
                }
            }


            return paxes.ToArray();

        }

        private bool HasAnInfantAssigned(MyCTS.Entities.InterJetPassanger pax)
        {
            if (pax is InterJetSeniorAdultPassanger)
            {
                var senior = (InterJetSeniorAdultPassanger)pax;
                return senior.AssignedInfant != null;
            }

            if (pax is InterJetAdultPassanger)
            {

                var adult = (InterJetAdultPassanger)pax;
                return adult.AssignedInfant != null;
            }

            return false;

        }

        /// <summary>
        /// Obtiene el precio de ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        public decimal GetItineraryPrice(MyCTS.Entities.InterJetTicket ticket)
        {

            decimal total = 0;
            total += GetItineraryPriceForNationals(ticket);
            if (ticket.Flights.HasInternationalSegments)
            {
                total += GetItineraryPriceForIternationationals(ticket);
            }
            if (total == PriceTotalResponseInterjet.getItinearyPrice)
            {
                ticket.BalanceToPay = total;
            }
            else
            {
                ticket.BalanceToPay = PriceTotalResponseInterjet.getItinearyPrice;
                total = PriceTotalResponseInterjet.getItinearyPrice;
            }

            return total;
        }

        public decimal GetItineraryPriceTest(MyCTS.Entities.InterJetTicket ticket)
        {
            var bookingClient = this.CreateBookingManager();
            try
            {

                var itineraryPriceRequest = new bookingManager.ItineraryPriceRequest();

                itineraryPriceRequest.SellByKeyRequest = new bookingManager.SellJourneyByKeyRequestData();
                itineraryPriceRequest.SSRRequest = new bookingManager.SSRRequest();
                itineraryPriceRequest.SSRRequest = this.GetSpecialService(ticket, true);
                itineraryPriceRequest.SSRRequest.CurrencyCode = InterJetConstant.CurrencyCode;

                itineraryPriceRequest.PriceItineraryBy = bookingManager.PriceItineraryBy.JourneyBySellKey;
                itineraryPriceRequest.SellByKeyRequest.PaxCount = ticket.Passangers.Total;
                itineraryPriceRequest.SellByKeyRequest.PaxPriceType = this.GetPaxPricesTypeFormTicket(ticket);
                itineraryPriceRequest.SellByKeyRequest.JourneySellKeys = this.GetSellKeyListFromTicketTest(ticket.Flights.GetFlights());//aqui esta el getselljourney
                itineraryPriceRequest.SellByKeyRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                itineraryPriceRequest.SellByKeyRequest.ActionStatusCode = InterJetConstant.ActionStatusCode;


                var pax = ticket.Passangers.GetAll().FirstOrDefault();
                string residenty = "OC";
                if (pax != null)
                {
                    residenty = pax.Nationality;

                }
                itineraryPriceRequest.TypeOfSale = new bookingManager.TypeOfSale();
                itineraryPriceRequest.TypeOfSale.PaxResidentCountry = "MX";

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(itineraryPriceRequest.GetType());
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file, itineraryPriceRequest);
                //file.Close();

                Serializer.Serialize("GetItineraryPriceRequestInternationals", itineraryPriceRequest);

                bookingManager.Booking booking = bookingClient.GetItineraryPrice(Contract, Signature,
                                                                                itineraryPriceRequest);

                PriceTotalResponseInterjet.totalPriceInfant = 0;
                PriceTotalResponseInterjet.totalPriceInfant = booking.BookingSum.BalanceDue - PriceTotalResponseInterjet.getItinearyPrice;
                PriceTotalResponseInterjet.getItinearyPrice= booking.BookingSum.BalanceDue;

                //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(booking.GetType());
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer1.Serialize(file1, booking);
                //file1.Close();


                Serializer.Serialize("GetItineraryPriceResponseInternationals", booking);
                this.SetFlightsTaxes(ticket, ticket.Flights.GetAllFlights(),
                                     booking);
                bookingClient.Close();

                return booking.BookingSum.TotalCost;

            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");

                }
                throw;
            }
            return 0;


        }

        /// <summary>
        /// Gets the itinerary price.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        /// <param name="selectedFlights">The selected flights.</param>
        /// <returns></returns>
        public List<MyCTS.Entities.InterJetFlight> GetItineraryPrice(InterJetAvailabilityUserInput userInput, InterJetSelectedFlights selectedFlights)
        {
            GetItineraryPriceAndSetPrices(userInput, selectedFlights);

            return selectedFlights.GetFlights();
        }

        public List<MyCTS.Entities.InterJetFlight> GetItineraryPriceTest(InterJetAvailabilityUserInput userInput, InterJetSelectedFlights selectedFlights)
        {
            GetItineraryPriceAndSetPricesTest(userInput, selectedFlights);

            return selectedFlights.GetFlights();
        }

        /// <summary>
        /// Obtiene los indentifiacadores de los vuelos.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="IsInternational">if set to <c>true</c> [is international].</param>
        /// <returns></returns>
        private bookingManager.SellKeyList[] GetSellKeyListFromTicketTest(IEnumerable<MyCTS.Entities.InterJetFlight> flights)
        {
            bookingManager.SellKeyList[] keys = null;
            bool conexion = false;
            List<bookingManager.SellKeyList> keys2 = new List<bookingManager.SellKeyList>();
            List<bookingManager.SellKeyList> keys3 = new List<bookingManager.SellKeyList>();
            foreach (MyCTS.Entities.InterJetFlight flight in flights)
            {
                foreach (MyCTS.Entities.ISegment seg in flight.Segments.GetAll())
                {
                    keys2.Add(new bookingManager.SellKeyList
                    {
                        FareSellKey = ((MyCTS.Entities.InterJetSegment)seg).Information.FareSellKey,
                        JourneySellKey = ((MyCTS.Entities.InterJetSegment)seg).Information.JourneySellKey
                    });
                }
            }

            int i = 0;

            foreach (MyCTS.Entities.InterJetFlight flight in flights)
            {
                if (flight.Segments.GetAll().Count > 1)
                {
                    if (i > 0 && keys2.Count == 4)
                    {
                        keys2[2].FareSellKey = keys2[2].FareSellKey + "^" + keys2[3].FareSellKey;
                    }
                    else
                    {
                        keys2[0].FareSellKey = keys2[0].FareSellKey + "^" + keys2[1].FareSellKey;
                    }
                    conexion = true;
                    i++;
                }
            }

            if (flights.ToList().Count == 1 && conexion)
            {
                keys3.Add(new bookingManager.SellKeyList { FareSellKey = keys2[0].FareSellKey, JourneySellKey = keys2[0].JourneySellKey });
                keys = keys3.ToArray();
            }
            else if (flights.ToList().Count > 1 && conexion)
            {
                keys3.Add(new bookingManager.SellKeyList { FareSellKey = keys2[0].FareSellKey, JourneySellKey = keys2[0].JourneySellKey });
                keys3.Add(new bookingManager.SellKeyList { FareSellKey = keys2[2].FareSellKey, JourneySellKey = keys2[2].JourneySellKey });
                keys = keys3.ToArray();
            }
            else
            {
                keys = keys2.ToArray();
            }

            return keys;
        }

        private APIInterJet.SellKeyList[] GetSellKeyListFromTicketTestApi(List<MyCTS.Entities.InterJetFlight> flights)
        {
            APIInterJet.SellKeyList[] keys = null;
            bool conexion = false;
            List<APIInterJet.SellKeyList> keys2 = new List<APIInterJet.SellKeyList>();
            List<APIInterJet.SellKeyList> keys3 = new List<APIInterJet.SellKeyList>();
            foreach (MyCTS.Entities.InterJetFlight flight in flights)
            {
                foreach (MyCTS.Entities.ISegment seg in flight.Segments.GetAll())
                {
                    keys2.Add(new APIInterJet.SellKeyList
                    {
                        FareSellKey = ((MyCTS.Entities.InterJetSegment)seg).Information.FareSellKey,
                        JourneySellKey = ((MyCTS.Entities.InterJetSegment)seg).Information.JourneySellKey
                    });
                }
            }

            int i = 0;

            foreach (MyCTS.Entities.InterJetFlight flight in flights)
            {
                if (flight.Segments.GetAll().Count > 1)
                {
                    if (i > 0 && keys2.Count == 4)
                    {
                        keys2[2].FareSellKey = keys2[2].FareSellKey + "^" + keys2[3].FareSellKey;
                    }
                    else
                    {
                        keys2[0].FareSellKey = keys2[0].FareSellKey + "^" + keys2[1].FareSellKey;
                    }
                    conexion = true;
                    i++;
                }
            }

            if (flights.ToList().Count == 1 && conexion)
            {
                keys3.Add(new APIInterJet.SellKeyList { FareSellKey = keys2[0].FareSellKey, JourneySellKey = keys2[0].JourneySellKey });
                keys = keys3.ToArray();
            }
            else if (flights.ToList().Count > 1 && conexion)
            {
                keys3.Add(new APIInterJet.SellKeyList { FareSellKey = keys2[0].FareSellKey, JourneySellKey = keys2[0].JourneySellKey });
                keys3.Add(new APIInterJet.SellKeyList { FareSellKey = keys2[2].FareSellKey, JourneySellKey = keys2[2].JourneySellKey });
                keys = keys3.ToArray();
            }
            else
            {
                keys = keys2.ToArray();
            }

            return keys;
        }

        private void GetItineraryPriceAndSetPricesTest(InterJetAvailabilityUserInput userInput, InterJetSelectedFlights selectedFlights)
        {
            APIInterJet.InterJetClient client = new InterJetClient();

            APIInterJet.ItineraryPriceRequest req = new APIInterJet.ItineraryPriceRequest();

            req.SellByKeyRequest = new APIInterJet.SellJourneyByKeyRequestData();

            //req.SSRRequest = new APIInterJet.SSRRequest();
            //req.SSRRequest = this.GetSpecialServicePreviousPricingTestApi(userInput, selectedFlights.GetFlights());
            //req.SSRRequest.CurrencyCode = InterJetConstant.CurrencyCode == string.Empty ? "MXN" : InterJetConstant.CurrencyCode;

            req.PriceItineraryBy = APIInterJet.PriceItineraryBy.JourneyBySellKey;
            req.PriceJourneyWithLegsRequest = new APIInterJet.PriceJourneyRequestData();

            req.SellByKeyRequest.ActionStatusCode = InterJetConstant.ActionStatusCode;
            req.SellByKeyRequest.JourneySellKeys = GetSellKeyListFromTicketTestApi(selectedFlights.GetFlights()).ToList();
            req.SellByKeyRequest.PaxCount = userInput.PassangerCount;
            req.SellByKeyRequest.CurrencyCode = InterJetConstant.CurrencyCode;

            req.SellByKeyRequest.PaxPriceType = GetPaxPriceTypesApi(userInput);



            req.PriceItineraryBy = APIInterJet.PriceItineraryBy.JourneyBySellKey;

            #region tarifas

            List<Entities.InterJetFlight> flightReq = selectedFlights.GetFlights();
            APIInterJet.PriceSegment seg = new APIInterJet.PriceSegment();
            APIInterJet.SellFare sellFare = new APIInterJet.SellFare();
            APIInterJet.PriceJourney jo = new APIInterJet.PriceJourney();
            APIInterJet.PriceLeg priceLeg = new APIInterJet.PriceLeg();
            APIInterJet.Passenger passenger = new APIInterJet.Passenger();
            APIInterJet.PassengerTypeInfo passengetInfo = new APIInterJet.PassengerTypeInfo();
            req.PriceJourneyWithLegsRequest.PriceJourneys = new APIInterJet.PriceJourney[] { jo }.ToList();
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments = new APIInterJet.PriceSegment[] { seg }.ToList();
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].State = APIInterJet.MessageState1.New;
            //
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].ActionStatusCode = "SS";
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].ArrivalStation = flightReq[0].ArrivalStation;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].DepartureStation = flightReq[0].DepartureStation;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].STA = flightReq[0].ArrivalTime;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].STD = flightReq[0].DepartureTime;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs = new APIInterJet.PriceLeg[] { priceLeg }.ToList();

            req.PriceJourneyWithLegsRequest.PriceJourneys[0].State = APIInterJet.MessageState1.New;

            if (flightReq[0].FlightDesignator != null)
            {
                req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].FlightDesignator = new APIInterJet.FlightDesignator1
                {
                    CarrierCode = flightReq[0].FlightDesignator.CarrierCode,
                    FlightNumber = flightReq[0].FlightDesignator.FlightNumber,
                    OpSuffix = ""
                };

                req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].Fare = new APIInterJet.SellFare
                {
                    State = APIInterJet.MessageState1.New,
                    ClassOfService = flightReq[0].Fare.ClassOfService,
                    CarrierCode = flightReq[0].Fare.CarrierCode,
                    RuleNumber = flightReq[0].Fare.RuleNumber,
                    FareBasisCode = flightReq[0].Fare.FareBasisCode,
                    FareSequence = flightReq[0].Fare.FareSequence,
                    FareClassOfService = flightReq[0].Fare.FareClassOfService,
                    IsAllotmentMarketFare = false,
                    FareApplicationType = APIInterJet.FareApplicationType.Route,
                    ClassType = flightReq[0].Fare.ClassType,
                    RuleTariff = flightReq[0].Fare.RuleTariff

                };

                req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs[0].FlightDesignator = new APIInterJet.FlightDesignator1
                {
                    CarrierCode = flightReq[0].Fare.CarrierCode,
                    FlightNumber = flightReq[0].Information.FlightNumber,
                    OpSuffix = ""
                };

            }
            else
            {

                //List<APIInterJet.PriceSegment> lstprice = new APIInterJet.PriceSegment[] { seg }.ToList();

                req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments = new APIInterJet.PriceSegment[] { seg , seg, seg, seg }.ToList();
                for (int z = 0; z < flightReq[0].Segments.GetAll().Count; z++)
                {
                    req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[z].FlightDesignator = new APIInterJet.FlightDesignator1
                    {
                        CarrierCode = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.FlightDesignator.CarrierCode,
                        FlightNumber = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.FlightNumber,
                        OpSuffix = ""
                    };

                    req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[z].Fare = new APIInterJet.SellFare
                    {
                        State = APIInterJet.MessageState1.New,
                        ClassOfService = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.ClassOfService,
                        CarrierCode = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.CarrierCode,
                        RuleNumber = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.RuleNumber,
                        FareBasisCode = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.FareBasisCode,
                        FareSequence = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.FareSequence,
                        FareClassOfService = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.FareClassOfService,
                        IsAllotmentMarketFare = false,
                        FareApplicationType = APIInterJet.FareApplicationType.Route,
                        ClassType = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.ClassType,
                        RuleTariff = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.Fare.RuleTariff
                    };

                    req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[z].PriceLegs[0].FlightDesignator = new APIInterJet.FlightDesignator1
                    {
                        CarrierCode = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.FlightDesignator.CarrierCode,
                        FlightNumber = ((Entities.InterJetSegment)flightReq[0].Segments.GetAll()[z]).Information.FlightNumber,
                        OpSuffix = ""
                    };
                }
            }

            
            

            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs[0].State = APIInterJet.MessageState1.New;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs[0].ArrivalStation = flightReq[0].ArrivalStation;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs[0].DepartureStation = flightReq[0].DepartureStation;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs[0].STA = flightReq[0].ArrivalTime;
            req.PriceJourneyWithLegsRequest.PriceJourneys[0].Segments[0].PriceLegs[0].STD = flightReq[0].DepartureTime;

            

            req.PriceJourneyWithLegsRequest.Passengers = new APIInterJet.Passenger[] { passenger }.ToList();
            req.PriceJourneyWithLegsRequest.Passengers[0].State = APIInterJet.MessageState1.New;
            req.PriceJourneyWithLegsRequest.Passengers[0].PassengerNumber = 0;
            req.PriceJourneyWithLegsRequest.Passengers[0].FamilyNumber = 0;
            req.PriceJourneyWithLegsRequest.Passengers[0].PassengerID = 0;
            req.PriceJourneyWithLegsRequest.Passengers[0].PseudoPassenger = false;

            req.PriceJourneyWithLegsRequest.Passengers[0].PassengerTypeInfos = new APIInterJet.PassengerTypeInfo[] { passengetInfo }.ToList();
            req.PriceJourneyWithLegsRequest.Passengers[0].PassengerTypeInfos[0].State = APIInterJet.MessageState1.New;
            req.PriceJourneyWithLegsRequest.Passengers[0].PassengerTypeInfos[0].DOB = Convert.ToDateTime("0001-01-01T00:00:00");
            req.PriceJourneyWithLegsRequest.Passengers[0].PassengerTypeInfos[0].PaxType = "ADT";

            req.TypeOfSale = new APIInterJet.TypeOfSale();
            req.TypeOfSale.PaxResidentCountry = "MX";

            #endregion

            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(req.GetType());
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\GetItineraryPriceRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
            //writer.Serialize(file, req);
            //file.Close();

            APIInterJet.Booking booking = client.GetItineraryPrice(Contract, Signature, req);
            PriceTotalResponseInterjet.getItinearyPrice = booking.BookingSum.BalanceDue;

            //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(booking.GetType());
            //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\GetItineraryPriceResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
            //writer1.Serialize(file1, booking);
            //file1.Close();

            ListTaxesInterjet.BasePriceList = new List<decimal>();
            ListTaxesInterjet.TaxesList = new List<decimal>();
            ListTaxesInterjet.DiscountList = new List<decimal>();
            ListTaxesInterjet.TotalPrice = new List<decimal>();
            ListTaxesInterjet.turning = 0;
            int jorney = 0;

            foreach (var flight in selectedFlights.GetFlights())
            {
                flight.PreviousPrincig = new MyCTS.Entities.InterJetPreviousPricing();
                flight.PreviousPrincig.Adult = new MyCTS.Entities.InterJetPassangerPreviousPricing();
                flight.PreviousPrincig.Senior = new MyCTS.Entities.InterJetPassangerPreviousPricing();
                flight.PreviousPrincig.Child = new MyCTS.Entities.InterJetPassangerPreviousPricing();
                flight.PreviousPrincig.Infant = new MyCTS.Entities.InterJetPassangerPreviousPricing();

                flight.PreviousPrincig.Adult.TotalPax = userInput.AdultsPassangers;
                flight.PreviousPrincig.Senior.TotalPax = userInput.SeniorsPassangers;
                flight.PreviousPrincig.Child.TotalPax = userInput.ChildsPassangers;
                flight.PreviousPrincig.Infant.TotalPax = userInput.InfantsPassangers;
                SetPreviousFlightPricingTest(flight, booking, jorney);
                jorney++;
            }
        }

        private List<APIInterJet.PaxPriceType> GetPaxPriceTypesApi(InterJetAvailabilityUserInput userInput)
        {
            var passangerPriceTypes = new List<APIInterJet.PaxPriceType>();
            if (userInput.HasAdultsPassangers)
            {
                passangerPriceTypes.AddRange(this.GetPaxPriceTypesApi("ADT", userInput.AdultsPassangers));
            }

            if (userInput.HasChildrenPassangers)
            {
                passangerPriceTypes.AddRange(this.GetPaxPriceTypesApi("CHD", userInput.ChildsPassangers));
            }
            if (userInput.HasSeniorsPassangers)
            {
                passangerPriceTypes.AddRange(this.GetPaxPriceTypesApi("SRC", userInput.SeniorsPassangers));
            }
            return passangerPriceTypes.ToList();


        }

        private List<APIInterJet.PaxPriceType> GetPaxPriceTypesApi(string paxType, int numbersOfPassangers)
        {
            var passangerTypes = new List<APIInterJet.PaxPriceType>();
            for (int passangerCount = 0; passangerCount < numbersOfPassangers; passangerCount++)
            {
                var passangerType = new APIInterJet.PaxPriceType
                {
                    PaxType = paxType
                };
                passangerTypes.Add(passangerType);
                passangerType.PaxDiscountCode = "INET";

            }

            return passangerTypes;
        }

        /// <summary>
        /// Gets the itinerary price.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        /// <param name="selectedFlights">The selected flights.</param>
        private void GetItineraryPriceAndSetPrices(InterJetAvailabilityUserInput userInput, InterJetSelectedFlights selectedFlights)
        {
            var bookingClient = this.CreateBookingManager();
            try
            {
                foreach (var flight in selectedFlights.GetFlights())
                {
                    var itineraryPriceRequest = new bookingManager.ItineraryPriceRequest
                    {
                        SellByKeyRequest = new bookingManager.SellJourneyByKeyRequestData(),
                        SSRRequest = new bookingManager.SSRRequest(),
                        PriceItineraryBy = bookingManager.PriceItineraryBy.JourneyBySellKey

                    };
                    itineraryPriceRequest.SellByKeyRequest.PaxCount = userInput.PassangerCount;
                    itineraryPriceRequest.SSRRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                    itineraryPriceRequest.SellByKeyRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                    itineraryPriceRequest.SellByKeyRequest.ActionStatusCode = InterJetConstant.ActionStatusCode;
                    itineraryPriceRequest.SellByKeyRequest.PaxPriceType = this.GetPaxPriceTypes(userInput);
                    itineraryPriceRequest.SellByKeyRequest.JourneySellKeys = GetSellKeyListFromTicket(flight);
                    itineraryPriceRequest.SSRRequest = this.GetSpecialServicePreviousPricing(userInput, flight);
                    itineraryPriceRequest.TypeOfSale = new bookingManager.TypeOfSale();
                    itineraryPriceRequest.TypeOfSale.PaxResidentCountry = "MX";
                    Serializer.Serialize("GetItineraryPriceRequest", itineraryPriceRequest);

                    //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(itineraryPriceRequest.GetType());
                    //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer1.Serialize(file1, itineraryPriceRequest);
                    //file1.Close();

                    bookingManager.Booking booking = bookingClient.GetItineraryPrice(Contract, Signature,
                                                                                    itineraryPriceRequest);

                    PriceTotalResponseInterjet.getItinearyPrice = booking.BookingSum.BalanceDue;

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(booking.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\GetItineraryPriceResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, itineraryPriceRequest);
                    //file.Close();



                    Serializer.Serialize("GetItineraryPriceResponse", booking);
                    flight.PreviousPrincig = new MyCTS.Entities.InterJetPreviousPricing();
                    flight.PreviousPrincig.Adult = new MyCTS.Entities.InterJetPassangerPreviousPricing();
                    flight.PreviousPrincig.Senior = new MyCTS.Entities.InterJetPassangerPreviousPricing();
                    flight.PreviousPrincig.Child = new MyCTS.Entities.InterJetPassangerPreviousPricing();
                    flight.PreviousPrincig.Infant = new MyCTS.Entities.InterJetPassangerPreviousPricing();

                    flight.PreviousPrincig.Adult.TotalPax = userInput.AdultsPassangers;
                    flight.PreviousPrincig.Senior.TotalPax = userInput.SeniorsPassangers;
                    flight.PreviousPrincig.Child.TotalPax = userInput.ChildsPassangers;
                    flight.PreviousPrincig.Infant.TotalPax = userInput.InfantsPassangers;
                    SetPreviousFlightPricing(flight, booking);

                }
                bookingClient.Close();
            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {

                    throw new TimeoutException("");
                }
                throw;

            }

        }

        /// <summary>
        /// Sets the previous flight pricing.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <param name="booking">The booking.</param>
        private void SetPreviousFlightPricing(MyCTS.Entities.InterJetFlight flight, bookingManager.Booking booking)
        {

            SetPreviousPaxPrice(booking, flight.PreviousPrincig.Adult, "ADT");
            SetPreviousPaxPrice(booking, flight.PreviousPrincig.Senior, "SRC");
            SetPreviousPaxPrice(booking, flight.PreviousPrincig.Child, "CHD");
            //SetPreviousInfantPaxPrice(booking, flight.PreviousPrincig.Infant);
        }

        private void SetPreviousFlightPricingTest(MyCTS.Entities.InterJetFlight flight, APIInterJet.Booking booking, int jorney)
        {
            SetPreviousPaxPriceTest(booking, flight.PreviousPrincig.Adult, "ADT", jorney);
            SetPreviousPaxPriceTest(booking, flight.PreviousPrincig.Senior, "SRC", jorney);
            SetPreviousPaxPriceTest(booking, flight.PreviousPrincig.Child, "CHD", jorney);
            SetPreviousInfantPaxPrice(booking, flight.PreviousPrincig.Infant);
        }

        private void SetPreviousPaxPriceTest(APIInterJet.Booking booking, MyCTS.Entities.InterJetPassangerPreviousPricing paxPreviousPrince, string paxType, int jn)
        {
            decimal baseP = 0;
            decimal taxP = 0;
            decimal discountP = 0;
            int seg = 0;

            if (booking != null)
            {
                if (booking.Journeys.Any())
                {
                    var journey = booking.Journeys[jn];
                    if (journey != null)
                    {
                        for (int j = 0; j < booking.Journeys[jn].Segments.Count(); j++)
                        {
                            var segment = journey.Segments[j];
                            if (segment != null)
                            {

                                if (segment.Fares.Any())
                                {
                                    var paxFares = segment.Fares.SelectMany(f => f.PaxFares);

                                    if (paxFares.Any())
                                    {

                                        var serviceOfCharge =
                                            paxFares.Where(paxFare => paxFare.PaxType.Equals(paxType)).SelectMany(
                                                s => s.ServiceCharges);


                                        if (serviceOfCharge.Any())
                                        {

                                            decimal basePrice =
                                                serviceOfCharge.Where(s => s.ChargeType == APIInterJet.ChargeType1.FarePrice).Sum(
                                                    s => s.Amount);

                                            decimal taxes =
                                                serviceOfCharge.Where(s => s.ChargeType == APIInterJet.ChargeType1.Tax).Sum(
                                                    s => s.Amount);

                                            decimal disccount =
                                                serviceOfCharge.Where(s => s.ChargeType == APIInterJet.ChargeType1.Discount).Sum(
                                                    s => s.Amount);


                                            paxPreviousPrince.BasePrice = paxPreviousPrince.BasePrice + basePrice;
                                            paxPreviousPrince.Taxes = paxPreviousPrince.Taxes + taxes;
                                            paxPreviousPrince.Discount = paxPreviousPrince.Discount + disccount;

                                            if (seg == 2)
                                            {
                                                baseP = 0;
                                                taxP = 0;
                                                discountP = 0;
                                            }

                                            baseP = baseP + basePrice;
                                            taxP = taxP + taxes;
                                            discountP = discountP + disccount;
                                            seg++;
                                        }

                                    }

                                }

                            }
                        }
                        if (baseP != 0)
                        {
                            ListTaxesInterjet.BasePriceList.Add(baseP);
                            ListTaxesInterjet.TaxesList.Add(taxP);
                            ListTaxesInterjet.DiscountList.Add(discountP);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the previous infant pax price.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <param name="paxPreviousPrince">The pax previous prince.</param>
        private void SetPreviousInfantPaxPrice(APIInterJet.Booking booking, MyCTS.Entities.InterJetPassangerPreviousPricing paxPreviousPrince)
        {
            if (booking != null)
            {

                if (booking.Passengers.Any())
                {
                    var passangersFees = booking.Passengers.SelectMany(pax => pax.PassengerFees);
                    if (passangersFees.Any())
                    {
                        var servicesOfCharge = passangersFees.SelectMany(fee => fee.ServiceCharges);
                        if (servicesOfCharge.Any())
                        {
                            decimal total = servicesOfCharge.Sum(s => s.Amount);
                            paxPreviousPrince.BasePrice = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the pax price.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <param name="paxPreviousPrince">The pax previous prince.</param>
        /// <param name="paxType">Type of the pax.</param>
        private void SetPreviousPaxPrice(bookingManager.Booking booking, MyCTS.Entities.InterJetPassangerPreviousPricing paxPreviousPrince, string paxType)
        {
            if (booking != null)
            {
                if (booking.Journeys.Any())
                {
                    for (int q = 0; q < booking.Journeys.Count(); q++)
                    {
                        var journey = booking.Journeys[q];
                        if (journey != null)
                        {
                            for (int j = 0; j < booking.Journeys[q].Segments.Count(); j++)
                            {
                                var segment = journey.Segments[j];
                                if (segment != null)
                                {

                                    if (segment.Fares.Any())
                                    {
                                        var paxFares = segment.Fares.SelectMany(f => f.PaxFares);

                                        if (paxFares.Any())
                                        {

                                            var serviceOfCharge =
                                                paxFares.Where(paxFare => paxFare.PaxType.Equals(paxType)).SelectMany(
                                                    s => s.ServiceCharges);


                                            if (serviceOfCharge.Any())
                                            {

                                                decimal basePrice =
                                                    serviceOfCharge.Where(s => s.ChargeType == bookingManager.ChargeType.FarePrice).Sum(
                                                        s => s.Amount);

                                                decimal taxes =
                                                    serviceOfCharge.Where(s => s.ChargeType == bookingManager.ChargeType.Tax).Sum(
                                                        s => s.Amount);

                                                decimal disccount =
                                                    serviceOfCharge.Where(s => s.ChargeType == bookingManager.ChargeType.Discount).Sum(
                                                        s => s.Amount);
                                                paxPreviousPrince.BasePrice = paxPreviousPrince.BasePrice + basePrice;
                                                paxPreviousPrince.Taxes = paxPreviousPrince.Taxes + taxes;
                                                paxPreviousPrince.Discount = paxPreviousPrince.Discount + disccount;

                                            }

                                        }

                                    }

                                }
                            }
                        }
                    }

                }
            }

        }

        /// <summary>
        /// Gets the itinerary price for nationals.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        private decimal GetItineraryPriceForNationals(MyCTS.Entities.InterJetTicket ticket)
        {
            var bookingClient = this.CreateBookingManager();
            try
            {
                bool hasFlights = ticket.Flights.GetAllFlights().Where(f => !f.IsInternational).ToList().Any();
                if (hasFlights)
                {
                    var itineraryPriceRequest = new bookingManager.ItineraryPriceRequest
                    {
                        SellByKeyRequest = new bookingManager.SellJourneyByKeyRequestData(),
                        SSRRequest = this.GetSpecialService(ticket, false),
                        TypeOfSale = new bookingManager.TypeOfSale()
                    };
                    itineraryPriceRequest.SSRRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                    itineraryPriceRequest.PriceItineraryBy = bookingManager.PriceItineraryBy.JourneyBySellKey;
                    itineraryPriceRequest.SellByKeyRequest.PaxCount = ticket.Passangers.Total;
                    itineraryPriceRequest.SellByKeyRequest.PaxPriceType = this.GetPaxPricesTypeFormTicket(ticket);
                    itineraryPriceRequest.SellByKeyRequest.JourneySellKeys = this.GetSellKeyListFromTicket(ticket, false);
                    itineraryPriceRequest.SellByKeyRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                    itineraryPriceRequest.SellByKeyRequest.ActionStatusCode = InterJetConstant.ActionStatusCode;
                    Serializer.Serialize("", null);
                    var pax = ticket.Passangers.GetAll().FirstOrDefault();
                    string residenty = "OC";
                    if (pax != null)
                    {
                        residenty = pax.Nationality;

                    }
                    itineraryPriceRequest.TypeOfSale = new bookingManager.TypeOfSale();
                    itineraryPriceRequest.TypeOfSale.PaxResidentCountry = "MX";

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(itineraryPriceRequest.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, itineraryPriceRequest);
                    //file.Close();

                    Serializer.Serialize("GetItineraryPriceRequestNationals", itineraryPriceRequest);


                    bookingManager.Booking booking = bookingClient.GetItineraryPrice(Contract, Signature,
                                                                                    itineraryPriceRequest);
                    PriceTotalResponseInterjet.getItinearyPrice = booking.BookingSum.BalanceDue;

                    //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(booking.GetType());
                    //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer1.Serialize(file1, booking);
                    //file1.Close();




                    Serializer.Serialize("GetItineraryPriceResponseNationals", booking);
                    this.SetFlightsTaxes(ticket, ticket.Flights.GetAllFlights().Where(f => !f.IsInternational).ToList(),
                                         booking);
                    bookingClient.Close();
                    return booking.BookingSum.TotalCost;
                }
            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");

                }
                throw;
            }
            return 0;
        }

        /// <summary>
        /// Gets the itinerary price for iternationationals.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        private decimal GetItineraryPriceForIternationationals(MyCTS.Entities.InterJetTicket ticket)
        {
            var bookingClient = this.CreateBookingManager();
            try
            {
                bool hasFlights = ticket.Flights.GetAllFlights().Where(f => f.IsInternational).ToList().Any();
                if (hasFlights)
                {
                    var itineraryPriceRequest = new bookingManager.ItineraryPriceRequest();

                    itineraryPriceRequest.SellByKeyRequest = new bookingManager.SellJourneyByKeyRequestData();
                    itineraryPriceRequest.SSRRequest = new bookingManager.SSRRequest();
                    itineraryPriceRequest.SSRRequest = this.GetSpecialService(ticket, true);
                    itineraryPriceRequest.SSRRequest.CurrencyCode = InterJetConstant.CurrencyCode;

                    itineraryPriceRequest.PriceItineraryBy = bookingManager.PriceItineraryBy.JourneyBySellKey;
                    itineraryPriceRequest.SellByKeyRequest.PaxCount = ticket.Passangers.Total;
                    itineraryPriceRequest.SellByKeyRequest.PaxPriceType = this.GetPaxPricesTypeFormTicket(ticket);
                    itineraryPriceRequest.SellByKeyRequest.JourneySellKeys = this.GetSellKeyListFromTicket(ticket, true);
                    itineraryPriceRequest.SellByKeyRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                    itineraryPriceRequest.SellByKeyRequest.ActionStatusCode = InterJetConstant.ActionStatusCode;

                    var pax = ticket.Passangers.GetAll().FirstOrDefault();
                    string residenty = "OC";
                    if (pax != null)
                    {
                        residenty = pax.Nationality;

                    }
                    itineraryPriceRequest.TypeOfSale = new bookingManager.TypeOfSale();
                    itineraryPriceRequest.TypeOfSale.PaxResidentCountry = "MX";

                    Serializer.Serialize("GetItineraryPriceRequestInternationals", itineraryPriceRequest);

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(itineraryPriceRequest.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, itineraryPriceRequest);
                    //file.Close();

                    bookingManager.Booking booking = bookingClient.GetItineraryPrice(Contract, Signature,
                                                                                    itineraryPriceRequest);
                    PriceTotalResponseInterjet.getItinearyPrice = booking.BookingSum.BalanceDue;

                    //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(booking.GetType());
                    //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\itineraryPriceResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer1.Serialize(file1, booking);
                    //file1.Close();

                    Serializer.Serialize("GetItineraryPriceResponseInternationals", booking);
                    this.SetFlightsTaxes(ticket, ticket.Flights.GetAllFlights().Where(f => f.IsInternational).ToList(),
                                         booking);
                    bookingClient.Close();
                    return booking.BookingSum.TotalCost;
                }
            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");

                }
                throw;
            }
            return 0;
        }

        private InterJetTaxBL _taxesService;

        /// <summary>
        /// Gets the taxes services.
        /// </summary>
        private InterJetTaxBL TaxesServices
        {
            get
            {
                return _taxesService ?? (_taxesService = new InterJetTaxBL());
            }
        }

        /// <summary>
        /// Sets the detail price.
        /// </summary>
        /// <param name="journey">The journey.</param>
        /// <param name="flight">The flight.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="paxType">Type of the pax.</param>
        private void SetDetailPrice(bookingManager.Journey journey, MyCTS.Entities.InterJetFlight flight, MyCTS.Entities.InterJetPassangerDetailPrice detail, string paxType)
        {

            detail.BasePrice = this.GetPriceFromBooking(journey, paxType, "FarePrice", bookingManager.ChargeType.FarePrice);
            detail.Discount = this.GetPriceFromBooking(journey, paxType, "Discount", bookingManager.ChargeType.Discount);
            detail.IVA = this.GetPriceFromBooking(journey, paxType, "IVA", bookingManager.ChargeType.Tax);
            detail.TUA = this.GetPriceFromBooking(journey, paxType, "TUA", bookingManager.ChargeType.Tax);
            detail.ExtraTaxes = this.GetPriceFromBooking(journey, paxType, "ExtraTaxes", bookingManager.ChargeType.Tax);

            if (detail.BasePrice != 0 && ListTaxesInterjet.Conexion)
            {
                ListTaxesInterjet.BasePriceList.Add(detail.BasePrice);
                ListTaxesInterjet.DiscountList.Add(detail.Discount);
                ListTaxesInterjet.IVA.Add(detail.IVA);
                ListTaxesInterjet.TUA.Add(detail.TUA);
                ListTaxesInterjet.Extras.Add(detail.ExtraTaxes);
            }
            detail.Flight = flight;
        }

        /// <summary>
        /// TODO: Verificar los impuestos extras por infante extra.
        /// Sets the extra charge for infants.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="paxType">Type of the pax.</param>
        /// <param name="booking">The booking.</param>
        private void SetExtraChargeForInfants(MyCTS.Entities.InterJetFlight flight, MyCTS.Entities.InterJetPassangerDetailPrice detail, string paxType, bookingManager.Booking booking)
        {

            var passangers =
                booking.Passengers.Where(
                    pax =>
                    pax.PassengerFees.Any() &&
                    pax.PassengerTypeInfos.FirstOrDefault(p => p.PaxType.Equals(paxType)) != null);


            if (passangers.Any())
            {
                var passengersFees =
                    booking.Passengers
                    .Where(pax => pax.PassengerFees.Any() && pax.PassengerTypeInfos.FirstOrDefault(p => p.PaxType.Equals(paxType)) != null)
                    .SelectMany(pax => pax.PassengerFees);
                if (passengersFees.Any())
                {
                    string itineraryString = string.Format("{0}{1}", flight.DepartureStation, flight.ArrivalStation);
                    var servicesOfCharge =
                       passengersFees.Where(p => p.ServiceCharges.Any() && p.FlightReference.Contains(itineraryString)).SelectMany(p => p.ServiceCharges);

                    if (servicesOfCharge != null)
                    {
                        detail.ExtraChargeForInfant = servicesOfCharge.Where(s => s.ChargeType == bookingManager.ChargeType.ServiceCharge).Sum(s => s.Amount);


                    }


                }


            }
        }

        /// <summary>
        /// Sets the flights taxes.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flights">The flights.</param>
        /// <param name="booking">The booking.</param>
        private void SetFlightsTaxes(MyCTS.Entities.InterJetTicket ticket, IEnumerable<MyCTS.Entities.InterJetFlight> flights, bookingManager.Booking booking)
        {

            ListTaxesInterjet.BasePriceList = new List<decimal>();
            ListTaxesInterjet.DiscountList = new List<decimal>();
            ListTaxesInterjet.IVA = new List<decimal>();
            ListTaxesInterjet.TUA = new List<decimal>();
            ListTaxesInterjet.Extras = new List<decimal>();
            ListTaxesInterjet.turning = 0;
            ListTaxesInterjet.turningTaxes = 0;
            ListTaxesInterjet.Fligth = 0;
            ListTaxesInterjet.turn = 0;
            string impuestos = string.Empty;
            taxes = string.Empty;

            #region "Calculo de vuelos internacionales"
            foreach (MyCTS.Entities.InterJetFlight flight in flights)
            {
                foreach (var journey in booking.Journeys)
                {
                    if (ListTaxesInterjet.Conexion)
                    {
                        flight.PriceDetail = new MyCTS.Entities.InterJetFlightDetailPrice();

                        flight.PriceDetail.Adult = new MyCTS.Entities.InterJetPassangerDetailPrice();
                        this.SetDetailPrice(journey, flight, flight.PriceDetail.Adult, "ADT");

                        flight.PriceDetail.Child = new MyCTS.Entities.InterJetPassangerDetailPrice();
                        this.SetDetailPrice(journey, flight, flight.PriceDetail.Child, "CHD");

                        flight.PriceDetail.Senior = new MyCTS.Entities.InterJetPassangerDetailPrice();
                        this.SetDetailPrice(journey, flight, flight.PriceDetail.Senior, "SRC");

                    }
                    else
                    {
                        if (flight.JourneySellKey.Equals(journey.JourneySellKey))
                        {
                            flight.PriceDetail = new MyCTS.Entities.InterJetFlightDetailPrice();

                            flight.PriceDetail.Adult = new MyCTS.Entities.InterJetPassangerDetailPrice();
                            this.SetDetailPrice(journey, flight, flight.PriceDetail.Adult, "ADT");

                            flight.PriceDetail.Child = new MyCTS.Entities.InterJetPassangerDetailPrice();
                            this.SetDetailPrice(journey, flight, flight.PriceDetail.Child, "CHD");

                            flight.PriceDetail.Senior = new MyCTS.Entities.InterJetPassangerDetailPrice();
                            this.SetDetailPrice(journey, flight, flight.PriceDetail.Senior, "SRC");

                        }
                    }
                }

                #region Calculo de Impuestos Adultos.

                bool IsInfantChargeOfServiceSet = false;
                if (ticket.Passangers.HasAdults)
                {

                    int numberOfAdults = ticket.Passangers.TotalAdults;

                    if (ListTaxesInterjet.roud && ListTaxesInterjet.Conexion)
                    {
                        flight.PriceDetail.Adult.BasePrice = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turn] * numberOfAdults;
                        flight.PriceDetail.Adult.IVA = ListTaxesInterjet.IVA[ListTaxesInterjet.turn] * numberOfAdults;
                        flight.PriceDetail.Adult.TUA = ListTaxesInterjet.TUA[ListTaxesInterjet.turn] * numberOfAdults;
                        flight.PriceDetail.Adult.Discount = ListTaxesInterjet.DiscountList[ListTaxesInterjet.turn] * numberOfAdults;
                        flight.PriceDetail.Adult.ExtraTaxes = ListTaxesInterjet.Extras[ListTaxesInterjet.turn] * numberOfAdults;
                        ListTaxesInterjet.turn = ListTaxesInterjet.turn + 1;
                    }
                    else
                    {
                        if (flight.Information.PriceDecimal != 0)
                        {
                            flight.PriceDetail.Adult.BasePrice = flight.Information.PriceDecimal * numberOfAdults;
                        }
                        else
                        {
                            flight.PriceDetail.Adult.BasePrice = flight.PriceDetail.Adult.BasePrice * numberOfAdults;
                        }
                        flight.PriceDetail.Adult.IVA = flight.PriceDetail.Adult.IVA * numberOfAdults;
                        flight.PriceDetail.Adult.TUA = flight.PriceDetail.Adult.TUA * numberOfAdults;
                        flight.PriceDetail.Adult.Discount = flight.PriceDetail.Adult.Discount * numberOfAdults;
                        flight.PriceDetail.Adult.ExtraTaxes = flight.PriceDetail.Adult.ExtraTaxes * numberOfAdults;

                    }
                    //recordar quitar todo lo de impuestos
                    //impuestos = string.Empty;
                    //impuestos = impuestos + "ADT " + flight.PriceDetail.Adult.BasePrice.ToString("#.00") + " " + flight.PriceDetail.Adult.IVA.ToString("#.00")
                    //+ " " + flight.PriceDetail.Adult.TUA.ToString("#.00") + " " + flight.PriceDetail.Adult.Discount.ToString("#.00")
                    //+ " " + flight.PriceDetail.Adult.ExtraTaxes.ToString("#.00");
                    //SetExtraChargeForInfants(flight, flight.PriceDetail.Adult, "ADT", booking);
                }
                #endregion

                #region Calculo impuestos niños
                if (ticket.Passangers.HasChildren)
                {
                    int numbersOfChildren = ticket.Passangers.TotalChildren;
                    if (ListTaxesInterjet.roud && ListTaxesInterjet.Conexion)
                    {
                        flight.PriceDetail.Child.BasePrice = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turn] * numbersOfChildren;
                        flight.PriceDetail.Child.IVA = ListTaxesInterjet.IVA[ListTaxesInterjet.turn] * numbersOfChildren;
                        flight.PriceDetail.Child.TUA = ListTaxesInterjet.TUA[ListTaxesInterjet.turn] * numbersOfChildren;
                        flight.PriceDetail.Child.Discount = ListTaxesInterjet.DiscountList[ListTaxesInterjet.turn] * numbersOfChildren;
                        flight.PriceDetail.Child.ExtraTaxes = ListTaxesInterjet.Extras[ListTaxesInterjet.turn] * numbersOfChildren;
                        ListTaxesInterjet.turn = ListTaxesInterjet.turn + 1;
                    }
                    else
                    {
                        flight.PriceDetail.Child.BasePrice = flight.Information.PriceDecimal * numbersOfChildren;
                        flight.PriceDetail.Child.IVA = flight.PriceDetail.Child.IVA * numbersOfChildren;
                        flight.PriceDetail.Child.TUA = flight.PriceDetail.Child.TUA * numbersOfChildren;
                        flight.PriceDetail.Child.Discount = flight.PriceDetail.Child.Discount * numbersOfChildren;
                        flight.PriceDetail.Child.ExtraTaxes = flight.PriceDetail.Child.ExtraTaxes * numbersOfChildren;
                    }

                    impuestos = impuestos + "CHD" + flight.PriceDetail.Child.BasePrice.ToString("#.00") + " " + flight.PriceDetail.Child.IVA.ToString("#.00")
                    + " " + flight.PriceDetail.Child.TUA.ToString("#.00") + " " + flight.PriceDetail.Child.Discount.ToString("#.00")
                    + " " + flight.PriceDetail.Child.ExtraTaxes.ToString("#.00");

                }
                #endregion

                #region Calculo Seniors
                if (ticket.Passangers.HasSeniorAdult)
                {
                    int numberOfSeniors = ticket.Passangers.TotalSenior;
                    if (ListTaxesInterjet.roud && ListTaxesInterjet.Conexion)
                    {
                        flight.PriceDetail.Senior.BasePrice = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turn] * numberOfSeniors;
                        flight.PriceDetail.Senior.IVA = ListTaxesInterjet.IVA[ListTaxesInterjet.turn] * numberOfSeniors;
                        flight.PriceDetail.Senior.TUA = ListTaxesInterjet.TUA[ListTaxesInterjet.turn] * numberOfSeniors;
                        flight.PriceDetail.Senior.Discount = ListTaxesInterjet.DiscountList[ListTaxesInterjet.turn] * numberOfSeniors;
                        flight.PriceDetail.Senior.ExtraTaxes = ListTaxesInterjet.Extras[ListTaxesInterjet.turn] * numberOfSeniors;
                        ListTaxesInterjet.turn = ListTaxesInterjet.turn + 1;

                    }
                    else
                    {
                        flight.PriceDetail.Senior.BasePrice = flight.Information.PriceDecimal * numberOfSeniors;
                        flight.PriceDetail.Senior.IVA = flight.PriceDetail.Senior.IVA * numberOfSeniors;
                        flight.PriceDetail.Senior.TUA = flight.PriceDetail.Senior.TUA * numberOfSeniors;
                        flight.PriceDetail.Senior.Discount = flight.PriceDetail.Senior.Discount * numberOfSeniors;
                        flight.PriceDetail.Senior.ExtraTaxes = flight.PriceDetail.Senior.ExtraTaxes * numberOfSeniors;

                    }
                    SetExtraChargeForInfants(flight, flight.PriceDetail.Senior, "SRC", booking);

                    impuestos = impuestos + "SRC" + flight.PriceDetail.Senior.BasePrice.ToString("#.00") + " " + flight.PriceDetail.Senior.IVA.ToString("#.00")
                    + " " + flight.PriceDetail.Senior.TUA.ToString("#.00") + " " + flight.PriceDetail.Senior.Discount.ToString("#.00")
                    + " " + flight.PriceDetail.Senior.ExtraTaxes.ToString("#.00");

                }
                #endregion

                //Recordar quitar
                Guid g = Guid.NewGuid();
                ImpuestosBajoCosto.Id = g.ToString();
                ImpuestosBajoCosto.ImpuestosObtenidos = taxes;
                ImpuestosBajoCostoBL.InsertImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, string.Empty, string.Empty, string.Empty, string.Empty);
            }
            #endregion
        }

        public decimal SeeNumber()
        {
            decimal amount = 0;
            try
            {
                IInterJet cliente = new InterJetClient();
                amount = cliente.SeeNumber(Contract, Signature, CostumerAccountInterJet.NumberPurche);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amount;
        }

        public void Confirmation(string pnr)
        {
            try
            {
                IInterJet cliente = new InterJetClient();
                cliente.Confirmation(Signature, Contract, pnr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<APIInterJet.GetSeatAvailabilityResponse> GetAvailabilitySeat(List<MyCTS.Entities.InterJetFlight> flights)
        {
            try
            {
                List<APIInterJet.GetSeatAvailabilityResponse> assing = null;
                IInterJet cliente = new InterJetClient();
                List<MyCTS.Services.APIInterJet.InterJetFlight> flight = DataFlight(flights);

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(flight.GetType());
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\GetAvailabilitySeatRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file, flight);
                //file.Close();

                assing = cliente.GetSeatAvailabilityWSList(Contract, Signature, flight, seg);

                //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(assing.GetType());
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\GetAvailabilitySeatResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file1, assing);
                //file1.Close();

                return assing;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MyCTS.Services.APIInterJet.AssignSeatsResponse AssingSeat(List<MyCTS.Entities.InterJetFlight> flights, List<string> passengers)
        {
            try
            {
                IInterJet cliente = new InterJetClient();
                MyCTS.Services.APIInterJet.AssignSeatsResponse seat = new MyCTS.Services.APIInterJet.AssignSeatsResponse();
                List<MyCTS.Services.APIInterJet.InterJetFlight> flight = DataFlight(flights);

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(flight.GetType());
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\AssingSeatRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file, flight);
                //file.Close();

                return cliente.AssingSeatWS(Contract, Signature, flight, seg, passengers);

                //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(flight.GetType());
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\AssingSeatResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer1.Serialize(file1, flight);
                //file1.Close();

                if (seat.BookingUpdateResponseData.Success.PNRAmount.SegmentCount > 0)
                    ImpuestosBajoCosto.continuePayment = true;
                else
                    ImpuestosBajoCosto.continuePayment = false;

                return seat;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MyCTS.Services.APIInterJet.InterJetFlight> DataFlight(List<MyCTS.Entities.InterJetFlight> flights)
        {
            List<MyCTS.Services.APIInterJet.InterJetFlight> flight = new List<APIInterJet.InterJetFlight>();
            MyCTS.Services.APIInterJet.InterJetFlight flig;

            foreach (MyCTS.Entities.InterJetFlight f in flights)
            {
                flig = new APIInterJet.InterJetFlight();
                flig.ArrivalDateTime = f.ArrivalDateTime;
                flig.ArrivalStation = f.ArrivalStation;
                flig.ArrivalTime = f.ArrivalTime;
                flig.BasePrice = f.BasePrice;
                flig.DepartureStation = f.DepartureStation;
                flig.DepartureTime = f.DepartureTime;
                flig.ExtraChargeForInfant = f.ExtraChargeForInfant;

                seg = f.Segments.GetAll().Count();
                flig.Fare = new APIInterJet.InterJetFare();
                flig.FlightDesignator = new APIInterJet.InterJetFlightDesignator();
                flig.Information = new APIInterJet.InterJetFlightInformation();
                flig.Information.Fare = new APIInterJet.InterJetFare();

                if (seg == 1)
                {
                    flig.Fare.CarrierCode = f.Fare.CarrierCode;
                    flig.Fare.ClassOfService = f.Fare.ClassOfService;
                    flig.Fare.ClassType = f.Fare.ClassType;
                    flig.Fare.FareBasisCode = f.Fare.FareBasisCode;
                    flig.Fare.FareClassOfService = f.Fare.FareClassOfService;
                    flig.Fare.FareSequence = f.Fare.FareSequence;
                    flig.Fare.RuleNumber = f.Fare.RuleNumber;
                    flig.Fare.RuleTariff = f.Fare.RuleTariff;
                    flig.FareSellKey = f.FareSellKey;

                    flig.FlightDesignator.CarrierCode = f.FlightDesignator.CarrierCode.ToString();
                    flig.FlightDesignator.FlightNumber = f.FlightDesignator.FlightNumber;

                    flig.Information.Fare.CarrierCode = f.Information.Fare.CarrierCode;
                    flig.Information.Fare.ClassOfService = f.Information.Fare.ClassOfService;
                    flig.Information.Fare.FareBasisCode = f.Information.Fare.FareBasisCode;
                    flig.Information.Fare.FareClassOfService = f.Information.Fare.FareClassOfService;
                    flig.Information.Fare.FareSequence = f.Information.Fare.FareSequence;
                    flig.Information.Fare.RuleNumber = f.Information.Fare.RuleNumber;
                    flig.Information.Fare.RuleTariff = f.Information.Fare.RuleTariff;
                }
                flig.ID = f.ID;
                flig.FlightNumber = f.FlightNumber;
                flig.Price = f.Price.Replace('$', ' ').Trim();

                flig.Information.Arrival = f.Information.Arrival;
                flig.Information.ArrivalStation = f.Information.ArrivalStation;
                flig.Information.ClassOfService = f.Information.ClassOfService;
                flig.Information.Departure = f.Information.Departure;
                flig.Information.DepartureStation = f.Information.DepartureStation;



                flig.IsInternational = f.IsInternational;
                flig.IsRoundTrip = f.IsRoundTrip;
                flig.IsSelected = f.IsSelected;
                flig.IsSingleTrip = f.IsSingleTrip;
                flig.JourneySellKey = f.JourneySellKey;
                flig.OwnerCompany = f.OwnerCompany;

                flig.Ticket = new APIInterJet.InterJetTicket();
                flig.Ticket.Passangers = new APIInterJet.InterJetPassangers();
                flig.Ticket.Passangers.Total = f.Ticket.Passangers.Total;

                if (seg == 2)
                {
                    flig.Segments = new APIInterJet.Segments();

                    flig.Segments._segments = new List<APIInterJet.ISegment>();
                    for (int a = 0; a < seg; a++)
                    {
                        APIInterJet.ISegment segmentSon = new APIInterJet.ISegment();

                        Entities.InterJetSegment se = new Entities.InterJetSegment();

                        List<Entities.ISegment> listOfSegments = f.Segments.GetAll();

                        segmentSon.ID = ((Entities.InterJetSegment)listOfSegments[a]).Information.FlightDesignator.FlightNumber + "|" + ((Entities.InterJetSegment)listOfSegments[a]).Information.FlightDesignator.CarrierCode;
                        segmentSon.DepartureTime = listOfSegments[a].DepartureTime;
                        segmentSon.DepartureStation = listOfSegments[a].DepartureStation;
                        segmentSon.ArrivalStation = listOfSegments[a].ArrivalStation;
                        segmentSon.ArrivalTime = listOfSegments[a].ArrivalTime;
                        segmentSon.Type = APIInterJet.SegmentType.Connection;

                        flig.Segments._segments.Add(segmentSon);
                    }
                    flig.Segments.GetAll = flig.Segments._segments;
                }
                flig.Tax = f.Tax;
                flig.TotalPrice = f.TotalPrice;

                flight.Add(flig);
            }

            return flight;
        }


        /// <summary>
        /// Gets the extra taxes.
        /// </summary>
        /// <param name="journey">The journey.</param>
        /// <param name="passangerType">Type of the passanger.</param>
        /// <param name="ivaToIgnore">The iva to ignore.</param>
        /// <param name="tuaToIgnore">The tua to ignore.</param>
        /// <param name="chargeType">Type of the charge.</param>
        /// <returns></returns>
        private decimal GetExtraTaxes(bookingManager.Journey journey, string passangerType, string ivaToIgnore, string tuaToIgnore, bookingManager.ChargeType chargeType)
        {

            decimal total = 0;

            if (journey != null)
            {
                for (int j = 0; j < journey.Segments.Count(); j++)
                {
                    bookingManager.Segment segment = journey.Segments[j];
                    if (segment != null)
                    {
                        for (int m = 0; m < segment.Fares.Count(); m++)
                        {
                            bookingManager.Fare fare = segment.Fares[m];
                            if (fare != null)
                            {
                                for (int p = 0; p < fare.PaxFares.Count(); p++)
                                {
                                    if (fare.PaxFares[p].PaxType.Equals(passangerType))
                                    {
                                        bookingManager.PaxFare paxFare = fare.PaxFares[p];

                                        if (paxFare != null)
                                        {
                                            total = paxFare.ServiceCharges.Where(service => !service.TicketCode.Equals(ivaToIgnore) &&
                                                                                            !service.TicketCode.Equals(tuaToIgnore) &&
                                                                                            !service.TicketCode.Equals(string.Empty) &&
                                                                                             service.ChargeType != bookingManager.ChargeType.FarePrice &&
                                                                                             service.ChargeType != bookingManager.ChargeType.Discount &&
                                                                                            service.ChargeType == chargeType).Sum(e => e.Amount);
                                        }
                                    }
                                }
                            }
                        }


                    }
                }
            }


            return total;

        }

        /// <summary>
        /// Gets the price from booking.
        /// </summary>
        /// <param name="journey">The journey.</param>
        /// <param name="passangerType">Type of the passanger.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="chargeType">Type of the charge.</param>
        /// <returns></returns>
        private decimal GetPriceFromBooking(bookingManager.Journey journey, string passangerType, string amountType, bookingManager.ChargeType chargeType)
        {

            decimal amount = 0;
            if (journey != null)
            {
                for (int j = 0; j < journey.Segments.Count(); j++)
                {
                    bookingManager.Segment segment = journey.Segments[j];
                    if (segment != null)
                    {
                        for (int k = 0; k < segment.Fares.Count(); k++)
                        {
                            bookingManager.Fare fare = segment.Fares[k];
                            if (fare != null)
                            {
                                for (int f = 0; f < fare.PaxFares.Count(); f++)
                                {
                                    if (fare.PaxFares[f].PaxType.Equals(passangerType))
                                    {
                                        bookingManager.PaxFare paxFare = fare.PaxFares[f];

                                        if (paxFare != null)
                                        {
                                            for (int l = 0; l < paxFare.ServiceCharges.Count(); l++)
                                            {
                                                bookingManager.BookingServiceCharge serviceOfCharge = paxFare.ServiceCharges[l];

                                                taxes = taxes + " " + paxFare.ServiceCharges[l].ChargeType.ToString() + " " + paxFare.ServiceCharges[l].TicketCode + " " + serviceOfCharge.Amount.ToString("#.00") + "|";

                                                if (amountType == "FarePrice" && paxFare.ServiceCharges[l].ChargeType.ToString() == "FarePrice")
                                                {
                                                    if (serviceOfCharge != null)
                                                    {
                                                        amount = amount + serviceOfCharge.Amount;
                                                    }
                                                }
                                                else if (amountType == "Discount" && paxFare.ServiceCharges[l].ChargeType.ToString() == "Discount")
                                                {
                                                    if (serviceOfCharge != null)
                                                    {
                                                        amount = amount + serviceOfCharge.Amount;
                                                    }
                                                }
                                                else if (amountType == "IVA" && (paxFare.ServiceCharges[l].TicketCode == "IVA" || paxFare.ServiceCharges[l].TicketCode == "IV2"))
                                                {
                                                    if (serviceOfCharge != null)
                                                    {
                                                        amount = amount + serviceOfCharge.Amount;
                                                    }
                                                }
                                                else if (amountType == "TUA" && (paxFare.ServiceCharges[l].TicketCode == "TUA" || paxFare.ServiceCharges[l].TicketCode == "TU2"))
                                                {
                                                    if (serviceOfCharge != null)
                                                    {
                                                        amount = amount + serviceOfCharge.Amount;
                                                    }
                                                }
                                                else if (amountType == "ExtraTaxes" && paxFare.ServiceCharges[l].ChargeType.ToString() != "FarePrice" &&
                                                    paxFare.ServiceCharges[l].ChargeType.ToString() != "Discount" &&
                                                    paxFare.ServiceCharges[l].TicketCode != "IVA" &&
                                                    paxFare.ServiceCharges[l].TicketCode != "IV2" &&
                                                    paxFare.ServiceCharges[l].TicketCode != "TU2" &&
                                                    paxFare.ServiceCharges[l].TicketCode != "TUA")
                                                {
                                                    if (serviceOfCharge != null)
                                                    {
                                                        amount = amount + serviceOfCharge.Amount;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return amount;
            }
            return 0;
        }

        /// <summary>
        /// Makes the reservation.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public void MakeReservation(MyCTS.Entities.InterJetTicket ticket)
        {
            var bookingClient = this.CreateBookingManager();
            try
            {
                var sellRequestData = new bookingManager.SellRequestData();

                sellRequestData.SellJourneyRequest = new bookingManager.SellJourneyRequest();
                sellRequestData.SellJourneyRequest.SellJourneyRequestData = new bookingManager.SellJourneyRequestData();
                sellRequestData.SellJourneyRequest.SellJourneyRequestData.PaxCount = ticket.Passangers.Total;
                sellRequestData.SellJourneyRequest.SellJourneyRequestData.Passengers =
                    this.GetPassangerFromTicket(ticket);
                sellRequestData.SellJourneyRequest.SellJourneyRequestData.Journeys =
                    this.GetJourneyToSellFromTicket(ticket);
                sellRequestData.SellJourneyRequest.SellJourneyRequestData.CurrencyCode = InterJetConstant.CurrencyCode;

                sellRequestData.SellJourneyRequest.SellJourneyRequestData.TypeOfSale = new bookingManager.TypeOfSale();
                sellRequestData.SellJourneyRequest.SellJourneyRequestData.TypeOfSale.PaxResidentCountry = "MX";


                sellRequestData.SellBy = bookingManager.SellBy.Journey;
                Serializer.Serialize("SellRequest", sellRequestData);
                Serializer.Serialize("CommitRequest", sellRequestData);

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(sellRequestData.GetType());
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\SellRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file, sellRequestData);
                //file.Close();

                bookingManager.BookingUpdateResponseData responseFromSell = bookingClient.Sell(Contract, Signature,
                                                                                              sellRequestData);

                //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(responseFromSell.GetType());
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\SellResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer1.Serialize(file1, responseFromSell);
                //file1.Close();

                PriceTotalResponseInterjet.sellResponse= responseFromSell.Success.PNRAmount.BalanceDue;

                if (PriceTotalResponseInterjet.isInfant)
                {
                    var sellRequestData1 = new bookingManager.SellRequestData();
                    sellRequestData1.SellJourneyRequest = new bookingManager.SellJourneyRequest();
                    sellRequestData1.SellSSR = new bookingManager.SellSSR();
                    sellRequestData1.SellSSR.SSRRequest = new bookingManager.SSRRequest();
                    sellRequestData1.SellSSR.SSRRequest.CurrencyCode = InterJetConstant.CurrencyCode;
                    sellRequestData1.SellSSR.SSRRequest = this.GetSpecialService(ticket);
                    sellRequestData1.SellFee = new bookingManager.SellFee();
                    sellRequestData1.SellFee.SellFeeRequestData = new bookingManager.SellFeeRequestData();
                    sellRequestData1.SellFee.SellFeeRequestData.PassengerNumber = 0;
                    sellRequestData1.SellFee.SellFeeRequestData.SellFeeType = bookingManager.SellFeeType.ServiceFee;

                    sellRequestData1.SellBy = bookingManager.SellBy.SSR;

                    //System.Xml.Serialization.XmlSerializer writer2 = new System.Xml.Serialization.XmlSerializer(sellRequestData1.GetType());
                    //System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"c:\RESP\SellRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer2.Serialize(file2, sellRequestData1);
                    //file2.Close();

                    bookingManager.BookingUpdateResponseData responseFromSell2 = bookingClient.Sell(Contract, Signature,
                                                                                                 sellRequestData1);

                    //System.Xml.Serialization.XmlSerializer writer3 = new System.Xml.Serialization.XmlSerializer(responseFromSell2.GetType());
                    //System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"c:\RESP\SellResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer3.Serialize(file3, responseFromSell2);
                    //file3.Close();

                    //PriceTotalResponseInterjet.totalPriceInfant = responseFromSell2.Success.PNRAmount.BalanceDue;
                    PriceTotalResponseInterjet.totalPriceInfant = responseFromSell2.Success.PNRAmount.BalanceDue - PriceTotalResponseInterjet.sellResponse;
                    PriceTotalResponseInterjet.sellResponse = responseFromSell2.Success.PNRAmount.BalanceDue;

                }


                if (responseFromSell.Success.PNRAmount.SegmentCount > 0)
                    ImpuestosBajoCosto.continuePayment = true;
                else
                    ImpuestosBajoCosto.continuePayment = false;

                Serializer.Serialize("CommitRequest", responseFromSell);

                Serializer.Serialize("SellResponse", responseFromSell);
                var e = responseFromSell;
                var r = e.OtherServiceInformations;

                bookingClient.Close();

            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");

                }
                throw;
            }

        }

        public void Commit(MyCTS.Entities.InterJetTicket ticket)
        {
            var bookingClient = this.CreateBookingManager();
            try
            {
                if (CostumerAccountInterJet.DepartureTime > DateTime.Now.AddHours(24))
                {
                    var commitRequest = new bookingManager.CommitRequestData();
                    commitRequest.Booking = new bookingManager.Booking();
                    commitRequest.Booking.PaxCount = ticket.Passangers.Total;
                    commitRequest.Booking.CurrencyCode = InterJetConstant.CurrencyCode;
                    commitRequest.Booking.BookingContacts = this.GetInterJetContactFromTicket(ticket);

                    Serializer.Serialize("CommitRequest", commitRequest);

                    //System.Xml.Serialization.XmlSerializer writer2 = new System.Xml.Serialization.XmlSerializer(commitRequest.GetType());
                    //System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"c:\RESP\ComitRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer2.Serialize(file2, commitRequest);
                    //file2.Close();

                    bookingManager.BookingUpdateResponseData responseFromCommit = bookingClient.Commit(Contract, Signature,
                                                                                                      commitRequest);

                    //System.Xml.Serialization.XmlSerializer writer3 = new System.Xml.Serialization.XmlSerializer(responseFromCommit.GetType());
                    //System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"c:\RESP\ComitResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer3.Serialize(file3, responseFromCommit);
                    //file3.Close();

                    if (responseFromCommit.Success.PNRAmount.SegmentCount > 0)
                        ImpuestosBajoCosto.continuePayment = true;
                    else
                        ImpuestosBajoCosto.continuePayment = false;

                    PriceTotalResponseInterjet.commitResponse = responseFromCommit.Success.PNRAmount.BalanceDue;

                    Serializer.Serialize("CommitResponse", responseFromCommit);
                    ticket.RecordLocator = responseFromCommit.Success.RecordLocator;
                    ticket.BalanceToPay = responseFromCommit.Success.PNRAmount.BalanceDue;
                    //quitar
                    ImpuestosBajoCosto.PNRBajoCosto = ticket.RecordLocator;
                    ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, ImpuestosBajoCosto.PNRBajoCosto, ImpuestosBajoCosto.ImpuestosMostrados, string.Empty, string.Empty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

       }

        /// <summary>
        /// Gets the booking.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <returns></returns>
        public bookingManager.Booking GetBooking(string recordLocator, List<MyCTS.Entities.InterJetFlight> flights)
        {
            ImpuestosBajoCosto.continuePayment = false;

            var bookingClient = this.CreateBookingManager();
            
            try
            {
                bookingManager.Booking bookingResponse = null;
                if (!string.IsNullOrEmpty(recordLocator))
                {
                    var bookingRequest = new bookingManager.GetBookingRequestData
                    {
                        GetByRecordLocator = new bookingManager.GetByRecordLocator
                        {
                            RecordLocator = recordLocator
                        }
                    };
                    Serializer.Serialize("GetBookingRequest", bookingRequest);

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(bookingRequest.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\GetBookingRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, bookingRequest);
                    //file.Close();

                    bookingResponse = bookingClient.GetBooking(Contract, Signature, bookingRequest);

                    //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(bookingResponse.GetType());
                    //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\GetBookingResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer1.Serialize(file1, bookingResponse);
                    //file1.Close();

                    if (bookingResponse != null)
                    {
                        
                        for (int j = 0; j < bookingResponse.Journeys.Count(); j++)
                        {
                            if (bookingResponse.Journeys[j].Segments.Count() > 0 &&
                                bookingResponse.Journeys[j].Segments.Count() == flights[j].Segments.GetAll().Count)
                            {
                                //TimeSpan time = Convert.ToDateTime(bookingResponse.BookingHold.HoldDateTime.ToString().Substring(12, 8)) - Convert.ToDateTime(bookingResponse.BookingInfo.CreatedDate.ToString().Substring(12, 8));
                                //DateTime a = ImpuestosBajoCosto.FechaCreacion.AddTicks(time.Ticks);
                                //if (a > DateTime.Now)
                                //{
                                    if (bookingResponse.BookingSum.BalanceDue > 0)
                                    {
                                        ImpuestosBajoCosto.continuePayment = true;
                                    }
                                //}
                            }
                            else
                            {
                                ImpuestosBajoCosto.continuePayment = false;
                            }
                        }



                        if (bookingResponse.BookingID.ToString().Length < 8)
                        {
                            NumeroBoleto.FligthNumber = "0" + bookingResponse.BookingID.ToString();
                        }
                        else
                        {
                            NumeroBoleto.FligthNumber = bookingResponse.BookingID.ToString();
                        }
                    }
                    Serializer.Serialize("GetBookingResponse", bookingResponse);
                    bookingClient.Close();
                }
                    return bookingResponse;
                
            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");

                }
                throw;
            }

        }

        /// <summary>
        /// Realiza el pago de la reservación.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="creditCardFields"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="paymentText"></param>
        public void Pay(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields, string paymentMethod, string paymentText)
        {

            var bookingClient = this.CreateBookingManager();
            try
            {

                var addPaymentRequest = new bookingManager.AddPaymentToBookingRequestData();
                addPaymentRequest.AccountNumber = creditCardFields.CreditCardNumber;
                addPaymentRequest.PaymentMethodCode = paymentMethod;

                if (paymentMethod == InterJetConstant.VisaMasterCardCode ||
                    paymentMethod == InterJetConstant.MasterCard)
                    addPaymentRequest.Installments = 1;
                if (paymentMethod != InterJetConstant.ElectronicPurse)
                {
                    addPaymentRequest.Expiration = creditCardFields.ExpirationDate;
                    addPaymentRequest.PaymentMethodType = bookingManager.RequestPaymentMethodType.ExternalAccount;
                    addPaymentRequest.PaymentFields = this.GetPaymentFields(creditCardFields, paymentMethod);
                }


                if (paymentMethod == "AG")
                    addPaymentRequest.PaymentMethodType = bookingManager.RequestPaymentMethodType.AgencyAccount;

               

                addPaymentRequest.PaymentText = paymentText;
                addPaymentRequest.QuotedAmount = Convert.ToDecimal(ticket.BalanceToPay);
                addPaymentRequest.QuotedCurrencyCode = InterJetConstant.CurrencyCode;

                Serializer.Serialize("AddPaymentToBookingRequest", addPaymentRequest);

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(addPaymentRequest.GetType());
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\addPaymentRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer.Serialize(file, addPaymentRequest);
                //file.Close();

                bookingManager.AddPaymentToBookingResponseData responseFromPayment = null;


                responseFromPayment = bookingClient.AddPaymentToBooking(Contract, Signature, addPaymentRequest);


                //System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(responseFromPayment.GetType());
                //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\RESP\addPaymentResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                //writer1.Serialize(file1, responseFromPayment);
                //file1.Close();

                Serializer.Serialize("AddPaymentToBookingResponse", responseFromPayment);
                if (responseFromPayment!=null && responseFromPayment.ValidationPayment.PaymentValidationErrors.Any())
                {

                    string[] errorMessage = (from error in responseFromPayment.ValidationPayment.PaymentValidationErrors
                                             select
                                                 error.ErrorDescription
                                            ).ToArray();
                    string msg = string.Join("\n", errorMessage);

                    throw new Exception(msg);
                }

                ListTaxesInterjet.Status = responseFromPayment.ValidationPayment.Payment.AuthorizationStatus.ToString();


                if (!string.IsNullOrEmpty(ticket.RecordLocator) && CostumerAccountInterJet.DepartureTime > DateTime.Now.AddHours(24))
                {
                   
                    var request = new bookingManager.CommitRequestData
                    {
                        Booking = new bookingManager.Booking
                        {
                            RecordLocator = ticket.RecordLocator,
                            BookingContacts = this.GetInterJetContactFromTicket(ticket)
                        },
                        DistributeToContacts = true
                    };

                    //System.Xml.Serialization.XmlSerializer writer2 = new System.Xml.Serialization.XmlSerializer(request.GetType());
                    //System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"c:\RESP\CommitRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer2.Serialize(file2, request);
                    //file2.Close();

                    Serializer.Serialize("CommitAddPaymentToBookingRequest", request);
                    var response = bookingClient.Commit(Contract, Signature, request);
                    Serializer.Serialize("CommitAddPaymentToBookingResponse", response);

                    PriceTotalResponseInterjet.commitResponse = response.Success.PNRAmount.BalanceDue;

                    //System.Xml.Serialization.XmlSerializer writer3 = new System.Xml.Serialization.XmlSerializer(response.GetType());
                    //System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"c:\RESP\CommitResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer3.Serialize(file3, response);
                    //file3.Close();
                }
                else
                {
                    var commitRequest = new bookingManager.CommitRequestData();
                    commitRequest.Booking = new bookingManager.Booking();
                    commitRequest.Booking.PaxCount = ticket.Passangers.Total;
                    commitRequest.Booking.CurrencyCode = InterJetConstant.CurrencyCode;
                    commitRequest.Booking.BookingContacts = this.GetInterJetContactFromTicket(ticket);
                    commitRequest.DistributeToContacts = true;

                    //System.Xml.Serialization.XmlSerializer writer4 = new System.Xml.Serialization.XmlSerializer(commitRequest.GetType());
                    //System.IO.StreamWriter file4 = new System.IO.StreamWriter(@"c:\RESP\CommitRequest " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer4.Serialize(file4, commitRequest);
                    //file4.Close();

                    bookingManager.BookingUpdateResponseData responseFromCommit = bookingClient.Commit(Contract, Signature, commitRequest);

                    //System.Xml.Serialization.XmlSerializer writer5 = new System.Xml.Serialization.XmlSerializer(responseFromCommit.GetType());
                    //System.IO.StreamWriter file5 = new System.IO.StreamWriter(@"c:\RESP\CommitResponse " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer5.Serialize(file5, responseFromCommit);
                    //file5.Close();
                    PriceTotalResponseInterjet.commitResponse = responseFromCommit.Success.PNRAmount.BalanceDue;

                    Serializer.Serialize("CommitResponse", responseFromCommit);
                    ticket.RecordLocator = responseFromCommit.Success.RecordLocator;
                    ticket.BalanceToPay = responseFromCommit.Success.PNRAmount.BalanceDue;
                    //quitar
                    ImpuestosBajoCosto.PNRBajoCosto = ticket.RecordLocator;
                    ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, ImpuestosBajoCosto.PNRBajoCosto, ImpuestosBajoCosto.ImpuestosMostrados, string.Empty, string.Empty);

                }


                bookingClient.Close();
            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();

                }
                catch
                {
                    throw new TimeoutException("");

                }
                throw;
            }

        }


        private bookingManager.BookingName[] GetBookingNameFromPassenger(MyCTS.Entities.InterJetPassanger passenger)
        {
            var bookingName = new bookingManager.BookingName { FirstName = passenger.Name, LastName = passenger.LastName, Title = passenger.Title, };
            return new[] { bookingName };

        }

        /// <summary>
        /// Realiza el pago  con tarjeta de american express.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="creditCardFields"></param>
        public void AmericanExpressPayment(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields)
        {
            this.Pay(ticket, creditCardFields, InterJetConstant.AmericanExpressPaymentCode, "Compra de boleto vía AmericanExpres");
        }

        /// <summary>
        /// Realiza el pago con tarjeta visa master card.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="creditCardFields"></param>
        public void VisaMasterCardPayment(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields)
        {
            this.Pay(ticket, creditCardFields, InterJetConstant.VisaMasterCardCode, "Compra de boleto vía Master Card");
        }

        /// <summary>
        /// Realiza el pago con tarjeta UTAP
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="creditCardFields"></param>
        public void UniversalAirTravelPlanPayment(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields)
        {
            this.Pay(ticket, creditCardFields, InterJetConstant.UniversalAirTravelPlanCode, "Compra de boleto via UATP");
        }

        /// <summary>
        /// Masters the card payment.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="creditCardFields">The credit card fields.</param>
        public void MasterCardPayment(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields)
        {
            this.Pay(ticket, creditCardFields, InterJetConstant.MasterCard, "Compra de boleto vía MasterCard");
        }

        /// <summary>
        /// Americans the express3 payment.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="creditCardFields">The credit card fields.</param>
        public void AmericanExpress3Payment(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields)
        {

            this.Pay(ticket, creditCardFields, InterJetConstant.AMEX3, "Compra de boleto vía American express 3");
        }

        //Pago Monedero Electronico
        public void ElectronicPursePayment(MyCTS.Entities.InterJetTicket ticket, InterJetCreditCardFields creditCardFields)
        {
            this.Pay(ticket, creditCardFields, InterJetConstant.ElectronicPurse, "Compra de boleto vía Monedero Electronico");
        }

        /// <summary>
        /// Limpia la reservación
        /// </summary>
        public void ClearBooking()
        {
            var bookingClient = this.CreateBookingManager();
            try
            {

                bookingClient.Clear(Contract, Signature);
            }
            catch (Exception exception)
            {

                try
                {
                    bookingClient.Abort();
                    throw;
                }
                catch
                {
                    throw new TimeoutException("");

                }
            }
        }

        /// <summary>
        /// Obtiene los campos de pago.
        /// </summary>
        /// <param name="creditCardFields"></param>
        /// <returns></returns>
        private bookingManager.PaymentField[] GetPaymentFields(InterJetCreditCardFields creditCardFields, string paymentMethod)
        {

            var fields = new List<bookingManager.PaymentField>();

            var accountOwner = new bookingManager.PaymentField
            {
                FieldName = InterJetConstant.AccountHolderName,
                FieldValue = creditCardFields.OwnerName
            };

            fields.Add(accountOwner);

            var expirationDate = new bookingManager.PaymentField
            {
                FieldName = InterJetConstant.ExpirationDate,
                FieldValue = creditCardFields.ExpirationDate.ToString()
            };

            fields.Add(expirationDate);

            var verificationCode = new bookingManager.PaymentField
            {
                FieldName = InterJetConstant.VerificationCode,
                FieldValue = creditCardFields.SecurityCodeNumber
            };


            fields.Add(verificationCode);

            var amount = new bookingManager.PaymentField
            {
                FieldName = InterJetConstant.Amount,
                FieldValue = creditCardFields.TotalAmount.ToString()
            };
            fields.Add(amount);
            var postalCode = new bookingManager.PaymentField { FieldName = InterJetConstant.PostalCode, FieldValue = creditCardFields.PostalCode };

            fields.Add(postalCode);

            if (paymentMethod == InterJetConstant.AmericanExpressPaymentCode ||
                     paymentMethod == InterJetConstant.AMEX3)
            {
                var centerCost = new bookingManager.PaymentField
                {
                    FieldName = "CentroCostos",
                    FieldValue = InterJetCreditCardFields.CC
                };
                fields.Add(centerCost);

                var employeeNum = new bookingManager.PaymentField
                {
                    FieldName = "NumEpleado",
                    FieldValue = InterJetCreditCardFields.EmployeeNum
                };
                fields.Add(employeeNum);
            }

            return fields.ToArray();
        }


        public void Sell(MyCTS.Entities.InterJetTicket ticketToSell)
        {



        }

        #endregion

        #region "Getters Object Model from Contracts"

        /// <summary>
        /// Obtiene los segementos que se quieran vender.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        private bookingManager.SellJourney[] GetJourneyToSellFromTicket(MyCTS.Entities.InterJetTicket ticket)
        {

            var journeysToSell = new List<bookingManager.SellJourney>();
            foreach (MyCTS.Entities.InterJetFlight flight in ticket.Flights.GetFlights())
            {
                if (flight.Segments.GetAll().Count == 1)
                {
                    var sellSegment = new bookingManager.SellSegment
                    {
                        ActionStatusCode = InterJetConstant.ActionStatusCode,
                        DepartureStation = flight.DepartureStation,
                        ArrivalStation = flight.ArrivalStation,
                        STA = flight.ArrivalDateTime,
                        STD = flight.DepartureTime,
                        FlightDesignator = new bookingManager.FlightDesignator
                        {
                            CarrierCode = flight.FlightDesignator.CarrierCode,
                            FlightNumber = flight.FlightNumber
                        },
                        Fare = new bookingManager.SellFare
                        {
                            CarrierCode = flight.Fare.CarrierCode,
                            ClassOfService = flight.Fare.ClassOfService,
                            ClassType = flight.Fare.ClassType,
                            FareApplicationType = bookingManager.FareApplicationType.Route,
                            FareBasisCode = flight.Fare.FareBasisCode,
                            FareClassOfService = flight.Fare.FareClassOfService,
                            FareSequence = flight.Fare.FareSequence,
                            RuleNumber = flight.Fare.RuleNumber,
                            RuleTariff = flight.Fare.RuleTariff
                        }
                    };

                    var journeyToSell = new bookingManager.SellJourney
                    {
                        Segments = new[] { sellSegment }
                    };
                    journeysToSell.Add(journeyToSell);
                }
                else
                {
                    bookingManager.SellSegment sellSegment = new bookingManager.SellSegment();
                    bookingManager.SellJourney journeyToSell = new bookingManager.SellJourney();
                    List<bookingManager.SellSegment> sellSegmentList = new List<bookingManager.SellSegment>();

                    int a = 0;

                    foreach (MyCTS.Entities.ISegment seg in flight.Segments.GetAll())
                    {
                        sellSegment = new bookingManager.SellSegment
                        {
                            ActionStatusCode = InterJetConstant.ActionStatusCode,
                            DepartureStation = seg.DepartureStation,
                            ArrivalStation = seg.ArrivalStation,
                            STA = seg.ArrivalTime,
                            STD = seg.DepartureTime,
                            FlightDesignator = new bookingManager.FlightDesignator
                            {
                                CarrierCode = ((MyCTS.Entities.InterJetSegment)seg).Information.FlightDesignator.CarrierCode,
                                FlightNumber = ((MyCTS.Entities.InterJetSegment)seg).Information.FlightDesignator.FlightNumber
                            },
                            Fare = new bookingManager.SellFare
                            {
                                CarrierCode = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.CarrierCode,
                                ClassOfService = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.ClassOfService,
                                ClassType = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.ClassType,
                                FareApplicationType = bookingManager.FareApplicationType.Governing,
                                FareBasisCode = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.FareBasisCode,
                                FareClassOfService = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.FareClassOfService,
                                FareSequence = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.FareSequence,
                                RuleNumber = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.RuleNumber,
                                RuleTariff = ((MyCTS.Entities.InterJetSegment)seg).Information.Fare.RuleTariff
                            },
                            
                            
                        };

                        if (a == 1)
                        {
                            sellSegment.Fare.FareApplicationType = bookingManager.FareApplicationType.Sector;
                            a = 0;
                        }
                        else
                            a++;

                        sellSegmentList.Add(sellSegment);
                        
                        //journeysToSell.Add(journeyToSell);
                    }
                    journeyToSell = new bookingManager.SellJourney
                    {
                        Segments = new[] { sellSegmentList[0], sellSegmentList[1] }
                    };

                    journeysToSell.Add(journeyToSell);
                }
            }
            return journeysToSell.ToArray();
        }

        /// <summary>
        /// Obtiene los segementos que se quieran vender.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <returns></returns>
        private bookingManager.SellJourney[] GetJourneyToSellFromTicket(MyCTS.Entities.InterJetFlight flight)
        {

            var journeysToSell = new List<bookingManager.SellJourney>();

            var sellSegment = new bookingManager.SellSegment
            {
                ActionStatusCode = InterJetConstant.ActionStatusCode,
                DepartureStation = flight.DepartureStation,
                ArrivalStation = flight.ArrivalStation,
                STA = flight.ArrivalDateTime,
                STD = flight.DepartureTime,
                FlightDesignator = new bookingManager.FlightDesignator
                {
                    CarrierCode = flight.FlightDesignator.CarrierCode,
                    FlightNumber = flight.FlightNumber
                },
                Fare = new bookingManager.SellFare
                {
                    CarrierCode = flight.Fare.CarrierCode,
                    ClassOfService = flight.Fare.ClassOfService,
                    ClassType = flight.Fare.ClassType,
                    FareApplicationType = bookingManager.FareApplicationType.Route,
                    FareBasisCode = flight.Fare.FareBasisCode,
                    FareClassOfService = flight.Fare.FareClassOfService,
                    FareSequence = flight.Fare.FareSequence,
                    RuleNumber = flight.Fare.RuleNumber,
                    RuleTariff = flight.Fare.RuleTariff
                }
            };

            var journeyToSell = new bookingManager.SellJourney
            {
                Segments = new bookingManager.SellSegment[] { sellSegment }
            };
            journeysToSell.Add(journeyToSell);

            return journeysToSell.ToArray();
        }


        /// <summary>
        /// Obtiene los indentifiacadores de los vuelos.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="IsInternational">if set to <c>true</c> [is international].</param>
        /// <returns></returns>
        private bookingManager.SellKeyList[] GetSellKeyListFromTicket(MyCTS.Entities.InterJetTicket ticket, bool IsInternational)
        {
            List<bookingManager.SellKeyList> keys2 = new List<bookingManager.SellKeyList>();
            bookingManager.SellKeyList[] keys = null;

            foreach (MyCTS.Entities.InterJetFlight flight in ticket.Flights.GetFlights().Where(f => f.IsInternational == IsInternational))
            {
                foreach (MyCTS.Entities.ISegment seg in flight.Segments.GetAll())
                {
                    keys2.Add(new bookingManager.SellKeyList
                    {
                        FareSellKey = ((MyCTS.Entities.InterJetSegment)seg).Information.FareSellKey,
                        JourneySellKey = ((MyCTS.Entities.InterJetSegment)seg).Information.JourneySellKey
                    });
                }
            }

            keys = keys2.ToArray();
            return keys;

        }


        /// <summary>
        /// Gets the sell key list from ticket.
        /// </summary>
        /// <param name="flights">The flights.</param>
        /// <param name="IsInternational">if set to <c>true</c> [is international].</param>
        /// <returns></returns>
        private bookingManager.SellKeyList[] GetSellKeyListFromTicket(MyCTS.Entities.InterJetFlight flight)
        {
            bookingManager.SellKeyList[] keys = new bookingManager.SellKeyList[]
                                     {

                                         new bookingManager.SellKeyList
                                             {
                                                   FareSellKey = flight.FareSellKey,
                                                  JourneySellKey = flight.JourneySellKey

                                             }
                                     };
            return keys;

        }

        /// <summary>
        /// OBtiene los pasajeros de los tickets para agregarlos en la reservación.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private bookingManager.Passenger[] GetPassangerFromTicket(MyCTS.Entities.InterJetTicket ticket)
        {
            var passangers = new List<bookingManager.Passenger>();
            foreach (var pax in ticket.Passangers.GetAll().Where(p => !(p is InterJetPassangerInfant)))
            {
                var newPax = new bookingManager.Passenger
                {
                    Names = this.GetPassangerBookingName(pax),
                    Infant = this.GetInfantFromPassanger(pax),
                    PassengerTypeInfos = this.GetPassangerTypeInfo(pax),
                    PaxDiscountCode = (pax is InterJetPassangerInfant) ? null : "INET"
                };

                if (ticket.Flights.HasInternationalSegments)
                {
                    newPax.PassengerTravelDocuments = this.GetPassengerDocuments(pax, ticket);

                }
                passangers.Add(newPax);
            }
            return passangers.ToArray();

        }


        /// <summary>
        /// Obtiene los documentos de viaje de un pasajero.
        /// </summary>
        /// <param name="pax"></param>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private bookingManager.PassengerTravelDocument[] GetPassengerDocuments(MyCTS.Entities.InterJetPassanger pax, MyCTS.Entities.InterJetTicket ticket)
        {
            var document = new bookingManager.PassengerTravelDocument
            {
                DOB = pax.DateOfBirth,
                DocTypeCode = InterJetConstant.DocTypeCode,
                Names = this.GetBookingNameFromContact(ticket.Contact),
                IssuedByCode = InterJetConstant.IssueByCode,
                DocNumber = ticket.Contact.PrimaryTelephone,
                Gender = this.GetGender(pax)
            };

            return new bookingManager.PassengerTravelDocument[] { document };
        }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <param name="pax">The pax.</param>
        /// <returns></returns>
        private bookingManager.Gender GetGender(MyCTS.Entities.InterJetPassanger pax)
        {

            if (pax.Title.Equals("MR"))
            {
                return bookingManager.Gender.Male;

            }

            if (pax.Title.Equals("MRS") || pax.Title.Equals("MS"))
            {
                return bookingManager.Gender.Female;

            }

            return bookingManager.Gender.Unmapped;



        }

        /// <summary>
        /// Obtiene el tipo de pasajero en los segmentos.
        /// </summary>
        /// <param name="pax"></param>
        /// <returns></returns>
        private bookingManager.PassengerTypeInfo[] GetPassangerTypeInfo(MyCTS.Entities.InterJetPassanger pax)
        {
            var type = new bookingManager.PassengerTypeInfo();

            if (pax.IsSeniorAdult)
            {
                type.PaxType = "SRC";
            }

            if (pax.IsAdult)
            {
                type.PaxType = "ADT";
            }

            if (pax.IsChild)
            {
                type.PaxType = "CHD";
            }

            type.DOB = pax.DateOfBirth;

            return new bookingManager.PassengerTypeInfo[] { type };
        }

        //TODO: verificar por que se queda colgado.
        // TODO: Verificar lo de los ivas diferentes
        // TODO: Agregar A3 
        /// <summary>
        /// Obtiene el nombre del pasajero y lo agrega en la reservación.
        /// </summary>
        /// <param name="passanger"></param>
        /// <returns></returns>
        private bookingManager.BookingName[] GetPassangerBookingName(MyCTS.Entities.InterJetPassanger passanger)
        {
            var bookingName = new bookingManager.BookingName
            {
                FirstName = passanger.Name,
                LastName = passanger.LastName,
                MiddleName = "",
                Title = passanger.Title,
                Suffix = passanger.Suffix
            };
            return new bookingManager.BookingName[] { bookingName };

        }


        /// <summary>
        /// Obtiene el nombre del infante de entre los infantes.
        /// </summary>
        /// <param name="passanger"></param>
        /// <returns></returns>
        private bookingManager.BookingName[] GetPassangerBookingName(InterJetPassangerInfant passanger)
        {
            var bookingName = new bookingManager.BookingName { FirstName = passanger.Name, LastName = passanger.LastName, Title = passanger.Title };
            return new bookingManager.BookingName[] { bookingName };

        }

        /// <summary>
        /// Obtiene el genero del pasajero.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        private bookingManager.Gender GetGenderFromInfant(string gender)
        {
            switch (gender)
            {
                case "MI":
                    return bookingManager.Gender.Male;
                case "FI":
                    return bookingManager.Gender.Female;
                default:
                    return bookingManager.Gender.Male;

            }
        }

        /// <summary>
        /// Obtiene al infante asignado a un pasajero.
        /// </summary>
        /// <param name="adultPax"></param>
        /// <returns></returns>
        private bookingManager.PassengerInfant GetInfantFromAdultPassanger(InterJetAdultPassanger adultPax)
        {
            var infant = new bookingManager.PassengerInfant
            {
                Names = this.GetPassangerBookingName(adultPax.AssignedInfant),
                Nationality = "MX",
                Gender = this.GetGenderFromInfant(adultPax.AssignedInfant.Sex),
                ResidentCountry = "MX",
                DOB = adultPax.AssignedInfant.DateOfBirth

            };
            return infant;
        }


        /// <summary>
        /// Obtiene el infante asignado a un adulto mayor.
        /// </summary>
        /// <param name="adultPax"></param>
        /// <returns></returns>
        private bookingManager.PassengerInfant GetInfantFromAdultPassanger(InterJetSeniorAdultPassanger adultPax)
        {
            var infant = new bookingManager.PassengerInfant
            {
                Names = this.GetPassangerBookingName(adultPax.AssignedInfant),
                Nationality = "MX",
                Gender = this.GetGenderFromInfant(adultPax.AssignedInfant.Sex),
                ResidentCountry = "MX",
                DOB = adultPax.AssignedInfant.DateOfBirth

            };
            return infant;
        }

        /// <summary>
        /// OBtiene al infante asigando a una adulto
        /// </summary>
        /// <param name="pax"></param>
        /// <returns></returns>
        private bookingManager.PassengerInfant GetInfantFromPassanger(MyCTS.Entities.InterJetPassanger pax)
        {
            bookingManager.PassengerInfant infant = null;
            if (pax.CanBeInfantAssigned)
            {
                var interJetInfat = new InterJetPassangerInfant();
                if (pax.IsAdult)
                {
                    var adultPax = (InterJetAdultPassanger)pax;
                    if (adultPax.AssignedInfant != null)
                    {
                        infant = this.GetInfantFromAdultPassanger(adultPax);
                    }
                }
                if (pax.IsSeniorAdult)
                {
                    var seniorPax = (InterJetSeniorAdultPassanger)pax;
                    if (seniorPax.AssignedInfant != null)
                    {
                        infant = this.GetInfantFromAdultPassanger(seniorPax);
                    }
                }
            }
            return infant;
        }

        #endregion

    }
}