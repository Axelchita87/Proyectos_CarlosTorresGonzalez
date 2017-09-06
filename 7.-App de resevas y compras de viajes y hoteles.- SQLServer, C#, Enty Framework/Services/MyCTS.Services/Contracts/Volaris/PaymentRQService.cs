using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.PaymentProduction;
#else

using MyCTS.Services.PaymentTest;
#endif
namespace MyCTS.Services.Contracts.Volaris
{
    public class PaymentRQService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

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
            messageHeader.Action = "PaymentRQ";
            messageHeader.Service = new Service
            {
                Value = "PaymentRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }
        #region Miembros de IService


        private void GetManualAndSabreTransaction(PaymentRS response)
        {


            string approvalCode = response.AuthorizationResult.ApprovalCode;

            Reservation.Payment.ManualApprovalCode = approvalCode;

        }



        public void Call()
        {
            try
            {
                var request = CreateRequest();
                var service = new PaymentServiceService()
                {
                    MessageHeaderValue = this.GetMessageHeader(),
                    SecurityValue = new Security()
                    {
                        BinarySecurityToken = this.SecurityToken
                    },
                };
                Serializer.Serialize("PaymentRQ", request);
                var response = service.PaymentServiceRQ(request);
                Serializer.Serialize("PaymentRS", response);
                if (response.Result.ResultCode.Equals("SUCCESS"))
                {
                    if (response.AuthorizationResult.ResponseCode.Equals("APPROVED"))
                    {
                        Reservation.Payment.Status = VolarisPaymentStatus.Approved;
                        Reservation.Payment.HistoricalRemarks.Add(response.AuthorizationResult.AuthRemarks1);
                        Reservation.Payment.HistoricalRemarks.Add(response.AuthorizationResult.AuthRemarks2);
                        Reservation.Payment.HasBeenApproved = true;
                        GetManualAndSabreTransaction(response);
                        Reservation.Agent.RecievedEmail = true;
                        VolarisLogger.InsertReservation();
                        Success = true;
                    }
                    if (response.AuthorizationResult.ResponseCode.Equals("DECLINED"))
                    {
                        Reservation.Payment.Status = VolarisPaymentStatus.Declined;
                        ErrorMessage = "El pago fue declinado por el banco al cual pertenece por favor verifique que la información de la tarjeta sea correcta.";
                        Success = false;
                    }

                    if (response.AuthorizationResult.ResponseCode.Equals("ERROR"))
                    {
                        Reservation.Payment.Status = VolarisPaymentStatus.Declined;
                        ErrorMessage = "El pago fue declinado por el banco al cual pertenece por favor verifique que la información de la tarjeta sea correcta.";
                        Success = false;
                    }
                }
                else
                {
                    LogError(response.Result.Description);
                    Success = false;
                    Reservation.Payment.Status = VolarisPaymentStatus.Unkown;
                    ErrorMessage = "No se pudo realizar la transacción por verifique que cuente con conexión a internet o que la información que ingreso sea correcta.";
                }
            }
            catch (Exception exe)
            {
                Success = false;
                Reservation.Payment.Status = VolarisPaymentStatus.Unkown;
                ErrorMessage = exe.Message;
                LogError(exe.Message);
            }
        }
        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "PaymentRQ",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }

        private PaymentRQ CreateRequest()
        {

            var request = new PaymentRQ
                              {
                                  POS = new POS_Type()
                                            {
                                                PseudoCityCode = VolarisResources.PseudoCodeCity,
                                                ISOCountry = "MX",
                                                ChannelID = "WEB",
                                                LocalDateTimeSpecified = true,
                                                LocalDateTime = DateTime.Now,

                                                IP_Address = "127.0.0.1",
                                                StationNumber = "77777884"
                                            },
                                  Action = new PaymentRQAction()
                                               {
                                                   Value = "Auth"
                                               },
                                  MerchantDetail = new PaymentRQMerchantDetail
                                                       {
                                                           MerchantID = "Y4"
                                                       },
                                  Version = VolarisResources.PaymentRQServiceVersion
                              };
            request.OrderDetail = CreateOrderDetail();
            request.PaymentDetail = CreatePaymentDetail();
            return request;
        }




        private PaymentRQOrderDetail CreateOrderDetail()
        {
            var orderDetail = new PaymentRQOrderDetail
                                  {
                                      RecordLocator = Reservation.RecordLocator.Record,
                                      ThirdPartyBookingInd = false,
                                      OrderID = string.Format("{0}/270510", Reservation.RecordLocator.Record),
                                      ProductDetail = CreateProductDetail(),
                                      PassengerDetail = CreatePassangerDetailType(),
                                      ContactInfo = CreateContactInfo(),
                                      FlightDetail = CreateFlightDetails()
                                  };


            return orderDetail;


        }

        /// <summary>
        /// Creates the payment detail.
        /// </summary>
        /// <returns></returns>
        private PaymentRQPaymentDetail[] CreatePaymentDetail()
        {
            return new[]
                       {
                           new PaymentRQPaymentDetail
                               {
                                   FOP = new PaymentRQPaymentDetailFOP
                                             {
                                                 Type = "CC"
                                             },
                                 AmountDetail = new PaymentRQPaymentDetailAmountDetail
                                                    {
                                                        CurrencyCode = "MXN",
                                                        AmountSpecified = true,
                                                        
                                                        Amount = Reservation.Itinerary.TotalPrice,
                                                    },
                                PaymentCard = new PaymentRQPaymentDetailPaymentCard
                                                  {
                                                      CardCode = Reservation.Payment.CreditCardInformation.Type == VolarisCreditCardType.Visa ? "BA":"IK",
                                                      Address = CreateAddressType(),
                                                      CardHolderName = CreateCardHolder(),
                                                      PhoneNumber = CreateOwnerPhoneType(),
                                                       CardNumber = Reservation.Payment.CreditCardInformation.CreditCardNumber,
                                                       CardSecurityCode = Reservation.Payment.CreditCardInformation.SecurityCode,
                                                       ExpireDate = Reservation.Payment.CreditCardInformation.ExpirationDate.ToString("MMyyyy")
                                                  },

                               }
                       };
        }

        private PhoneType[] CreateOwnerPhoneType()
        {
            var owner = Reservation.Payment.Owner;
            return new[]
                       {
                           new PhoneType
                               {
                                  Number   = owner.Phone,
                                  Type = "B"
                               }
                       };
        }

        private PaymentCardTypeCardHolderName CreateCardHolder()
        {
            var owner = Reservation.Payment.Owner;
            return new PaymentCardTypeCardHolderName
                       {
                           Name = owner.Name,
                           LastName = owner.LastName,

                       };
        }

        private AddressType CreateAddressType()
        {

            var owner = Reservation.Payment.Owner;
            return new AddressType
                       {
                           AddressLine1 = owner.AddresLine1,
                           AddressLine2 = owner.AddressLine2,
                           CityName = owner.CityName,
                           Country = new CountryNameType
                                         {
                                             Code = owner.Country.Id
                                         },
                           StateProv = new AddressTypeStateProv
                                           {
                                               StateCode = owner.State.Id
                                           },
                           PostalCode = owner.PostalCode,

                       };

        }

        private ProductDetailType[] CreateProductDetail()
        {
            return new[]
                       {
                           new ProductDetailType
                               {
                                      ProductID = "0001",
                                      CurrencyCode = "MXN",
                                      UnitPrice = Reservation.Itinerary.TotalPrice,
                                      Quantity = 1
                               }
                       };
        }

        private PassengerDetailType[] CreatePassangerDetailType()
        {
            return Reservation.Passangers.GetAll().Select(pax => new PassengerDetailType
                                                                     {
                                                                         Name = pax.Name,
                                                                         LastName = pax.LastName,
                                                                         NameInPNR = pax.NameInRecord
                                                                     }).ToArray();
        }

        private PaymentRQOrderDetailContactInfo CreateContactInfo()
        {
            var request = new PaymentRQOrderDetailContactInfo
                              {
                                  EmailAddress = Reservation.Contact.Emails.GetAll().Select(mail => mail.Email).ToArray(),
                                  PhoneNumber = Reservation.Contact.Phones.GetAll().Select(phone => new PhoneType
                                                                                                         {
                                                                                                             Number = phone.FullNumber,
                                                                                                             Type = "B"
                                                                                                         }).ToArray()

                              };

            return request;
        }


        private FlightDetailType[] CreateFlightDetails()
        {
            var flightDetails = new List<FlightDetailType>();

            flightDetails.AddRange(CreateFlightDetails(Reservation.Itinerary.Departure));
            if (Reservation.Itinerary.Type == ItineraryType.RoundTrip)
            {
                flightDetails.AddRange(CreateFlightDetails(Reservation.Itinerary.Departure));
            }
            return flightDetails.ToArray();

        }
        private IEnumerable<FlightDetailType> CreateFlightDetails(VolarisFlight flight)
        {
            return flight.Segments.GetAll().Select(seg => new FlightDetailType
                                                              {
                                                                  AirlineCode = "Y4",
                                                                  FlightNumber = seg.ID,
                                                                  ArrivalInfo = new FlightDetailTypeArrivalInfo
                                                                                    {
                                                                                        ArrivalAirport = seg.ArrivalStation,
                                                                                        ArrivalDateTime = seg.ArrivalTime,
                                                                                        ArrivalDateTimeSpecified = true
                                                                                    },
                                                                  DepartureInfo = new FlightDetailTypeDepartureInfo
                                                                                      {
                                                                                          CurrentLocalDateTime = DateTime.Now,
                                                                                          DepartureAirport = seg.DepartureStation,
                                                                                          CurrentLocalDateTimeSpecified = true,

                                                                                          DepartureDateTime = seg.DepartureTime
                                                                                      },

                                                              }).ToArray();

        }


        #endregion
    }
}
