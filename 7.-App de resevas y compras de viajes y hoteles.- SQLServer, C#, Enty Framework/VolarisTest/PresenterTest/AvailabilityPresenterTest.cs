using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability;
using NUnit.Framework;
using VolarisTest.ViewTest;

namespace VolarisTest.PresenterTest
{
    [TestFixture]
    public class AvailabilityPresenterTest
    {
        [Test]
        public void SearchFlights_InvalidNumbersOfFlight_ReturnsNohting()
        {

            var presenter = new AvailabiltyPresenter
                                {
                                    View = new AvailabilityMockUpView
                                               {
                                                   AdultsPassangers = 0,
                                                   DepartureDate = DateTime.Now.AddDays(2),
                                                   DepartureStation = "MEX",
                                                   ArrivalStation = "CUN",
                                                   IsSingleTrip = true
                                               },
                                    Repository = new AvailabilityRepository()
                                };
            Assert.Throws<InvalidNumberOfPassangersExeception>(presenter.SearchFlights);

        }

        [Test]
        public void SearchFlights_ValidNumbersOfFlight_ReturnsNohting()
        {

            var presenter = new AvailabiltyPresenter
            {
                View = new AvailabilityMockUpView
                {
                    AdultsPassangers = 1,
                    DepartureDate = DateTime.Now.AddDays(2),
                    DepartureStation = "MEX",
                    ArrivalStation = "CUN",
                    IsSingleTrip = true
                },
                Repository = new AvailabilityRepository()
            };
            Assert.DoesNotThrow(presenter.SearchFlights);

        }



    }
}
