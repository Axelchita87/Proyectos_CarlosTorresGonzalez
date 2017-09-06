using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisLimitTimeCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisLimitTimeCommandBuilder()
        {
            Communicator = new VolarisAPICommunicator();
        }
        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public VolarisReservation Reservation { get; set; }
        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();
        public void Build()
        {
            string sabreCommandToSend = string.Format("7TAW{0}{1}/",
                DateTime.Now.Day <= 9 ? string.Format("0{0}", DateTime.Now.Day) : DateTime.Now.Day.ToString(CultureInfo.InvariantCulture),
                DateTime.Now.ToString("MMM", new CultureInfo("en-US")));
            var response = Communicator.SendCommand(sabreCommandToSend);

            if (_errorDictionary.ContainsKey(response))
            {

                Success = false;
                ErrorMessage = _errorDictionary[response];
                Communicator.SendMessage("I");
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
