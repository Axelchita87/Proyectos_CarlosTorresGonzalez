using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    public class InterJetCustomerCommand : InterJetCommandBuilder
    {
        public override string Build()
        {
            var command = string.Empty;
            if (VolarisSession.IsVolarisProcess)
                command = string.Format("DK{0}",VolarisSession.DK);
            else
                command = string.Format("DK{0}", Ticket.PassangerNumberRecord.DK);
            var response = Comunicator.SendCommand(command);
            Success = true;
            return "";
        }
    }
}
