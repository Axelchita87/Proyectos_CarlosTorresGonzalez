using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    public class InterJetRemarkCommand : InterJetCommandBuilder
    {


        public override string Build()
        {
            if (VolarisSession.IsVolarisProcess)
            {
                foreach (var remarks in VolarisSession.Remarks.Get())
                {
                    if (!String.IsNullOrEmpty(remarks))
                    {
                        Comunicator.SendCommand(remarks);
                    }
                }
            }
            else
            {
                foreach (var remark in this.Ticket.Remarks.GetRemarks())
                {
                    if (!String.IsNullOrEmpty(remark))
                    {
                        Comunicator.SendCommand(remark);
                    }
                }
            }
            Success = true;
            return "";
        }
    }
}
