using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisSpecialServiceInformationCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisSpecialServiceInformationCommandBuilder()
        {
            Communicator = new VolarisAPICommunicator();
        }
        #region Implementation of IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }
        public VolarisReservation Reservation { get; set; }
        public void Build()
        {
            var commands = new List<string>();
            if (Reservation.Itinerary.IsInternational)
            {

                commands.AddRange(Reservation.Passangers.GetAll().Select(p => p.SecureFlightCommandForHost).ToList());

            }

            if (Reservation.Passangers.HasInfants)
            {
                commands.AddRange(Reservation.Passangers.GetInfants().Select(p => p.SSRCommandForHost));
            }

            foreach (var command in commands)
            {
                var response = Communicator.SendCommand(command);

                if (response != null)
                {

                }

            }

            Success = true;
        }

        public string ErrorMessage { get; set; }
        public string MessageOnBuilt { get; set; }
        public bool Success { get; set; }

        #endregion
    }
}
