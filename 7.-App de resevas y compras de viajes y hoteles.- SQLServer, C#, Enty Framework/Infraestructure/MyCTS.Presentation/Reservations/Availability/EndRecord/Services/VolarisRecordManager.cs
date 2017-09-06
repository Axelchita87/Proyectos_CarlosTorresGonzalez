using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.Services
{
    public class VolarisRecordManager : TRecordManager
    {
        private readonly List<IVolarisCommandBuilder> _builders;

        public VolarisRecordManager()
        {
            _builders = new List<IVolarisCommandBuilder>();

        }

        public override bool GenerateRecord()
        {
            var reservation = Model as VolarisReservation;


            if (reservation != null)
            {
                this.AgentName = reservation.Agent.FullName;
                this.Queue = reservation.Agent.Queue;
                this.PseudoCityCode = reservation.Agent.Pcc;
                _builders.Add(new VolarisCustomerDkCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Cliente.." });
                _builders.Add(new VolarisPassangersCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Pasajeros.." });
                _builders.Add(new VolarisItineraryCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Itinerario.." });
                _builders.Add(new VolarisContactInformationCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Contacto.." });
                _builders.Add(new VolarisLimitTimeCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Tiempo Limite.." });
                _builders.Add(new VolarisUserStoredFeeCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Tarifa Manual.." });
                _builders.Add(new VolarisAccountingLineCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando Lineas Contables.." });

                if (reservation.Itinerary.NeedSpecialServiceRequest)
                {
                    _builders.Add(new VolarisSpecialServiceInformationCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando servicios.." });
                }
                _builders.Add(new VolarisRemarksCommandBuilder { Reservation = reservation, MessageOnBuilt = "Agregando remarks.." });
                    
                foreach (var builder in _builders)
                {

                    if (OnActionStart != null && OnActionCompleted != null)
                    {
                        OnActionStart(this, new OnActionStartEventArg { Message = builder.MessageOnBuilt });
                        builder.Build();
                        OnActionCompleted(this, new OnActionCompletedEventArgs { Message = builder.MessageOnBuilt });

                    }
                    if (!builder.Success)
                    {
                        this.ErrorMessage = builder.ErrorMessage;
                        return builder.Success;
                    }
                }
            }
            return true;
        }
    }
}
