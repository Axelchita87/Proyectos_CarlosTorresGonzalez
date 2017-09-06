using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisCustomerDkCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisCustomerDkCommandBuilder()
        {

            Communicator = new VolarisAPICommunicator();
        }
        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public MyCTS.Entities.VolarisReservation Reservation { get; set; }


        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();
        public void Build()
        {

            string command = string.Format("DK{0}", Reservation.CustomerDk.Value);
            string response = Communicator.SendCommand(command);
            if (_errorDictionary.ContainsKey(response))
            {
                Success = false;
                ErrorMessage = _errorDictionary[response];
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
