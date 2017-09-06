using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.com.sabre.webservices.SabreCommand;

namespace MyCTS.Services.Contracts
{
    public class SabreCommandServiceManager
    {

        public SabreCommandServiceManager()
        {
            this.ResponseFromServer = "";
        }

        public string ResponseFromServer
        {
            get;
            set;
        }

        public void SendCommand(string commandToSend)
        {

            using(WSSessionSabre session = new WSSessionSabre())
            {
                try
                {
                    session.OpenConnection();
                    if (session.IsConnected)
                    {

                        SabreCommandLLSService service = new SabreCommandLLSService();
                        service.MessageHeaderValue = new MessageHeader();
                        service.MessageHeaderValue.ConversationId = session.ConversationId;
                        service.MessageHeaderValue.Action = "SabreCommandLLSRQ";
                        service.MessageHeaderValue.CPAId = session.IPcc;
                        service.MessageHeaderValue.From = new From();

                        From from = new From();
                        PartyId partyId = new PartyId();
                        partyId.Value = "9999";
                        from.PartyId = new PartyId[] { partyId };

                        service.MessageHeaderValue.From = from;

                        service.MessageHeaderValue.To = new To();

                        To to = new To();
                        PartyId newPartyId = new PartyId();
                        newPartyId.Value = "123123";
                        to.PartyId = new PartyId[] { newPartyId };
                        service.MessageHeaderValue.To = to;



                        service.SecurityValue = new Security();
                        service.SecurityValue.BinarySecurityToken = session.SecurityToken;

                        SabreCommandLLSRQ request = new SabreCommandLLSRQ();
                        request.Request = new SabreCommandLLSRQRequest();
                        request.Request.HostCommand = commandToSend;
                        request.Target = SabreCommandLLSRQTarget.Test;
                        request.Request.Output = SabreCommandLLSRQRequestOutput.SDSXML;
                        request.TimeStamp = new TimeSpan().ToString();


                        SabreCommandLLSRS response = service.SabreCommandLLSRQ(request);

                        this.ResponseFromServer = response.Response;

                    }
                }
                catch (Exception exception)
                {
                    this.ResponseFromServer = "";
                }
                
            }


        }
    }
}
