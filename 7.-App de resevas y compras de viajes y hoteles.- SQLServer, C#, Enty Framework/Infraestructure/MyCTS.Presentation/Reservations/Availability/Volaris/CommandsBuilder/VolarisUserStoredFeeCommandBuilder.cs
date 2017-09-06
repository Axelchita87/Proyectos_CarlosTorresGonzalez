using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisUserStoredFeeCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisUserStoredFeeCommandBuilder()
        {
            Communicator = new VolarisAPICommunicator();
        }
        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public Entities.VolarisReservation Reservation { get; set; }
        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();
        public void Build()
        {


            string sabreCommand = string.Format("PQM-TARIFA MANUAL DE Volaris {0}-{1}", DateTime.Now.ToString("ddMMMyy",
                                                                                        new CultureInfo("en-US")),
                                                                                       Reservation.Itinerary.TotalPrice.ToString("0.00", new CultureInfo("es-mx")));

            var response = Communicator.SendCommand(sabreCommand);

            if (_errorDictionary.ContainsKey(response))
            {
                Communicator.SendMessage("I");
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
