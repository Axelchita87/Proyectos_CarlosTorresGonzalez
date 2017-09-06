using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisContactInformationCommandBuilder : IVolarisCommandBuilder
    {

        public VolarisContactInformationCommandBuilder()
        {
            Communicator = new VolarisAPICommunicator();
        }


        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public VolarisReservation Reservation { get; set; }
        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();
        public void Build()
        {


            if (Reservation != null)
            {
                var primaryContact =
                    Reservation.Contact.Phones.GetAll().FirstOrDefault(p => p.Type == VolarisPhoneType.Primary);

                if (primaryContact != null)
                {
                    string commandToSend = string.Format("9{0}-B", primaryContact.FullNumber);
                    var response = Communicator.SendCommand(commandToSend);
                    if (_errorDictionary.ContainsKey(response))
                    {

                        Success = false;
                        ErrorMessage = _errorDictionary[response];
                        Communicator.SendMessage("I");
                    }

                    Success = true;

                }
                else
                {
                    //TODO: Agregar un telefono por default en caso de que no se encuentre un telefono primary -Volaris
                }


            }
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
