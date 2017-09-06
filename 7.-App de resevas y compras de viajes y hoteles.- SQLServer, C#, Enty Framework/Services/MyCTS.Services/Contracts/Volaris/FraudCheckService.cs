using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.FraudCheckProduction;
#else

using MyCTS.Services.FraudCheckTest;
#endif
namespace MyCTS.Services.Contracts.Volaris
{
    /// <summary>
    /// 
    /// </summary>
    public class FraudCheckService : ISabreService
    {

        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "FraudCheckService",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }
        /// <summary>
        /// Gets the message header.
        /// </summary>
        /// <returns></returns>
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
            messageHeader.Action = "FraudCheckRQ";
            messageHeader.Service = new Service
                                        {
                                            Value = "FraudCheckRQ"
                                        };

            messageHeader.MessageData = new MessageData
                                            {
                                                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                                                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
                                            };



            return messageHeader;
        }

        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }


        public VolarisReservation Reservation { get; set; }

        #endregion

        #region Miembros de IService


        private string GetIpAddress()
        {
            var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            var ip = (
                         from addr in hostEntry.AddressList
                         where addr.AddressFamily.ToString() == "InterNetwork"
                         select addr.ToString()
                     ).FirstOrDefault();

            return ip;
        }


        public void Call()
        {
            try
            {
                var request = GetRequest();
                var service = new FraudCheckServiceService()
                {
                    MessageHeaderValue = GetMessageHeader(),
                    SecurityValue = new Security()
                    {
                        BinarySecurityToken = SecurityToken
                    }
                };
                Serializer.Serialize("FraudCheckRQ", request);
                var response = service.FraudCheckServiceRQ(request);
                Serializer.Serialize("FraudCheckRS", response);
                if (response.FraudRemarks != null)
                {


                }
                Success = true;
            }
            catch (Exception exe)
            {
                Success = true;
                LogError(exe.Message);
            }
        }

        private FraudCheckRQ GetRequest()
        {

            var request = new FraudCheckRQ()
            {
                POS = new POS_Type()
                {
                    ChannelID = "WEB",

                    PseudoCityCode = VolarisResources.PseudoCodeCity,
                    LocalDateTime = DateTime.Now,
                    LocalDateTimeSpecified = true,
                    ISOCountry = "MX",
                    IP_Address = GetIpAddress(),
                    StationNumber = "77777884"
                },
                Version = VolarisResources.FraudCheckServiceServiceVersion
            };

            request.MerchantDetail = new FraudCheckRQMerchantDetail()
            {
                MerchantID = "Y4",
                MerchantName = "Volaris"
            };

            request.OrderDetail = CreateOrderDetail();
            request.PaymentDetail = CreatePaymentDetail();
            return request;
        }

        private FraudCheckRQOrderDetail CreateOrderDetail()
        {
            var orderDetail = new FraudCheckRQOrderDetail
                                  {
                                      OrderID = string.Format("{0}300312", Reservation.RecordLocator.Record),
                                      ThirdPartyBookingInd = true,
                                      ThirdPartyBookingIndSpecified = true,
                                      RecordLocator = Reservation.RecordLocator.Record,
                                      PassengerDetail = CreatePassangerDetail(),
                                      ContactInfo = CreateContactDetailInfo(),
                                      FlightDetail = CreateFlightDetails(),
                                      ProductDetail = CreateProductDetail(),
                                  };


            return orderDetail;

        }

        private FraudCheckRQPaymentDetail[] CreatePaymentDetail()
        {
            var paymentDetail = new FraudCheckRQPaymentDetail
                                    {
                                        FOP = new FraudCheckRQPaymentDetailFOP
                                                  {
                                                      Type = "CC"
                                                  },
                                        PaymentCard = CreateCreditCardPaymentDetail(),
                                        AmountDetail = new FraudCheckRQPaymentDetailAmountDetail
                                                           {
                                                               Amount = Reservation.Itinerary.TotalPrice,
                                                               AmountSpecified = true,
                                                               CurrencyCode = "MXN"
                                                           }
                                    };

            return new[] { paymentDetail };
        }

        #region OrderDetail
        private PassengerDetailType[] CreatePassangerDetail()
        {
            var passangersDetails = new List<PassengerDetailType>();
            foreach (var pax in Reservation.Passangers.GetAll().Where(p => !string.IsNullOrEmpty(p.eTicket)))
            {
                var paxDetail = new PassengerDetailType();
                paxDetail.Document = new[]
                                         {
                                             new PassengerDetailTypeDocument
                                                 {
                                                     DocType = "TKT",
                                                     //eTicketInd = true,
                                                     //eTicketIndSpecified = true,
                                                     DocNumber = string.Format("036{0}", pax.eTicket)
                                                 }
                                         };
                paxDetail.FirstName = pax.Name;
                paxDetail.LastName = pax.LastName;
                paxDetail.NameInPNR = pax.NameInRecord;
                passangersDetails.Add(paxDetail);
            }


            return passangersDetails.ToArray();
        }

        private FraudCheckRQOrderDetailContactInfo CreateContactDetailInfo()
        {
            var contactInfo = new FraudCheckRQOrderDetailContactInfo
                                  {
                                      EmailAddress = CreateContactInfoMails(),
                                      PhoneNumber = CreateContactPhones(),

                                  };

            return contactInfo;
        }

        private string[] CreateContactInfoMails()
        {
            var emails = new List<string>();

            foreach (var email in Reservation.Contact.Emails.GetAll())
            {
                emails.Add(email.Email);
            }
            return emails.ToArray();
        }

        private PhoneType[] CreateContactPhones()
        {
            var phones = new List<PhoneType>();
            foreach (var contactPhone in Reservation.Contact.Phones.GetAll())
            {
                var phone = new PhoneType
                                {
                                    Number = contactPhone.FullNumber,
                                    Type = "B",


                                };
                phones.Add(phone);
            }
            return phones.ToArray();

        }


        #region Flight Detail


        private FlightDetailType[] CreateFlightDetails()
        {

            var flightsDetails = new List<FlightDetailType>();

            var departureFlightSegments = CreateFlightTypeForVolarisFlight(Reservation.Itinerary.Departure);
            flightsDetails.AddRange(departureFlightSegments);

            if (Reservation.Itinerary.Type == ItineraryType.RoundTrip)
            {
                var returnFlightSegment = CreateFlightTypeForVolarisFlight(Reservation.Itinerary.Return);
                flightsDetails.AddRange(returnFlightSegment);
            }

            return flightsDetails.ToArray();
        }

        private IEnumerable<FlightDetailType> CreateFlightTypeForVolarisFlight(VolarisFlight flight)
        {
            var flightsDetails = new List<FlightDetailType>();

            if (flight != null && flight.Segments.GetAll().Any())
            {
                foreach (var segment in flight.Segments.GetAll().Cast<VolarisSegment>().ToList())
                {

                    var flightDetail = new FlightDetailType
                                           {
                                               AirlineCode = "Y4",
                                               FlightNumber = segment.ID,
                                               ClassOfService = segment.ClassOfService,
                                               DepartureInfo = new FlightDetailTypeDepartureInfo()
                                                                   {

                                                                       DepartureAirport = segment.DepartureStation,
                                                                       DepartureDateTime = segment.DepartureTime
                                                                   },
                                               ArrivalInfo = new FlightDetailTypeArrivalInfo()
                                                                 {
                                                                     ArrivalDateTimeSpecified = true,
                                                                     ArrivalAirport = segment.ArrivalStation,
                                                                     ArrivalDateTime = segment.ArrivalTime,
                                                                     FinalDestinationInd = true,
                                                                     FinalDestinationIndSpecified = true
                                                                 }
                                           };

                    flightsDetails.Add(flightDetail);
                }

            }
            return flightsDetails.ToArray();
        }



        #endregion

        #region Producto Detail


        private ProductDetailType[] CreateProductDetail()
        {
            var productDetails = new List<ProductDetailType>();


            var productDetail = new ProductDetailType
                                    {
                                        ProductID = "001",
                                        UnitPrice = Reservation.Itinerary.TotalPrice,
                                        Quantity = 1
                                    };
            productDetails.Add(productDetail);
            return productDetails.ToArray();
        }

        #endregion
        #endregion

        #region Payment Detail


        private readonly Dictionary<VolarisCreditCardType, string> _creditCardConverter =
            new Dictionary<VolarisCreditCardType, string>
                {
                    {VolarisCreditCardType.AmericanExpress, "AX"},
                    {VolarisCreditCardType.MasterCard, "CA"},
                    {VolarisCreditCardType.Visa, "BA"}

                };
        private FraudCheckRQPaymentDetailPaymentCard CreateCreditCardPaymentDetail()
        {

            var creditCardInfo = Reservation.Payment.CreditCardInformation;
            var payment = Reservation.Payment;
            var creditCardDetail = new FraudCheckRQPaymentDetailPaymentCard
                                       {
                                           CardCode = _creditCardConverter[creditCardInfo.Type],
                                           CardNumber = creditCardInfo.CreditCardNumber,
                                           ExpireDate = creditCardInfo.ExpirationDate.ToString("MMyyyy"),
                                           CardHolderName = new PaymentCardTypeCardHolderName
                                                                {
                                                                    FirstName = payment.Owner.Name,
                                                                    LastName = payment.Owner.LastName
                                                                },
                                           Address = new AddressType
                                                         {
                                                             AddressLine1 = payment.Owner.AddresLine1,
                                                             AddressLine2 = payment.Owner.AddressLine2,

                                                             CityName = payment.Owner.CityName,
                                                             Country = new CountryNameType
                                                                           {
                                                                               Code = payment.Owner.Country.Id
                                                                           },
                                                             StateProv = new AddressTypeStateProv
                                                                             {
                                                                                 StateCode = payment.Owner.State.Id
                                                                             },
                                                             PostalCode = payment.Owner.PostalCode
                                                         },
                                           EmailAddress = new[] { payment.Owner.Email },
                                           PhoneNumber = new[]{
                                                                new PhoneType{Number = payment.Owner.Phone},
                                                                new PhoneType{Number = "52 55555 52"}
                                                              }


                                       };

            return creditCardDetail;

        }


        #endregion


        #endregion
    }
}
