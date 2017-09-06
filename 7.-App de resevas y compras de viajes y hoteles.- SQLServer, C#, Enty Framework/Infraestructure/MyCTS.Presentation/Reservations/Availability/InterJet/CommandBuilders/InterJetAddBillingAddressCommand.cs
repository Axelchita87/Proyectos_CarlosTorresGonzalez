using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddBillingAddressCommand : InterJetCommandBuilder
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            string commandToSend = this.GetSabreCommand();
            string responseFromAPI = this.Comunicator.SendCommand(commandToSend);
            return responseFromAPI;

        }


        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <returns></returns>
        private string GetSabreCommand()
        {
            ucBillingAdressEmission.commandsBuild();
            string commandToSend = ucBillingAdressEmission.send;
            return commandToSend;

        }
    }
}
