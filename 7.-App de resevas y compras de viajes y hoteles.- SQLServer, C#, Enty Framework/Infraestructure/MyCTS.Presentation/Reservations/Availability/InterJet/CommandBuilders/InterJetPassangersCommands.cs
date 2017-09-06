using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    public class InterJetPassangersCommands : InterJetCommandBuilder
    {
        public override string Build()
        {
             var responseForNameAdded = string.Empty;
                    var responseForPassangerType=string.Empty;
            if (VolarisSession.IsVolarisProcess)
            {
                foreach (var paxes in VolarisSession.InterJetPassangers)
                {
                    string name = string.Empty;
                    if (paxes.PassangerNameInRecord.Contains('Ñ'))
                    {
                        string[] namepax = paxes.PassangerNameInRecord.Split('Ñ');
                        name = namepax[0] + "XYZ" + namepax[1];
                    }
                    else
                    {
                        name = paxes.PassangerNameInRecord;
                    }

                    responseForNameAdded = Comunicator.SendCommand(name);
                    responseForPassangerType = Comunicator.SendCommand(paxes.PassangerTypeInRecord);
                }
            }
            else
            {
                foreach (var pax in Ticket.Passangers.GetAll())
                {
                    string name = string.Empty;
                    if (pax.PassangerNameInRecord.Contains('Ñ'))
                    {
                        string[] namepax = pax.PassangerNameInRecord.Split('Ñ');
                        name = namepax[0] + "XYZ" + namepax[1];
                    }
                    else
                    {
                        name = pax.PassangerNameInRecord;
                    }

                    responseForNameAdded = Comunicator.SendCommand(name);
                    responseForPassangerType = Comunicator.SendCommand(pax.PassangerTypeInRecord);
                }
            }
            Success = true;
            return "";
        }
    }
}
