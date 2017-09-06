using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public interface IEndRecordBuilder
    {
        void Build();
        EndRecordAPIComunicator Comunicator { get; set; }
        bool Success { get; set; }
        bool IsInvoiced { get; set; }
        string SabrePnr { get; set; }
        bool HasPnr { get; set; }
        string AgentQueue { get; set; }
        string AgentFullName { get; set; }
        string PseudoCityCode { get; set; }
        string MessageOnProgress { get; set; }
        string ErrorMessage { get; set; }

    }
}
