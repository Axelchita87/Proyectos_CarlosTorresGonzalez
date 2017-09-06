using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public interface IVolarisCommandBuilder
    {

        VolarisAPICommunicator Communicator { get; set; }
        VolarisReservation Reservation { get; set; }
        void Build();
        string ErrorMessage { get; set; }
        string MessageOnBuilt { get; set; }
        bool Success { get; set; }
    }
}
