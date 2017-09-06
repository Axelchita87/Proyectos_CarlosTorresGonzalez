using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.AirTicketProduction;
#else

using MyCTS.Services.AirTicketTest;
#endif
namespace MyCTS.Services.Contracts.Volaris
{
    public class AirTicketPaymentService : ISabreService
    {
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
            messageHeader.Action = "AirTicketLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "AirTicketLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };





            return messageHeader;
        }

        public VolarisReservation Reservation { get; set; }
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Miembros de IService

        public void Call()
        {
            try
            {
                var request = new AirTicketRQ
                                  {
                                      POS = new AirTicketRQPOS()
                                                {
                                                    Source = new AirTicketRQPOSSource()
                                                                 {
                                                                     PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                 }
                                                },
                                      Version = VolarisResources.AirTicketServiceVersion

                                  };

                var creditCardInformation = Reservation.Payment.CreditCardInformation;

                request.OptionalQualifiers = new AirTicketRQOptionalQualifiers()
                                                 {
                                                     FOPQualifiers = new AirTicketRQOptionalQualifiersFOPQualifiers()
                                                                         {
                                                                             SingleFOP =
                                                                                 new AirTicketRQOptionalQualifiersFOPQualifiersSingleFOP
                                                                                 ()
                                                                                     {
                                                                                         CCInfo =
                                                                                             new AirTicketRQOptionalQualifiersFOPQualifiersSingleFOPCCInfo
                                                                                             ()
                                                                                                 {
                                                                                                     CreditCardNumber =
                                                                                                         new AirTicketRQOptionalQualifiersFOPQualifiersSingleFOPCCInfoCreditCardNumber
                                                                                                         ()
                                                                                                             {


                                                                                                                 Code =
                                                                                                                     creditCardInformation
                                                                                                                     .
                                                                                                                     CreditCardNumber
                                                                                                             },
                                                                                                     CreditCardExpiration
                                                                                                         =
                                                                                                         new AirTicketRQOptionalQualifiersFOPQualifiersSingleFOPCCInfoCreditCardExpiration
                                                                                                         ()
                                                                                                             {

                                                                                                                 ExpireDate
                                                                                                                     =
                                                                                                                     creditCardInformation
                                                                                                                     .
                                                                                                                     ExpirationDate
                                                                                                                     .
                                                                                                                     ToString
                                                                                                                     ("yyyy-MM",
                                                                                                                      new CultureInfo
                                                                                                                          ("en-US"))
                                                                                                             },
                                                                                                     ManualApproval =
                                                                                                         new AirTicketRQOptionalQualifiersFOPQualifiersSingleFOPCCInfoManualApproval
                                                                                                         ()
                                                                                                             {
                                                                                                                 Code = Reservation.Payment.ManualApprovalCode
                                                                                                             },
                                                                                                     CreditCardVendor =
                                                                                                         new AirTicketRQOptionalQualifiersFOPQualifiersSingleFOPCCInfoCreditCardVendor
                                                                                                         ()
                                                                                                             {
                                                                                                                 Code = Reservation.Payment.CreditCardInformation.CreditCardStringType

                                                                                                             }
                                                                                                 },
                                                                                         Type = "CC"

                                                                                     }
                                                                         },
                                                     PricingQualifiers =
                                                         new AirTicketRQOptionalQualifiersPricingQualifiers()
                                                             {
                                                                 BasicPrice = new[]
                                                                                  {
                                                                                      new AirTicketRQOptionalQualifiersPricingQualifiersBasicPrice
                                                                                          
                                                                                          {
                                                                                              PQNumber = "1"
                                                                                          },
                                                                                  }

                                                             }
                                                 };

                var service = new AirTicketService
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                          {
                                                              BinarySecurityToken = this.SecurityToken
                                                          }
                                  };
                Serializer.Serialize("AirTicketLLSRQ", request);
                var response = service.AirTicketRQ(request);
                Serializer.Serialize("AirTicketLLSRS", response);
                if (response.Success != null && response.Errors == null)
                {

                    if (response.Text != null)
                    {
                        var result = response.Text.FirstOrDefault(t => !string.IsNullOrEmpty(t));
                        if (!string.IsNullOrEmpty(result))
                        {
                            var responseText = result.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToList();
                            if (responseText.Any() && responseText.Count > 10)
                            {

                                // Asumiendo que ya se aprobo por PaymentRQ
                                if (!Reservation.Payment.HasBeenApproved)
                                {
                                    var authoCode = responseText[8];
                                    Reservation.Agent.RecievedEmail = true;
                                    Reservation.Payment.ManualApprovalCode = authoCode;
                                    Reservation.Payment.Status = VolarisPaymentStatus.Approved;
                                    VolarisLogger.InsertReservation();
                                }
                                Success = true;
                            }
                            else
                            {
                                ErrorMessage = "No se pudo concluir el pago de la reservación, debido a que la tarjeta fue declinada,por favor verifique que los datos sean correctos.";
                                Success = false;
                                Reservation.Payment.Status = VolarisPaymentStatus.Declined;

                                if (response.Text.Any())
                                {
                                    LogError(response.Text.FirstOrDefault());
                                }
                            }

                        }
                        else
                        {
                            ErrorMessage = "No se pudo concluir el pago de la reservación, debido a que la tarjeta fue declinada,por favor verifique que los datos sean correctos.";
                            Success = false;
                            Reservation.Payment.Status = VolarisPaymentStatus.Declined;
                            if (response.Text.Any())
                            {
                                LogError(response.Text.FirstOrDefault());
                            }
                        }

                    }


                }
                else
                {
                    Reservation.Payment.Status = VolarisPaymentStatus.Declined;
                    var error = response.Errors.Error.ErrorInfo.Message;
                    LogError(error);
                    Success = false;
                }
            }
            catch (Exception exe)
            {
                Reservation.Payment.Status = VolarisPaymentStatus.Declined;
                Success = false;
                LogError(exe.Message);
            }


        }


        private readonly Dictionary<string, string> _errorMessageDictionary = new Dictionary<string, string>
                                                                           {
                                                                               {"invalid credit card","El numero de tarjeta es invalido,por favor verifique que el numero de tarjeta corresponda con el tipo de tarjeta seleccionado."},
                                                                               {"incorrect credit card","El numero de tarjeta es invalido,por favor verifique que el numero de tarjeta corresponda con el tipo de tarjeta seleccionado."},
                                                                               {"se excedió el tiempo de espera de la operación","No se pudo establecer comunicación con volaris, por favor intente de nuevo o verifique que cuente con conexion internet."}
                                                                           };

        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "AirTicketPaymentService",
                ErrorMessage = errorMessage

            };
            var result = _errorMessageDictionary.FirstOrDefault(d => errorMessage.ToLower().Contains(d.Key));
            ErrorMessage = result.Key != null ? result.Value : "No se pudo concluir el pago de la reservación, debido a que la tarjeta fue declinada.";
            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }

        #endregion
    }
}
