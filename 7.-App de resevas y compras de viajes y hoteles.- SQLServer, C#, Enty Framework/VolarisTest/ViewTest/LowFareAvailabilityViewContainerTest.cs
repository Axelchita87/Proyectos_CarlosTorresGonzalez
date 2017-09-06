using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Container;
using NUnit.Framework;

namespace VolarisTest.ViewTest
{

    [TestFixture]
    public class LowFareAvailabilityViewContainerTest
    {


        [Test]
        public void ValidateInput_ValidationFail_ReturnsException()
        {

            var view = new LowFareAvailabilityContainerMockup();
            Assert.Throws<NoSelectedFlightException>(view.ValidateInput);

        }
        [Test]
        public void ValidateInput_ValidationSuccess_ReturnsNothing()
        {
            var view = new LowFareAvailabilityContainerMockup();

            view.SelectedFlight = new VolarisFlight();
            view.ValidateInput();
            Assert.IsTrue(view.IsValid, "Ocurrio un errror al volverse al validar la vista.");

        }

        [Test]
        public void FilterByCompanyName_CanFilterFlights_ReturnsNothing()
        {
            var view = new LowFareAvailabilityContainerMockup();
            view.FilterByCompanyName("Volaris");

            Assert.IsTrue(view.FilterOK, "No se pudo filter los vuelos de volaris.");



        }
        [Test]
        public void FilterByCompanyName_EmptyCompanyName_ReturnsNothing()
        {
            var view = new LowFareAvailabilityContainerMockup();
            view.FilterByCompanyName("");

            Assert.IsFalse(view.FilterOK, "No se pudo filter los vuelos de volaris.");
        }

        [Test]
        public void FilterByCompanyName_CantFilterFlightsBecauseCompanyDoesnExist_ReturnsNothing()
        {
            var view = new LowFareAvailabilityContainerMockup();
            view.FilterByCompanyName("American");

            Assert.IsFalse(view.FilterOK, "No se pudo filter los vuelos de volaris.");
        }

    }
}
