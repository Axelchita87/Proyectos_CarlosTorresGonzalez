using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.com.sabre.webservices1;
#else

using MyCTS.Services.SessionCloseTest;

#endif

namespace MyCTS.Services.Contracts.Volaris
{
    public class CloseSessionService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

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
            messageHeader.Action = "SessionCloseRQ";
            messageHeader.Service = new Service
            {
                Value = "SessionCloseRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }
        public string ConversationID { get; set; }

        public void Call()
        {
            try
            {
                var request = new SessionCloseRQ()
                                  {
                                      POS = new SessionCloseRQPOS()
                                                {
                                                    Source = new SessionCloseRQPOSSource()
                                                                 {
                                                                     PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                 }
                                                },

                                  };

                var service = new SessionCloseRQService()
                                  {
                                      SecurityValue = new Security()
                                                          {
                                                              BinarySecurityToken = this.SecurityToken
                                                          },
                                      MessageHeaderValue = this.GetMessageHeader()


                                  };

                Serializer.Serialize("SessionCloseRQ", request);
                var response = service.SessionCloseRQ(request);
                Serializer.Serialize("SessionCloseRS", response);
                if (response.Errors == null)
                {
                    Success = true;
                }
                else
                {
                    ErrorMessage = response.Errors.Error.ErrorMessage;
                }

            }
            catch (Exception exe)
            {
                Success = false;
                var e = exe;
            }


        }

        #endregion

        #region Miembros de ISabreService


        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
    }
}
