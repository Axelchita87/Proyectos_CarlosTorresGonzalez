using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public class ProtectionSegmentBuilder : IEndRecordBuilder
    {

        public ProtectionSegmentBuilder()
        {
            Comunicator = new EndRecordAPIComunicator();

        }

        private const string ResponseSuccess = "\n*";

        public void Build()
        {

            var date = DateTime.Today.AddDays(300).ToString("ddMMM", new CultureInfo("en-us"));
            var command = string.Format(ProtectionSegmentBuilder.ProtectionSegmentTemplate, date);
            var response = Comunicator.SendCommand(command);

            if (response.Equals(ProtectionSegmentBuilder.ResponseSuccess))
            {

            }
            Success = true;
        }

        private const string ProtectionSegmentTemplate = @"0OTHAAGK1MEX{0}-SEGMENTO DE PROTECCION";
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
