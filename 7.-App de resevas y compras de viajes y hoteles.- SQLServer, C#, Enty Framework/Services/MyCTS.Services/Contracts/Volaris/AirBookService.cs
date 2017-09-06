using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.AirBookProduction;
#else

using MyCTS.Services.AirBookTest;
#endif

namespace MyCTS.Services.Contracts.Volaris
{
    public class AirBookService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public VolarisReservation Reservation { get; set; }

        private MessageHeader GetMessageHeader()
        {

            var messageHeader = new MessageHeader
                                    {
                                        ConversationId = "CurrentSession",
                                        From = new From
                                                   {
                                                       PartyId = new[]
                                                                     {
                                                                         new PartyId
                                                                             {
                                                                                 Value = "9999"

                                                                             }
                                                                     }

                                                   },
                                        To = new To
                                                 {

                                                     PartyId = new[]
                                                                   {
                                                                       new PartyId
                                                                           {
                                                                               Value = "123123"
                                                                           }
                                                                   }


                                                 }


                                    };

            messageHeader.CPAId = "Y4";
            messageHeader.Action = "OTA_AirBookLLSRQ";
            messageHeader.Service = new Service
                                        {
                                            Value = "OTA_AirBookLLSRQ"
                                        };

            messageHeader.MessageData = new MessageData
                                            {
                                                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                                                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
                                            };



            return messageHeader;
        }

        public void Call()
        {
            try
            {

                var request = CreateRequest();
                request.AirItinerary.OriginDestinationOptions = CreateDestinationAndOriginSegments();
                var service = new OTA_AirBookService
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                          {
                                                              BinarySecurityToken = SecurityToken,

                                                          }

                                  };
                Serializer.Serialize("OTA_AirBookLLSRQ", request);
                var responseFromService = service.OTA_AirBookRQ(request);
                Serializer.Serialize("OTA_AirBookLLSRQ", responseFromService);
                if (responseFromService.Success != null && responseFromService.Errors == null)
                {
                    Reservation.Status = VolarisReservationStatus.Accepted;
                    Success = true;
                }
                else
                {
                    Reservation.Status = VolarisReservationStatus.NotAccepted;
                    var errorCode = responseFromService.Errors.FirstOrDefault();
                    if (errorCode != null)
                    {

                        LogError(errorCode.Error.ErrorInfo.Message);
                    }
                    Success = false;
                    ErrorMessage =
                        "No se puedo crear la reservación debido a que no se pudo apartar el espacio con la aerolinea.";
                }

            }
            catch (Exception e)
            {
                Reservation.Status = VolarisReservationStatus.NotAccepted;
                Success = false;
                ErrorMessage = "No se puedo crear la reservación debido a que no se pudo apartar el espacio con la aerolinea.";
                LogError(e.Message);
            }


        }
        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "AirBookService",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }
        /// <summary>
        /// Creates the destination and origin segments.
        /// </summary>
        /// <returns></returns>
        private OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegment[][] CreateDestinationAndOriginSegments()
        {
            var originsAndDestination = new List<OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegment[]>();
            var departureSegments = Reservation.Itinerary.Departure.Segments.GetAll().Cast<VolarisSegment>().ToList();
            if (departureSegments.Any())
            {
                originsAndDestination.AddRange(GetDestinationAndOriginSegments(departureSegments));
            }
            var returningSegments = Reservation.Itinerary.Return.Segments.GetAll().Cast<VolarisSegment>().ToList();
            if (returningSegments.Any())
            {
                originsAndDestination.AddRange(GetDestinationAndOriginSegments(returningSegments));
            }
            return originsAndDestination.ToArray();
        }

        /// <summary>
        /// Gets the destination and origin segments.
        /// </summary>
        /// <param name="segments">The segments.</param>
        /// <returns></returns>
        private IEnumerable<OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegment[]> GetDestinationAndOriginSegments(List<VolarisSegment> segments)
        {
            var originsAndDestination = new List<OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegment[]>();
            if (segments.Any())
            {
                foreach (var segment in segments)
                {
                    originsAndDestination.Add(new[]
                                                   {
                                                       new OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegment()
                                                           {
                                                               ActionCode = "NN",
                                                               ResBookDesigCode = segment.ClassOfService,
                                                               NumberInParty = segment.NumberInParty.ToString(CultureInfo.InvariantCulture),
                                                               FlightNumber = segment.ID,

                                                               MarketingAirline = new OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegmentMarketingAirline()
                                                                                      {
                                                                                          Code = "Y4"
                                                                                      },
                                                               OperatingAirline = new OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegmentOperatingAirline()
                                                                                      {
                                                                                          Code = "Y4"
                                                                                      },

                                                               ArrivalAirport = new OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegmentArrivalAirport()
                                                                                    {
                                                                                       LocationCode = segment.ArrivalStation
                                                                                    },
                                                              ArrivalDateTime = string.Format("{2}-{0}T{1}",
                                                                                segment.ArrivalTime.ToString("MM-dd",new CultureInfo("es-MX")),
                                                                                segment.ArrivalTime.ToString("HH:mm:ss"),
                                                                                segment.ArrivalTime.ToString("yyyy")),

                                                              DepartureAirport =  new OTA_AirBookRQAirItineraryOriginDestinationOptionFlightSegmentDepartureAirport()
                                                                                        {
                                                                                            LocationCode = segment.DepartureStation
                                                                                        },
                                                              DepartureDateTime =  string.Format("{2}-{0}T{1}",
                                                                                   segment.DepartureTime.ToString("MM-dd",new CultureInfo("es-MX"))
                                                                                   ,segment.DepartureTime.ToString("HH:mm:ss"),
                                                                                   segment.DepartureTime.ToString("yyyy")),
                                                                
                                                           }
                                                   });
                }
            }
            return originsAndDestination;
        }



        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns></returns>
        private OTA_AirBookRQ CreateRequest()
        {
            return new OTA_AirBookRQ
            {
                POS = new OTA_AirBookRQPOS
                {
                    Source = new OTA_AirBookRQPOSSource
                    {
                        PseudoCityCode = VolarisResources.PseudoCodeCity
                    }
                },
                Version = VolarisResources.AirBookServiceVersion,
                AirItinerary = new OTA_AirBookRQAirItinerary(),
                TimeStamp = DateTime.Now.ToString("s"),
            };

        }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
    }
}
