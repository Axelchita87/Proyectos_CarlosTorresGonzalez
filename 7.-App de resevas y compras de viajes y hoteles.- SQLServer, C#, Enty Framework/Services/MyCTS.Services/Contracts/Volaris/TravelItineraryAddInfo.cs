using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.TravelItineraryAddInfoProduction;
#else
using MyCTS.Services.TravelItineraryAddInfoTest;
#endif
namespace MyCTS.Services.Contracts.Volaris
{
    /// <summary>
    /// 
    /// </summary>
    public class TravelItineraryAddInfo : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }
        public VolarisReservation Reservation { get; set; }
        public string ConversationID { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
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
            messageHeader.Action = "TravelItineraryAddInfoLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "TravelItineraryAddInfoLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }
        #endregion

        #region Miembros de IService

        public void Call()
        {
            try
            {
                var request = CreateRequest();

                request.CustomerInfo = CreateCustomerInformation();
                request.AgencyInfo = CreateAgencyInfo();

                var service = new TravelItineraryAddInfoService()
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                          {
                                                              BinarySecurityToken = this.SecurityToken
                                                          }
                                  };
                Serializer.Serialize("TravelItineraryAddInfoLLSRQ", request);
                var response = service.TravelItineraryAddInfoRQ(request);

                Serializer.Serialize("TravelItineraryAddInfoLLSRS", response);
                if (response.Success != null && response.Errors == null)
                {
                    Success = true;
                }
                else
                {
                    LogError(response.Errors.Error.ErrorInfo.Message);
                    Success = false;
                    ErrorMessage = "No se pudo agregar información de los pasajeros, debido a que volaris no considero los datos de los pasajeros como validos, por favor verifique que la información sea correcta y en caso de persistir los problemas reporte el error a soporte tecnico.";
                }
            }
            catch (Exception exe)
            {
                Success = false;
                ErrorMessage = exe.Message;
                LogError(exe.Message);
            }


        }


        private TravelItineraryAddInfoRQAgencyInfo CreateAgencyInfo()
        {
            return new TravelItineraryAddInfoRQAgencyInfo
            {

                Address = new TravelItineraryAddInfoRQAgencyInfoAddress
                {

                    AddressLine = "Corporate Travel",
                    CityName = "Mexico",
                    CountryCode = "MX",

                    StateCountyProv =
                        new TravelItineraryAddInfoRQAgencyInfoAddressStateCountyProv
                        {
                            StateCode = "DF"
                        },
                    PostalCode = "11510",
                    StreetNmbr = "JaimeBalmes11"


                },
                Ticketing = new TravelItineraryAddInfoRQAgencyInfoTicketing
                {
                    PseudoCityCode = VolarisResources.PseudoCodeCity,
                    TicketType = "7TAW/",
                    TicketTimeLimit = string.Format("{0}T{1}", DateTime.Now.ToString("MM-dd"), DateTime.Now.AddHours(4).ToString("HH:mm:ss")),
                }


            };
        }
        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "TravelItineraryAddInfoService",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }
        private TravelItineraryAddInfoRQCustomerInfo CreateCustomerInformation()
        {
            var customerInfo = new TravelItineraryAddInfoRQCustomerInfo()
                                   {
                                       PersonName = CreatePassangersName(),
                                       Telephone = CreateTelephoneContacs(),
                                   };

            var mails = Reservation.Contact.Emails.GetAll().Select(e => new TravelItineraryAddInfoRQCustomerInfoEmail
                                                                    {
                                                                        Address = e.Email
                                                                    }).ToList();
            mails.Add(new TravelItineraryAddInfoRQCustomerInfoEmail
                          {
                              Address = Reservation.Agent.Email
                          });
            customerInfo.Email = mails.ToArray();
            return customerInfo;
        }

        /// <summary>
        /// Creates the name of the passangers.
        /// </summary>
        /// <returns></returns>
        private TravelItineraryAddInfoRQCustomerInfoPersonName[] CreatePassangersName()
        {
            return Reservation.Passangers.GetAll().Select(pax => new TravelItineraryAddInfoRQCustomerInfoPersonName()
                                                                     {
                                                                         GivenName = pax.Name,
                                                                         Surname = pax.LastName,
                                                                         Infant = (pax is VolarisInfantPassanger)
                                                                     }).ToArray();


        }
        /// <summary>
        /// Creates the telephone contacs.
        /// </summary>
        /// <returns></returns>
        private TravelItineraryAddInfoRQCustomerInfoTelephone[] CreateTelephoneContacs()
        {
            return Reservation.Contact.Phones.GetAll().Select(t => new TravelItineraryAddInfoRQCustomerInfoTelephone
                                                                       {
                                                                           AreaCityCode = t.TelephoneCityCode,
                                                                           PhoneNumber = t.Telephone

                                                                       }).ToArray();   

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns></returns>
        private TravelItineraryAddInfoRQ CreateRequest()
        {
            return new TravelItineraryAddInfoRQ
            {

                POS = new TravelItineraryAddInfoRQPOS
                {
                    Source = new TravelItineraryAddInfoRQPOSSource
                    {

                        PseudoCityCode = VolarisResources.PseudoCodeCity
                    }
                },

                Version = VolarisResources.TravelItineraryAddInfoServiceVersion

            };
        }

        #endregion
    }
}
