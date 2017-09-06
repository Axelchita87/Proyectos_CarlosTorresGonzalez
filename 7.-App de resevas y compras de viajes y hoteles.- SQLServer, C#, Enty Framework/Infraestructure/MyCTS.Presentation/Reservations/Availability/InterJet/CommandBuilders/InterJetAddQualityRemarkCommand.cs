using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddQualityRemarkCommand :InterJetCommandBuilder
    {

        private readonly string CARD_TYPE = "5.</C28*{0}/>";
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            //string commandToSend = this.GetCommandSabre();
            //string responseFromAPI = this.Comunicator.SendCommand(commandToSend);
            //return responseFromAPI;
            ucTicketEmissionBuildCommand.BuildRemarksForInterJet();
            string cardType = string.Empty;
            if (VolarisSession.IsVolarisProcess)
            {
                cardType = VolarisSession.IsClientCard ? "CLIENTE" : "CTS";
            }
            else
            {
                cardType = ucInterJetPaymentForm.IsClientCard ? "CLIENTE" : "CTS";
            }
            this.Comunicator.SendCommand(string.Format(CARD_TYPE, cardType));
            return "";
        }

        /// <summary>
        /// Gets the command sabre.
        /// </summary>
        /// <returns></returns>
        private string GetCommandSabre()
        {

            string commandToSend = ucAllQualityControls.BuildSabreCommandForInterjet();
            return commandToSend;

        }
    }
}
