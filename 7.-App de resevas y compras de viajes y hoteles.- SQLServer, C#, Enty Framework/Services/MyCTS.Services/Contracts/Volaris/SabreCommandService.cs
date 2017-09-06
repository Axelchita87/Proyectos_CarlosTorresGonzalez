using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.com.sabre.webservices.SabreCommand;
#else

using MyCTS.Services.SabreCommandTest;
#endif
namespace MyCTS.Services.Contracts.Volaris
{
    public class SabreCommandService : ISabreService
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
            messageHeader.Action = "SabreCommandLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "SabreCommandLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }
        #region Miembros de IService

        public void Call()
        {
            try
            {
                var request = new SabreCommandLLSRQ
                {
                    Request = new SabreCommandLLSRQRequest
                    {
                        HostCommand = "SI5"
                    },
                    Version = VolarisResources.SabreCommandServiceVersion

                };

                var service = new SabreCommandLLSService
                {

                    MessageHeaderValue = this.GetMessageHeader(),
                    SecurityValue = new Security
                    {
                        BinarySecurityToken = this.SecurityToken
                    }
                };

                Serializer.Serialize("SabreCommandLLSRQ", request);
                var response = service.SabreCommandLLSRQ(request);
                Serializer.Serialize("SabreCommandLLSRS", response);
                if (response.ErrorRS == null)
                {
                    Success = true;

                }
                else
                {
                    Success = false;
                    ErrorMessage = "No se pudo establecer coneccion con los servicios.";
                }
            }
            catch (Exception ex)
            {

                Success = true;
                ErrorMessage = ex.Message;

            }

        }

        #endregion
    }
}
