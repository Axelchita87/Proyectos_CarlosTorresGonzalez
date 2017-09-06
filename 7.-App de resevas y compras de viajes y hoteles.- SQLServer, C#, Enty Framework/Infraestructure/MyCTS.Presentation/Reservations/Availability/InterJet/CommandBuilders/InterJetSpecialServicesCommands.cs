using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    public class InterJetSpecialServicesCommands : InterJetCommandBuilder
    {
        public override string Build()
        {

            var commands = new List<string>();
            if (Ticket.Flights.HasInternationalSegments)
            {
                commands.AddRange(Ticket.Passangers.GetAll().Select(pax => pax.SecureFlightCommandForHost));
            }

            if (Ticket.Passangers.HasInfants)
            {
                if (this.Ticket.Passangers.GetInfants().Any())
                {
                    var infants = this.Ticket.Passangers.GetInfants();
                    commands.AddRange(from infant in infants
                                      where infant != null
                                      select string.Format("3INFT/{0}/{1}/{2}-{3}.1",
                                                            infant.LastName,
                                                            infant.Name,
                                                            infant.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US")),
                                                            infant.AssignedPassanger.ID));
                }
            }

            foreach (var command in commands)
            {
                var response = Comunicator.SendCommand(command);

            }
            Success = true;
            return "";
        }
    }
}
