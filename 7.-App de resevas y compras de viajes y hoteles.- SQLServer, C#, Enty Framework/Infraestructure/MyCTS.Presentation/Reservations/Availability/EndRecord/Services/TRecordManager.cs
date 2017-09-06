using System;
using System.Collections.Generic;
using MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders;
using MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.Services
{
    public abstract class TRecordManager
    {
        public object Model { get; set; }
        public string Applicant { get; set; }
        public bool HasSpecifiedApplicant { get; set; }
        public abstract bool GenerateRecord();
        public string ErrorMessage { set; get; }
        public string SabrePnr { get; set; }
        public EventHandler<OnActionStartEventArg> OnActionStart { get; set; }
        public EventHandler<OnActionCompletedEventArgs> OnActionCompleted { get; set; }
        public EventHandler<OnRecordCompletedEventArgs> OnRecordCompleted { get; set; }
        public string Queue { get; set; }
        public string AgentName { get; set; }
        public string PseudoCityCode { get; set; }
        public bool IsInvoiced { get; set; }

        private bool IsValidProcess { get; set; }
        public VolarisAPICommunicator Communicator { get; set; }
        public bool EndAndRecoverRecord()
        {
            if (GenerateRecord())
            {
                if (CloseRecord())
                {

                    return true;
                }
            }
            return false;
        }

        private bool CloseRecord()
        {
            var endRecordBuilders = new List<IEndRecordBuilder>();
            //endRecordBuilders.Add(new PsuedoCodeVerifyBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Verificando Pseudo.." });
            endRecordBuilders.Add(new QSortEndRecordBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Agregando QSort.." });
            endRecordBuilders.Add(new ProtectionSegmentBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Agregando Segmento de Protección.." });
            endRecordBuilders.Add(new CustomerVerifyBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Verificando Cliente.." });
            endRecordBuilders.Add(new AgencyInformationBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Agregando Información de Agencia.." });
            endRecordBuilders.Add(new RecievedSixBuilder { Applicant = Applicant, AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Enviado 6 de Recibido.." });
            endRecordBuilders.Add(new EchoRomeoBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Cerrando Reserva.." });
            endRecordBuilders.Add(new DinBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, MessageOnProgress = "Enviando a facturación.." });
            endRecordBuilders.Add(new QueuePlaceBuilder { AgentFullName = AgentName, AgentQueue = Queue, PseudoCityCode = this.PseudoCityCode, SabrePnr = this.SabrePnr, MessageOnProgress = "Agregando Queue.." });

            foreach (var builder in endRecordBuilders)
            {
                if (OnActionStart != null && OnActionCompleted != null)
                {
                    if (builder.MessageOnProgress.Equals("Agregando Queue.."))
                    {
                        if( !string.IsNullOrEmpty(this.SabrePnr))
                        {
                            builder.SabrePnr = this.SabrePnr;
                        }
                    }
                    OnActionStart(this, new OnActionStartEventArg { Message = builder.MessageOnProgress });
                    builder.Build();
                    OnActionCompleted(this, new OnActionCompletedEventArgs { Message = builder.MessageOnProgress });
                    if (!builder.Success)
                    {
                        ErrorMessage = builder.ErrorMessage;
                        return false;
                    }
                    if (builder.HasPnr)
                    {
                        this.SabrePnr = builder.SabrePnr;
                    }
                    if (builder.IsInvoiced)
                    {
                        IsInvoiced = true;
                    }
                }
            }

            return true;

        }






    }
}
