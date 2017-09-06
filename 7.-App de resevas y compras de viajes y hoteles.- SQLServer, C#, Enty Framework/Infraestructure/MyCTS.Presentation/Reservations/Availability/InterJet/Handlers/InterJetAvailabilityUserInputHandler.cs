using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.Contracts;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{

    public class InterJetAvailabilityUserInputHandler
    {
        /// <summary>
        /// Obtiene de la disponibilidad de vuelos de los parametros a ser mandados al webservice de Interjet
        /// </summary>
        /// <returns></returns>
        public  InterJetAvailabilityUserInput GetInterJetAvailabilityUserInput()
        {
            InterJetAvailabilityUserInput userInput = new InterJetAvailabilityUserInput();
            userInput.ArrivalStation = "MID";
            userInput.DepartureStation = "MEX";
            userInput.BeginDate = DateTime.Parse("01/01/2011");
            userInput.EndDate = DateTime.Today;
            return userInput;
        }
        


    }
}
