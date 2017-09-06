using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public class DinBuilder : IEndRecordBuilder
    {

        public DinBuilder()
        {

            Comunicator = new EndRecordAPIComunicator();
            _actions = new Dictionary<string, Action>
                           {
                               {"PAC TO VERIFY",ReSendDIN}
                           };
        }

        private void ReSendDIN()
        {
            const string command = "DIN";
            Comunicator.SendMessage("Envio de DIN");

            var response = Comunicator.SendCommand(command);
            HandleResponse(response);
        }

        private void HandleResponse(string response)
        {
            var actionToExecute = _actions.FirstOrDefault(e => response.Contains(e.Key));
            if (actionToExecute.Key != null)
            {
                _actions[actionToExecute.Key]();
            }
            else
            {
                if (response.Contains("INVOICED"))
                {
                    Success = true;
                    IsInvoiced = true;
                }
                else
                {
                    Success = false;
                    ErrorMessage = "Ocurrio un error al tratar de facturar la reservación.";
                }
            }

        }

        #region Miembros de IEndRecordBuilder

        private readonly Dictionary<string, Action> _actions;

        public void Build()
        {
            const string command = "DIN";
            //Comunicator.SendMessage("Envio de DIN");
            //Success = true;
            //IsInvoiced = true;
            var response = Comunicator.SendCommand(command);
            HandleResponse(response);

        }

        public EndRecordAPIComunicator Comunicator { get; set; }

        public bool Success { get; set; }

        public bool IsInvoiced { get; set; }

        public string SabrePnr { get; set; }

        public bool HasPnr { get; set; }

        public string AgentQueue { get; set; }

        public string AgentFullName { get; set; }

        public string PseudoCityCode { get; set; }

        public string MessageOnProgress { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
    }
}
