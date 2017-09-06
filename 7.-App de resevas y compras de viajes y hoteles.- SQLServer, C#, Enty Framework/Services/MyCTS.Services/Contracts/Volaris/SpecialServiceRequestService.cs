using System;
using System.Collections.Generic;
using System.Linq;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.SpecialServiceProduction;
#else

using MyCTS.Services.SpecialServiceTest;
#endif

namespace MyCTS.Services.Contracts.Volaris
{
    /// <summary>
    /// 
    /// </summary>
    public class SpecialServiceRequestService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }
        public VolarisReservation Reservation { get; set; }
        public string ErrorMessage { get; set; }
        #endregion
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
            messageHeader.Action = "SpecialServiceLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "SpecialServiceLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }

        private Dictionary<VolarisSepecialServiceType, string> _ssrConverter =
            new Dictionary<VolarisSepecialServiceType, string>()
                {
                    {VolarisSepecialServiceType.WheelChair, "WCHR"},
                    {VolarisSepecialServiceType.PassangerMostBeGuided, "WCHR"},
                    {VolarisSepecialServiceType.SecureFlight,"DOCSA"},
                    {VolarisSepecialServiceType.Infant, "INFT"}
                };
        #region Miembros de IService

        /// <summary>
        /// Creates the services.
        /// </summary>
        /// <returns></returns>
        private SpecialServiceRQService[] CreateServices()
        {
            var services = new List<SpecialServiceRQService>();

            var passangers = Reservation.Passangers.GetAll();
            if (passangers.Any())
            {
                foreach (var pax in passangers)
                {

                    services.AddRange(GetServices(pax));
                }
            }


            return services.ToArray();
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="pax">The pax.</param>
        /// <returns></returns>
        private IEnumerable<SpecialServiceRQService> GetServices(IVolarisPassanger pax)
        {
            var services = new List<SpecialServiceRQService>();


            foreach (var specialService in pax.SpecialServices.GetAllService())
            {
                if (_repositoryConverter.ContainsKey(specialService.Type))
                {
                    var service = _repositoryConverter[specialService.Type](pax);
                    if (service != null)
                    {
                        services.Add(service);
                    }
                }
            }


            return services;
        }


        private readonly Dictionary<VolarisSepecialServiceType, Func<IVolarisPassanger, SpecialServiceRQService>>
            _repositoryConverter
                = new Dictionary<VolarisSepecialServiceType, Func<IVolarisPassanger, SpecialServiceRQService>>
                      {
                          {VolarisSepecialServiceType.PassangerMostBeGuided, GetServiceForWheelChairAndPaxMusBeGuided},
                          {VolarisSepecialServiceType.WheelChair, GetServiceForWheelChairAndPaxMusBeGuided},
                          {VolarisSepecialServiceType.Infant, GetServiceForInfant},
                          {VolarisSepecialServiceType.SecureFlight, GetServiceForSecureFlight}
                      };


        private static SpecialServiceRQService GetServiceForWheelChairAndPaxMusBeGuided(IVolarisPassanger pax)
        {

            var service = new SpecialServiceRQService
                              {
                              };
            service.Airline = new SpecialServiceRQServiceAirline() { Code = "Y4", HostedCarrier = true };
            service.SSRCode = "WCHC";
            service.TPA_Extensions = new SpecialServiceRQServiceTPA_Extensions()
                                         {
                                             Name = new SpecialServiceRQServiceTPA_ExtensionsName()
                                                        {
                                                            Number = pax.Number,
                                                            NumberSpecified = true
                                                        },
                                           Segment = new SpecialServiceRQServiceTPA_ExtensionsSegment()
                                                         {
                                                             Number = "1"
                                                         }
                                         };

            return service;
        }

        private static SpecialServiceRQService GetServiceForInfant(IVolarisPassanger pax)
        {

            var infant = pax as VolarisInfantPassanger;
            if (infant != null)
            {
                var service = new SpecialServiceRQService
                                  {
                                  };
                service.Airline = new SpecialServiceRQServiceAirline() { Code = "Y4", HostedCarrier = true };
                service.SSRCode = "INFT";
                service.Text = infant.SSRCommand;
                service.TPA_Extensions = new SpecialServiceRQServiceTPA_Extensions()
                                             {
                                                 Name = new SpecialServiceRQServiceTPA_ExtensionsName()
                                                            {
                                                                Number = infant.AssignedPassanger.Number,
                                                                NumberSpecified = true
                                                            }
                                             };
                return service;
            }
            return null;

        }
        private static SpecialServiceRQService GetServiceForSecureFlight(IVolarisPassanger pax)
        {

            if (!(pax is VolarisInfantPassanger))
            {
                var service = new SpecialServiceRQService
                                  {
                                  };
                service.Airline = new SpecialServiceRQServiceAirline() {Code = "Y4", HostedCarrier = true};
                service.SSRCode = "DOCSA";
                service.Text = pax.SecureFlightCommand;
                service.TPA_Extensions = new SpecialServiceRQServiceTPA_Extensions()
                                             {
                                                 Name = new SpecialServiceRQServiceTPA_ExtensionsName()
                                                            {
                                                                Number = pax.Number,
                                                                NumberSpecified = true
                                                            }
                                             };

                return service;
            }
            return null;
        }



        public void Call()
        {
            try
            {

                var request = new SpecialServiceRQ()
                {
                    POS = new SpecialServiceRQPOS()
                    {
                        Source = new SpecialServiceRQPOSSource()
                        {
                            PseudoCityCode = VolarisResources.PseudoCodeCity
                        }
                    },
                    Version = VolarisResources.SpecialServiceServiceVersion
                };
                request.Service = CreateServices();

                var service = new SpecialService()
                {
                    MessageHeaderValue = this.GetMessageHeader(),
                    SecurityValue = new Security()
                    {
                        BinarySecurityToken = this.SecurityToken
                    }
                };
                Serializer.Serialize("SpecialServiceLLSRQ", request);
                var response = service.SpecialServiceRQ(request);
                Serializer.Serialize("SpecialServiceLLSRS", response);
                if (response.Success != null && response.Errors == null)
                {
                    Success = true;
                }
                else
                {
                    Success = false;
                    ErrorMessage = "No se agregaron correctamente los servicios especiales";
                }


            }
            catch (Exception exe)
            {
                Success = false;
                ErrorMessage = "No se agregaron correctamente los servicios especiales";
            }
        }

        #endregion
    }
}
