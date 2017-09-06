using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    public class InterJetAddContactPhoneCommand : InterJetCommandBuilder
    {
        public override string Build()
        {
            string commandToSend = string.Empty;
            if (Entities.VolarisSession.IsVolarisProcess)
            {
                commandToSend= string.Format("9{0}-B", "85252222");
            }
            else
            {
                commandToSend = string.Format("9{0}-B", this.Ticket.Contact.PrimaryTelephone);
            }
            string responseFromAPI = this.Comunicator.SendCommand(commandToSend);
            Success = true;
            return responseFromAPI;
        }
    }
}
