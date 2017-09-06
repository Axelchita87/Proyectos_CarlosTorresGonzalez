using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public class PsuedoCodeVerifyBuilder : IEndRecordBuilder
    {

        public PsuedoCodeVerifyBuilder()
        {

            this.Comunicator = new EndRecordAPIComunicator();
        }
        public void Build()
        {
            const string displayPCCCommand = "*S";

            string response = Comunicator.SendCommand(displayPCCCommand);
            string currentPcc = GetCurrentPCC(response);
            string TAcommand = string.Format("W/TA*{0}", currentPcc);

            Comunicator.SendCommand(TAcommand);
            const string lookForActivePccCommand = "MD/AUTO VAL";
            response = Comunicator.SendCommand(lookForActivePccCommand);
            if (response.Contains("AUTO VAL - OFF"))
            {
                Success = false;
                ErrorMessage =
                                   @"Para realizar venta de vuelos de Bajo Costo, es necesario contar con una IATA dentro del PCC, 
                                    de lo contrario emúlate a matriz con el formato AAA3L64 y llama de nuevo el proceso.";

            }
            else
            {
                Success = true;
            }
        }

        private string GetCurrentPCC(string response)
        {
            if (!string.IsNullOrEmpty(response))
            {

                return response.Substring(0, 4);
            }
            return string.Empty;

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
    }
}
