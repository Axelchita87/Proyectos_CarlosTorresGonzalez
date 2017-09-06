using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    public class InterJetAddChargeOfServiceRemarkCommand : InterJetCommandBuilder
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
            return "";
        }

        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <returns></returns>
        public string GetSabreCommand()
        {
            return ucChargeService.Remarks;
        }
    }
}
