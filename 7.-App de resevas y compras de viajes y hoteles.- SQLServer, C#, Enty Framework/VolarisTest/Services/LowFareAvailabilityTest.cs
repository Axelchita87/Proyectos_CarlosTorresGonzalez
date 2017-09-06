using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts;
using MyCTS.Services.Contracts.Volaris;
using NUnit.Framework;
using MyCTS.Services;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Services;

namespace VolarisTest.Services
{
    [TestFixture]
    public class LowFareAvailabilityTest
    {
        [Test]
        public void Call_SuccesCall_ReturnisFlights()
        {
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
            var service = new LowFareAvailabilityService()
            {
                AvailabilityRequest = request,
                AvailabilityServices = new List<IAvailabilitySearchable>() {
                    new VolarisAvailability{
                        Request = request
                                                                               
                        },
                    new InterJetAvailability
                        {
                            Request = request
                        }
                                                                                                                              
                }
            };

            //Assert.IsNotNull(service.Call().GetAll(), "No se encontraron vuelos");


        }

    }
}
