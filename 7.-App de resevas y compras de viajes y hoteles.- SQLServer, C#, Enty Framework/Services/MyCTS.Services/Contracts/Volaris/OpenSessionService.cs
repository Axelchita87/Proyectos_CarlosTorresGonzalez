
#if VOLARIS_PRODUCTION
using MyCTS.Services.com.sabre.webservices;
#else
using MyCTS.Services.SessionCreateTest;
#endif
using System;
using System.Web.Services.Protocols;

namespace MyCTS.Services.Contracts.Volaris
{
    public class OpenSessionService : ISabreService
    {



        #region Miembros de ISabreService

        /// <summary>
        /// Gets or sets the security token.
        /// </summary>
        /// <value>
        /// The security token.
        /// </value>
        public string SecurityToken { get; set; }

        /// <summary>
        /// Gets or sets the conversation ID.
        /// </summary>
        /// <value>
        /// The conversation ID.
        /// </value>
        public string ConversationID { get; set; }

        /// <summary>
        /// Calls this instance.
        /// </summary>
        public void Call()
        {

            try
            {
                var createRequestSession = new SessionCreateRQ
                                               {
                                                   POS =
                                                       new SessionCreateRQPOS
                                                           {
                                                               Source = new SessionCreateRQPOSSource
                                                                            {

                                                                                PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                            }

                                                           }
                                               };
                var service = new SessionCreateRQService
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = this.GetSecurityHeader(),

                                  };
                Serializer.Serialize("SessionCreateRQ", createRequestSession);
                var response = service.SessionCreateRQ(createRequestSession);
                Serializer.Serialize("SessionCreateRS", response);
                if (response.Errors != null)
                {
                    Success = false;
                    ErrorMessage = "No se pudo establecer una enlace con volaris, verifique que tenga acceso a internet, en caso de persistir el problema reportarlo a soporte tecnico.";
                    return;
                }
                this.SecurityToken = service.SecurityValue.BinarySecurityToken;
                this.ConversationID = service.MessageHeaderValue.ConversationId;
                Success = true;
            }
            catch (SoapException soapException)
            {

                var ed = soapException;
                Success = false;
                ErrorMessage = "No se pudo establecer una enlace con volaris, verifique que tenga acceso a internet, en caso de persistir el problema reportarlo a soporte tecnico.";
            }


        }



        #endregion

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
            messageHeader.Action = "SessionCreateRQ";
            messageHeader.Service = new Service
            {
                Value = "SessionCreateRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }

        /// <summary>
        /// Gets the security header.
        /// </summary>
        /// <returns></returns>
        private Security GetSecurityHeader()
        {

#if (VOLARIS_PRODUCTION)
                          var security = new Security
                        {
                            UsernameToken = new SecurityUsernameToken
                            {
                                Username = "840021",
                                Password = "CTS8SRL4",
                                Domain = "Y4",
                                Organization = "Y4"



                            }


                        };
#else


            var security = new Security
            {
                UsernameToken = new SecurityUsernameToken
                {
                    Username = "840021",
                    Password = "VOLARIS2",
                    Domain = "Y4",
                    Organization = "Y4"

                }
            };

#endif

            return security;
        }

        #region Miembros de ISabreService


        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
    }
}
