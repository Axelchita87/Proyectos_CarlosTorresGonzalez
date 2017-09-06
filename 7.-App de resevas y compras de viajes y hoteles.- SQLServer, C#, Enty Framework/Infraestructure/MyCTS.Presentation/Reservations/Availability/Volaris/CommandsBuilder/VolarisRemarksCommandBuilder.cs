using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisRemarksCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisRemarksCommandBuilder()
        {
            this.Communicator = new VolarisAPICommunicator();
        }
        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public MyCTS.Entities.VolarisReservation Reservation { get; set; }
        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();
        public void Build()
        {

            var commands = this.Reservation.Remarks.Get();

            foreach (var command in commands)
            {
                if (!String.IsNullOrEmpty(command))
                {
                    var response = Communicator.SendCommand(command);

                    if (_errorDictionary.ContainsKey(response))
                    {
                        Communicator.SendMessage("I");
                        Success = false;
                        ErrorMessage = _errorDictionary[response];
                        return;
                    }
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
