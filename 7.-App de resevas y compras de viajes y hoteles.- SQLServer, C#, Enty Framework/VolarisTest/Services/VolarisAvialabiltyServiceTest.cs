using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts;
using MyCTS.Services.Contracts.Volaris;
using NUnit.Framework;
using MyCTS.Services;


namespace VolarisTest.Services
{
    [TestFixture]
    public class VolarisAvialabiltyServiceTest
    {
        [Test]
        public void Call_AvailabilitySucces_ReturnsFlights()
        {
            ISabreService openSessionService = new OpenSessionService();
            openSessionService.Call();
            var request = new AvailabilityRequest()
                              {
                                  DepartureStation = "MEX",
                                  ArrivalStation = "CUN",
                                  DepartureDateTime = DateTime.Now.AddDays(1).AddHours(-5),
                                  Pasengers = new RequestedPassengers
                                                  {
                                                      Adult = new RequestedPassanger
                                                                  {
                                                                      Count = 1
                                                                  }
                                                  }
                              };
            request.BecomeSingleTrip();

            //ISabreService<Flights> availabilityService = new VolarisAvialabiltyService()
            //{
            //    AvailabilityRequest = request,
            //    ConversationID = openSessionService.ConversationID,
            //    SecurityToken = openSessionService.SecurityToken

            //};
            //Assert.IsTrue(availabilityService.Call().GetAll().Count > 0, "No se pudo obtener los vuelos");


        }

    }
}
