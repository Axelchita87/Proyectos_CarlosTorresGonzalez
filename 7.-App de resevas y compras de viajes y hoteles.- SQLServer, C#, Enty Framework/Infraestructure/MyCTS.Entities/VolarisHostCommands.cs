using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisHostCommands
    {

        public VolarisReservation Reservation { get; set; }
        /// <summary>
        /// Gets the passangers names.
        /// </summary>
        /// <returns></returns>
        public List<string> GetPassangersNames()
        {

            if (Reservation != null)
            {
                var commands = new List<string>();
                var passangers = Reservation.Passangers.GetAll();

                if (passangers.Any())
                {
                    foreach (var pax in passangers)
                    {
                        commands.Add(pax.NameInRecord);
                        commands.Add(pax.PassangeTypeInRecord);
                    }
                    return commands;
                }
            }
            return new List<string>();
        }

        public List<string> GetItinerarySegments()
        {



            return Reservation.Itinerary.GetItineraryHostCommandFormat();
        }
    }
}
