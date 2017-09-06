using System;
using System.Linq;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.AddRemarkProduction;
#else

using MyCTS.Services.AddRemarkTest;
#endif

namespace MyCTS.Services.Contracts.Volaris
{
    public class AddRemarksService : ISabreService
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
            messageHeader.Action = "AddRemarkLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "AddRemarkLLSRQ"
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
                var request = GetRequest();
                var service = new AddRemarkService()
                    {
                        MessageHeaderValue = this.GetMessageHeader(),
                        SecurityValue = new Security()
                                            {

                                                BinarySecurityToken = this.SecurityToken
                                            }
                    };
                Serializer.Serialize("AddRemarkLLSRQ", request);
                var response = service.AddRemarkRQ(request);
                Serializer.Serialize("AddRemarkLLSRS", response);
                if (response.Errors == null && response.Success != null)
                {
                    Success = true;
                }


            }
            catch (Exception exe)
            {
                Success = true;
            }

        }


        private AddRemarkRQ GetRequest()
        {
            var request = new AddRemarkRQ()
            {
                POS = new AddRemarkRQPOS()
                {
                    Source = new AddRemarkRQPOSSource()
                    {
                        PseudoCityCode = VolarisResources.PseudoCodeCity
                    }
                },
                Version = VolarisResources.AddRemarkServiceVersion

            };

            request.HistoricalRemark = Reservation.Payment.HistoricalRemarks.Select(r => new AddRemarkRQHistoricalRemark
                                                                                             {
                                                                                                 Text = r
                                                                                             }).ToArray();
            return request;
        }
        #endregion
    }
}
