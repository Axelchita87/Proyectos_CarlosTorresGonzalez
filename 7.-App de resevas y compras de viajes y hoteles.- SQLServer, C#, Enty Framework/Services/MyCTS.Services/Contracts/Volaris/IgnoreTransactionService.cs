using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if (VOLARIS_PRODUCTION)

#else
using System.Web.Services.Protocols;
using MyCTS.Entities;
using MyCTS.Services.IgnoreTransanctionTest;
#endif

namespace MyCTS.Services.Contracts.Volaris
{
    public class IgnoreTransactionService : ISabreService
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
            messageHeader.Action = "IgnoreTransactionLLSRQ";
            messageHeader.Service = new Service
                                        {
                                            Value = "IgnoreTransactionLLSRQ"
                                        };

            messageHeader.MessageData = new MessageData
                                            {
                                                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                                                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
                                            };



            return messageHeader;
        }



        public void Call()
        {
            try
            {
                var request = new IgnoreTransactionRQ()
                                  {
                                      POS = new IgnoreTransactionRQPOS()
                                                {
                                                    Source = new IgnoreTransactionRQPOSSource()
                                                                 {

                                                                     PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                 }
                                                },
                                      Version = VolarisResources.IgnoreTransactionServiceVersion
                                  };
                request.IgnoreTransaction = new IgnoreTransactionRQIgnoreTransaction()
                                                {
                                                    
                                                    Ind = true
                                                };
                var service = new IgnoreTransanctionTest.IgnoreTransactionService()
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                           {
                                                               BinarySecurityToken = this.SecurityToken
                                                           }
                                  };

                Serializer.Serialize("IgnoreTransactionLLSRQ", request);
                var response = service.IgnoreTransactionRQ(request);
                Serializer.Serialize("IgnoreTransactionLLSRS", response);
                if (response.Errors == null && response.Success  != null)
                {
                    Success = true;
                }
                else
                {
                    ErrorMessage = "Ocurrió un problema al tratar de ignorar la reservación.";
                    Success = false;
                }
            }
            catch (Exception e)
            {
                Success = false;
                ErrorMessage = e.Message;
            }

        }
    }
}
