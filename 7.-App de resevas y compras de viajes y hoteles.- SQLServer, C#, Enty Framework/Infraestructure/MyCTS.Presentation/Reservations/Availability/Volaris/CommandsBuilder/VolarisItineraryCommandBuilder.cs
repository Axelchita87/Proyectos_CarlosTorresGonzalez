using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisItineraryCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisItineraryCommandBuilder()
        {
            Communicator = new VolarisAPICommunicator();
        }
        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public VolarisReservation Reservation { get; set; }

        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();
        public void Build()
        {

            var commands = Reservation.Itinerary.GetItineraryHostCommandFormat();

            foreach (var command in commands)
            {
                var response = Communicator.SendCommand(command);
                if (_errorDictionary.ContainsKey(response))
                {

                    Success = false;
                    ErrorMessage = _errorDictionary[response];
                    Communicator.SendMessage("I");
                    return;
                }

            }
            Success = true;

        }

        #endregion

        #region Miembros de IVolarisCommandBuilder


        public string ErrorMessage { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Miembros de IVolarisCommandBuilder


        public string MessageOnBuilt { get; set; }

        #endregion
    }
}
