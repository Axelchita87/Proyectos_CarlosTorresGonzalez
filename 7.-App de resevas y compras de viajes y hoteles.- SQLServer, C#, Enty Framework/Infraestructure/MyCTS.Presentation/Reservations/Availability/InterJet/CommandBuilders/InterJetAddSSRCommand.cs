using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddSSRCommand : InterJetCommandBuilder
    {
        public override string Build()
        {
            string commandsToSend = string.Join(InterJetCommandBuilder.ENDIT, GetSabreCommand().ToArray());
            string responseFromApi = Comunicator.SendCommand(commandsToSend);
            return responseFromApi;
        }


        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <returns></returns>
        public List<string> GetSabreCommand()
        {
            var infants = new List<InterJetPassangerInfant>();
            infants = this.Ticket.Passangers.GetInfants();
            var commands = new List<string>();

            if (this.Ticket.Passangers.GetInfants().Any())
            {
                foreach (InterJetPassangerInfant infant in infants)
                {
                    if (infant != null)
                    {
                        
                        string infantCommandInformation = string.Format("3INFT/{0}/{1}/{2}-{3}",
                                                                infant.LastName,
                                                                infant.Name,
                                                                infant.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US")),
                                                                infant.AssignedPassanger.SabrePassangerID);
                       
                        commands.Add(infantCommandInformation);
                    }
                }
            }

            return commands;
        }
    }
}
