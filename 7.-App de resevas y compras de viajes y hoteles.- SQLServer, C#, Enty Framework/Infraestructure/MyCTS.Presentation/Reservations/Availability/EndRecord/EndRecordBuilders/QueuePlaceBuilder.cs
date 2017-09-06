using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;
//using MyCTS.Business;
//using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public class QueuePlaceBuilder : IEndRecordBuilder
    {

        public QueuePlaceBuilder()
        {
            Comunicator = new EndRecordAPIComunicator();
        }
        public void Build()
        {
            var displayPnrCommand = string.Concat("*", SabrePnr);
            Comunicator.SendCommand(displayPnrCommand);
            var command = string.Format("QP/{0}{1}/11", PseudoCityCode, AgentQueue);
            var response = Comunicator.SendCommand(command);

            ////SOLO PARA PRUEBAS GABY SOLANO
            //CatTransactionBL.AddCommandsTransaction(Login.Agent, Common.CurrentPNR, response, DateTime.Now, Common.CurrentArea);


            if (response.Contains(""))
            {
                //Success = false;
            }
            //else
            //{
            //    Success = true;
            //}
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
