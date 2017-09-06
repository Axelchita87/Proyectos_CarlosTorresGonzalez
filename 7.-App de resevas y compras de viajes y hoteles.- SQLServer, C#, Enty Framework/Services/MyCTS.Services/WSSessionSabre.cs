using System;
using System.Collections.Generic;
using System.Text;
#if (VOLARIS_PRODUCTION)
using serviceOpen = MyCTS.Services.com.sabre.webservices;
using serviceClose = MyCTS.Services.com.sabre.webservices1;
#else
using serviceOpen = MyCTS.Services.SessionCreateTest;
using serviceClose = MyCTS.Services.SessionCloseTest;
#endif
using MyCTS.Business;
using MyCTS.Entities;



namespace MyCTS.Services
{
    public class WSSessionSabre : IDisposable
    {
        #region Propiedades
        private string conversationId;
        public string ConversationId
        {
            get { return conversationId; }
            set { conversationId = value; }
        }

        private string securityToken;
        public string SecurityToken
        {
            get { return securityToken; }
            set { securityToken = value; }
        }

        private string ipcc;
        public string IPcc
        {
            get { return ipcc; }
            set { ipcc = value; }
        }

        private DateTime dateReference;
        public DateTime DateReference
        {
            get { return dateReference; }
            set { dateReference = value; }
        }

        private bool isConnected = false;
        public bool IsConnected
        {
            get { return isConnected; }
        }
        #endregion


        /// <summary>
        /// Inicializa la conexión con los servicios de sabre
        /// </summary>
        public WSSessionSabre()
        {
        }

        /// <summary>
        /// Inicializa la conexión con los servicios de sabre
        /// </summary>
        /// <param name="createConnection">True = Inicializa la conexión</param>
        public WSSessionSabre(bool createConnection)
        {
            this.OpenConnection();
        }

        public void OpenConnection()
        {
            if (this.IsConnected)
                return;

            try
            {
                Parameter parameterFirm = ParameterBL.GetParameterValue("FirmWS");
                Parameter parameterPassword = ParameterBL.GetParameterValue("PasswordWS");
                Parameter parameterPCC = ParameterBL.GetParameterValue("PCCWS");
                    string username = parameterFirm.Values;
                string password = parameterPassword.Values;
                string domain = "DEFAULT";
                this.IPcc = parameterPCC.Values;
                this.ConversationId = "TestSession";

                DateTime dt = DateTime.UtcNow;
                string tstamp = dt.ToString("s") + "Z";

                serviceOpen.MessageHeader msgHeader = GetOpenMessageHeader();

                serviceOpen.Security security = new serviceOpen.Security();
                serviceOpen.SecurityUsernameToken securityUserToken = new serviceOpen.SecurityUsernameToken();
                securityUserToken.Username = username;
                securityUserToken.Password = password;
                securityUserToken.Organization = this.IPcc;
                securityUserToken.Domain = domain;
                security.UsernameToken = securityUserToken;


                serviceOpen.SessionCreateRQ req = new serviceOpen.SessionCreateRQ();
                serviceOpen.SessionCreateRQPOS pos = new serviceOpen.SessionCreateRQPOS();
                serviceOpen.SessionCreateRQPOSSource source = new serviceOpen.SessionCreateRQPOSSource();
                source.PseudoCityCode = this.IPcc;
                pos.Source = source;
                req.POS = pos;

                serviceOpen.SessionCreateRQService serviceObj = new serviceOpen.SessionCreateRQService();
                serviceObj.MessageHeaderValue = msgHeader;
                serviceObj.SecurityValue = security;


                serviceOpen.SessionCreateRS resp = serviceObj.SessionCreateRQ(req);	// Send the request

                if (resp.Errors != null && resp.Errors.Error != null)
                {
                    string x = "Error : " + resp.Errors.Error.ErrorInfo.Message;
                }
                else
                {
                    msgHeader = serviceObj.MessageHeaderValue;
                    security = serviceObj.SecurityValue;

                    this.ConversationId = msgHeader.ConversationId; // ConversationId to a string
                    this.SecurityToken = security.BinarySecurityToken;// BinarySecurityToken to a string
                    this.DateReference = DateTime.Now;
                    this.isConnected = true;
                }


            }
            catch
            {
                this.isConnected = false;
            }
        }

        /// <summary>
        /// Obtiene la cabecera para abrir mensaje enviado por 
        /// los servicios de sabre 
        /// </summary>
        /// <returns>Cabecera para que abre conexión</returns>
        private serviceOpen.MessageHeader GetOpenMessageHeader()
        {
            DateTime dt = DateTime.UtcNow;
            string tstamp = dt.ToString("s") + "Z";

            //Create the message header and provide the conversation ID.
            serviceOpen.MessageHeader msgHeader = new serviceOpen.MessageHeader();
            msgHeader.ConversationId = this.ConversationId;		// Set the ConversationId

            serviceOpen.From from = new serviceOpen.From();
            serviceOpen.PartyId fromPartyId = new serviceOpen.PartyId();
            serviceOpen.PartyId[] fromPartyIdArr = new serviceOpen.PartyId[1];
            fromPartyId.Value = "99999";
            fromPartyIdArr[0] = fromPartyId;
            from.PartyId = fromPartyIdArr;
            msgHeader.From = from;

            serviceOpen.To to = new serviceOpen.To();
            serviceOpen.PartyId toPartyId = new serviceOpen.PartyId();
            serviceOpen.PartyId[] toPartyIdArr = new serviceOpen.PartyId[1];
            toPartyId.Value = "123123";
            toPartyIdArr[0] = toPartyId;
            to.PartyId = toPartyIdArr;
            msgHeader.To = to;

            //Add the value for eb:CPAId, which is the IPCC. 
            //Add the value for the action code of this Web service, SessionCreateRQ.

            msgHeader.CPAId = ipcc;
            msgHeader.Action = "SessionCreateRQ";
            serviceOpen.Service service = new serviceOpen.Service();
            service.Value = "SessionCreate";
            msgHeader.Service = service;

            serviceOpen.MessageData msgData = new serviceOpen.MessageData();
            msgData.MessageId = "mid:20001209-133003-2333@clientofsabre.com";
            msgData.Timestamp = tstamp;
            msgHeader.MessageData = msgData;

            return msgHeader;

        }

        /// <summary>
        /// Obtiene la cabecera para cerrar mensaje enviado por 
        /// los servicios de sabre 
        /// </summary>
        /// <returns>Cabecera para que cierra conexción</returns>
        private serviceClose.MessageHeader GetCloseMessageHeader()
        {
            DateTime dt = DateTime.UtcNow;
            string tstamp = dt.ToString("s") + "Z";

            serviceClose.MessageHeader msgHeader = new serviceClose.MessageHeader();
            msgHeader.ConversationId = this.ConversationId;		// Set the ConversationId

            serviceClose.From from = new serviceClose.From();
            serviceClose.PartyId fromPartyId = new serviceClose.PartyId();
            serviceClose.PartyId[] fromPartyIdArr = new serviceClose.PartyId[1];
            fromPartyId.Value = "99999";
            fromPartyIdArr[0] = fromPartyId;
            from.PartyId = fromPartyIdArr;
            msgHeader.From = from;

            serviceClose.To to = new serviceClose.To();
            serviceClose.PartyId toPartyId = new serviceClose.PartyId();
            serviceClose.PartyId[] toPartyIdArr = new serviceClose.PartyId[1];
            toPartyId.Value = "123123";
            toPartyIdArr[0] = toPartyId;
            to.PartyId = toPartyIdArr;
            msgHeader.To = to;

            msgHeader.CPAId = ipcc;
            msgHeader.Action = "SessionCloseRQ";
            serviceClose.Service service = new serviceClose.Service();
            service.Value = "SessionClose";
            msgHeader.Service = service;

            serviceClose.MessageData msgData = new serviceClose.MessageData();
            msgData.MessageId = "mid:20001209-133003-2333@clientofsabre.com";
            msgData.Timestamp = tstamp;
            msgHeader.MessageData = msgData;

            return msgHeader;

        }

        public void CloseConnection()
        {
            this.Dispose();
        }


        #region IDisposable Members

        /// <summary>
        /// Libera conexiones y sesiones de sabre
        /// </summary>
        public void Dispose()
        {
            try
            {

                if (!this.isConnected) return;

                serviceClose.MessageHeader msgHeader = this.GetCloseMessageHeader();
                serviceClose.Security security = new serviceClose.Security();
                security.BinarySecurityToken = this.SecurityToken;		// Put BinarySecurityToken in req header


                serviceClose.SessionCloseRQ req = new serviceClose.SessionCloseRQ();
                serviceClose.SessionCloseRQPOS pos = new serviceClose.SessionCloseRQPOS();
                serviceClose.SessionCloseRQPOSSource source = new serviceClose.SessionCloseRQPOSSource();
                source.PseudoCityCode = this.IPcc;
                pos.Source = source;
                req.POS = pos;

                serviceClose.SessionCloseRQService serviceObj = new serviceClose.SessionCloseRQService();
                serviceObj.MessageHeaderValue = msgHeader;
                serviceObj.SecurityValue = security;

                serviceClose.SessionCloseRS resp = serviceObj.SessionCloseRQ(req);	// Send the request
            }
            catch (Exception e)
            {

            }
        }
        #endregion

    }
}
