using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;
using MyCTS.Presentation.Reservations.Availability.Volaris.Mailer;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class EchoRomeoBuilder : IEndRecordBuilder
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EchoRomeoBuilder"/> class.
        /// </summary>
        public EchoRomeoBuilder()
        {
            Comunicator = new EndRecordAPIComunicator();
            _actions = new Dictionary<string, Action>
                           {
                               {"CONNX TIME SEG",SendAnotherER},
                               {"DUPLICATES NAMES",CancelOnDuplicates}
                           };
        }

        /// <summary>
        /// Cancels the on duplicates.
        /// </summary>
        private void CancelOnDuplicates()
        {
            Success = false;
            ErrorMessage =
                "Existen nombres de pasajeros con nombres duplicados, por favor verifique que los pasajeros no tengan los mismos nombres.";

        }

        /// <summary>
        /// Sends another ER.
        /// </summary>
        private void SendAnotherER()
        {
            const string command = "ER";
            var response = Comunicator.SendCommand(command);
            HandleResponse(response);
        }

        #region Implementation of IEndRecordBuilder

        private readonly Dictionary<string, Action> _actions;

        private const string ResponseSuccess = "\n*";

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public void Build()
        {
            const string command = "ER";
            var response = Comunicator.SendCommand(command);

            if (!string.IsNullOrEmpty(response))
            {
                HandleResponse(response);
            }


        }

        /// <summary>
        /// Handles the response.
        /// </summary>
        /// <param name="response">The response.</param>
        private void HandleResponse(string response)
        {
            var action = _actions.FirstOrDefault(e => response.Contains(e.Key));
            if (action.Key != null)
            {
                _actions[action.Key]();

            }
            else if(response.Contains("VERIFY"))
            {
                SendAnotherER();
            }
            else
            {
                LookUpForPnr(response);
            }

        }


        /// <summary>
        /// Looks up for PNR.
        /// </summary>
        /// <param name="response">The response.</param>
        private void LookUpForPnr(string response)
        {
            try
            {
                var pnr = response.Split('\n')[0];
                var regex = new Regex("[A-Z]{6}");
                bool isPnr = regex.Match(pnr).Success;
                if (isPnr)
                {


                    SabrePnr = pnr;
                    HasPnr = true;
                    Success = true;
                }

            }
            catch
            {
                Success = false;
            }
        }
        /// <summary>
        /// Gets or sets the comunicator.
        /// </summary>
        /// <value>
        /// The comunicator.
        /// </value>
        public EndRecordAPIComunicator Comunicator { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EchoRomeoBuilder"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        public bool IsInvoiced { get; set; }

        /// <summary>
        /// Gets or sets the sabre PNR.
        /// </summary>
        /// <value>
        /// The sabre PNR.
        /// </value>
        public string SabrePnr { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has PNR.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has PNR; otherwise, <c>false</c>.
        /// </value>
        public bool HasPnr { get; set; }
        /// <summary>
        /// Gets or sets the agent queue.
        /// </summary>
        /// <value>
        /// The agent queue.
        /// </value>
        public string AgentQueue { get; set; }
        /// <summary>
        /// Gets or sets the full name of the agent.
        /// </summary>
        /// <value>
        /// The full name of the agent.
        /// </value>
        public string AgentFullName { get; set; }

        /// <summary>
        /// Gets or sets the pseudo city code.
        /// </summary>
        /// <value>
        /// The pseudo city code.
        /// </value>
        public string PseudoCityCode { get; set; }

        /// <summary>
        /// Gets or sets the message on progress.
        /// </summary>
        /// <value>
        /// The message on progress.
        /// </value>
        public string MessageOnProgress { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        #endregion
    }
}
