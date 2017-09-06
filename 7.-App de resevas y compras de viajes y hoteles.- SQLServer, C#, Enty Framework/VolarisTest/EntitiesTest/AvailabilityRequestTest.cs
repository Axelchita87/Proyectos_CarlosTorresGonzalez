using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using NUnit.Framework;

namespace VolarisTest.EntitiesTest
{
    [TestFixture]
    public class AvailabilityRequestTest
    {
        [Test]
        public void Constructor_ValidInitialization_ReturnsNothing()
        {
            var request = new AvailabilityRequest();
            Assert.IsNotNull(request.Pasengers,"Inicialización erronea de los pasajeros agregados en la petición de disponibilidad");

        }

        [Test]
        public void Validate_ValidDates_ReturnsNothing()
        {

            var request = new AvailabilityRequest();
            request.ArrivalStation = "MEX";
            request.DepartureStation = "MID";
            request.DepartureDateTime = DateTime.Now;
            request.Pasengers.Adult.Count = 1;
            request.ReturningDateTime = DateTime.Now.AddDays(2);
            request.BecomeRoundTrip();
            Assert.DoesNotThrow(request.Validate);

        }

        [Test]
        public void Validate_InvalidReturningDate_ReturnsNothing()
        {

            var request = new AvailabilityRequest();
            request.ArrivalStation = "MEX";
            request.DepartureStation = "MID";
            request.DepartureDateTime = DateTime.Now;
            request.Pasengers.Adult.Count = 1;
            request.ReturningDateTime = DateTime.Now.AddDays(-5);
            request.BecomeRoundTrip();
            Assert.Throws<InvalidAvailabilityRequestException>(request.Validate);

        }




        [Test]
        public void Validate_InvalidDepartureDate_ReturnsNothing()
        {

            var request = new AvailabilityRequest();
            request.ArrivalStation = "MEX";
            request.DepartureStation = "MID";
            request.DepartureDateTime = DateTime.Now.AddDays(-4);
            request.Pasengers.Adult.Count = 1;
            Assert.Throws<InvalidAvailabilityRequestException>(request.Validate);

        }
    }
}
