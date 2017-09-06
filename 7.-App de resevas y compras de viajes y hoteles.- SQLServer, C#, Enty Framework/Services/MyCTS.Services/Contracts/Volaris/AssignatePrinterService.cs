using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.DesignatePrinterProduction;
#else

using MyCTS.Services.DesignatePrinterTest;
#endif


namespace MyCTS.Services.Contracts.Volaris
{
    public class AssignatePrinterService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
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
            messageHeader.Action = "DesignatePrinterLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "DesignatePrinterLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }
        #region Miembros de IService


        public VolarisReservation Reservation { get; set; }
        public void Call()
        {
            try
            {
                var request = new DesignatePrinterRQ()
                                  {
                                      POS = new DesignatePrinterRQPOS()
                                                {
                                                    Source = new DesignatePrinterRQPOSSource()
                                                                 {
                                                                     PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                 }
                                                },
                                      Version = VolarisResources.DesignatePrinterServiceVersion
                                  };
                request.Printers = new DesignatePrinterRQPrinters()
                                       {
                                           Ticket = new DesignatePrinterRQPrintersTicket()
                                                        {
                                                            CountryCode = VolarisResources.CountryCode,
                                                            LineAddress = VolarisResources.LineAddres


                                                        },

                                       };
                var service = new DesignatePrinterService()
                                  {

                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                          {
                                                              BinarySecurityToken = this.SecurityToken
                                                          }
                                  };
                Serializer.Serialize("DesignatePrinterLLSRQ", request);

                var response = service.DesignatePrinterRQ(request);
                Serializer.Serialize("DesignatePrinterLLSRS", response);
                if (response.Success != null && response.Errors == null)
                {
                    Success = true;
                }
                else
                {
                    Success = false;
                    ErrorMessage = "No se puedo terminer la transacción.";
                    LogError(response.Errors.Error.ErrorMessage);




                }
            }
            catch (Exception exe)
            {
                Success = false;
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
                ServiceName = "AssignatePrinterService",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }


        #endregion
    }
}
