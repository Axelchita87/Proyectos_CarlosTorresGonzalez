using System;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.EndTransactionProduction;
#else

using MyCTS.Services.EndTransactionTest;
#endif
namespace MyCTS.Services.Contracts.Volaris
{
    public class TransactionService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        public bool Success { get; set; }
        public VolarisReservation Reservation { get; set; }
        public string ErrorMessage { get; set; }

        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "EndTransactionService",
                ErrorMessage = errorMessage

            };


            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }
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
            messageHeader.Action = "EndTransactionLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "EndTransactionLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }
        #region Miembros de IService

        public void Call()
        {
            try
            {
                var request = new EndTransactionRQ()
                                  {
                                      POS = new EndTransactionRQPOS()
                                                {
                                                    Source = new EndTransactionRQPOSSource()
                                                                 {
                                                                     PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                 }
                                                },
                                      Version = VolarisResources.EndTransactionServiceVersion
                                  };
                request.EndTransaction = new EndTransactionRQEndTransaction()
                                             {
                                                 Ind = true,
                                                 IndSpecified = true,
                                                 SendEmail = new EndTransactionRQEndTransactionSendEmail()
                                                                 {
                                                                     Ind = Reservation.Agent.RecievedEmail,
                                                                     IndSpecified = Reservation.Agent.RecievedEmail
                                                                 }
                                             };
                request.UpdatedBy = new EndTransactionRQUpdatedBy()
                                        {
                                            TPA_Extensions = new EndTransactionRQUpdatedByTPA_Extensions()
                                                                 {
                                                                     Access =
                                                                         new EndTransactionRQUpdatedByTPA_ExtensionsAccess
                                                                         ()
                                                                             {
                                                                                 AccessPerson =
                                                                                     new EndTransactionRQUpdatedByTPA_ExtensionsAccessAccessPerson
                                                                                     ()
                                                                                         {
                                                                                             GivenName = "DONE"
                                                                                         }
                                                                             }
                                                                 }
                                        };

                var service = new EndTransactionService
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                          {
                                                              BinarySecurityToken = this.SecurityToken
                                                          }
                                  };
                Serializer.Serialize("EndTransactionLLSRQ", request);
                var response = service.EndTransactionRQ(request);
                Serializer.Serialize("EndTransactionLLSRS", response);
                if (response.Success != null && response.Errors == null && response.UniqueID != null)
                {
                    Success = true;
                    Reservation.RecordLocator = new VolarisRecordLocator()
                                                    {
                                                        Record = response.UniqueID.ID,
                                                        Created = DateTime.Now

                                                    };

                }
                else
                {
                    if (response.Errors != null)
                    {
                        LogError(response.Errors.Error.ErrorInfo.Message);
                    }

                    Success = false;
                    ErrorMessage = "Ocurrió un problema al crear la reservación.";
                }
            }
            catch (Exception exe)
            {
                Success = false;
                ErrorMessage = exe.Message;
                LogError(exe.Message);


            }
        }

        #endregion
    }
}
