using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
using System.Collections;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.TravelItineraryProduction;
#else

using MyCTS.Services.TravelItineraryTest;
#endif

namespace MyCTS.Services.Contracts.Volaris
{
    public class ItineraryReadService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "TravelItineraryReadService",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }
        #region Miembros de IService
        private MessageHeader GetMessageHeader()
        {

            var messageHeader = new MessageHeader
            {
                ConversationId = "CurrentSession",
                From = new From
                {
                    PartyId = new[] { new PartyId
                                          {
                                              Value =  "9999"
                                          }}

                },
                To = new To
                {

                    PartyId = new[] {new PartyId
                                         {
                                              Value = "123123"
                                         }}


                }


            };

            messageHeader.CPAId = "Y4";
            messageHeader.Action = "TravelItineraryReadLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "TravelItineraryReadLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };

            return messageHeader;
        }

        public VolarisReservation Reservation { get; set; }
        public void Call()
        {
            try
            {
                var request = new TravelItineraryReadRQ()
                {
                    POS = new TravelItineraryReadRQPOS()
                    {

                        Source = new TravelItineraryReadRQPOSSource()
                        {
                            PseudoCityCode = VolarisResources.PseudoCodeCity
                        }
                    },
                    Version = VolarisResources.TravelItinerraryReadServiceVersion
                };
                request.UniqueID = new TravelItineraryReadRQUniqueID()
                {
                    ID = Reservation.RecordLocator.Record
                };
                request.MessagingDetails = new TravelItineraryReadRQMessagingDetails()
                {

                    Transaction = new[]
                                                                 {
                                                                     new TravelItineraryReadRQMessagingDetailsTransaction
                                                                         {
                                                                             Code = "PNR"
                                                                         },
                                                                          new TravelItineraryReadRQMessagingDetailsTransaction
                                                                         {
                                                                             Code = "PAX"
                                                                         },
                                                                          new TravelItineraryReadRQMessagingDetailsTransaction
                                                                         {
                                                                             Code = "ITN"
                                                                         },
                                                                          new TravelItineraryReadRQMessagingDetailsTransaction
                                                                         {
                                                                             Code = "FOP"
                                                                         },
                                                                            new TravelItineraryReadRQMessagingDetailsTransaction
                                                                         {
                                                                             Code = "FQP"
                                                                         },
                                                                          new TravelItineraryReadRQMessagingDetailsTransaction
                                                                         {
                                                                             Code = "FQP"
                                                                         },


                                                                 }
                };
                var service = new TravelItineraryReadService()
                {
                    MessageHeaderValue = this.GetMessageHeader(),
                    SecurityValue = new Security()
                    {

                        BinarySecurityToken = this.SecurityToken
                    }
                };
                Serializer.Serialize("TravelItineraryReadLLSRQ", request);
                var response = service.TravelItineraryReadRQ(request);
                Serializer.Serialize("TravelItineraryReadLLSRS", response);
                LookUpForTickets(response);
                if (response.Errors == null && response.Success != null)
                {
                    Success = true;
                }
                else
                {
                    if (response.Errors != null)
                    {
                        LogError(response.Errors.Error.ErrorInfo.Message);
                    }

                    Success = false;
                    ErrorMessage = "No se pudo recuperar la reserva.";
                }
            }
            catch (Exception exe)
            {
                Success = false;
                LogError(exe.Message);
                ErrorMessage = exe.Message;
            }
        }


        private void LookUpForTickets(TravelItineraryReadRS response)
        {

            if (response.Errors == null)
            {
                var tickets = response.TravelItinerary.ItineraryInfo.Ticketing;

                var passangers = Reservation.Passangers.GetAll().Where(p => !(p is VolarisInfantPassanger)).ToList();
                foreach (var pax in passangers)
                {

                    var ticketsToLook =
                        tickets.Where(
                            t =>
                            pax != null &&
                            (t.eTicketNumber != null &&
                            (!string.IsNullOrEmpty(t.eTicketNumber) &&
                            t.eTicketNumber.Split(' ')[2].Equals(pax.NameInTicket)))).ToList();


                    var eTickets = ticketsToLook.Select(t =>
                                                        t.eTicketNumber.Split(' ')[1]
                                                        .Substring(3, t.eTicketNumber.Split(' ')[1].Length - 3));
                    var eTicket = eTickets.FirstOrDefault(e => !Reservation.Passangers.IsTicketInUse(e));

                    if (!string.IsNullOrEmpty(eTicket))
                    {
                        pax.eTicket = eTicket;

                    }


                }
            }
        }

        #endregion
    }
}
