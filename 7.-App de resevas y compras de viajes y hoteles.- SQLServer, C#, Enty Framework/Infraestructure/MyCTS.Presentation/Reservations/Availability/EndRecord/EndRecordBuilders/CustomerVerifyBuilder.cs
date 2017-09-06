using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public class CustomerVerifyBuilder : IEndRecordBuilder
    {

        public CustomerVerifyBuilder()
        {
            this.Comunicator = new EndRecordAPIComunicator();
        }


        private const string ResponseSuccess = "CUSTOMER NUMBER";

        public void Build()
        {
            const string command = "*PDK";
            var response = Comunicator.SendCommand(command);
            if (response.Contains(CustomerVerifyBuilder.ResponseSuccess))
            {
                Success = true;

            }
            Success = true;
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
