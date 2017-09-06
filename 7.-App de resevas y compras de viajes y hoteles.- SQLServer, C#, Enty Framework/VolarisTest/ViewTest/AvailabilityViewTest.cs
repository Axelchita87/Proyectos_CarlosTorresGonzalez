using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation;
using NUnit.Framework;
using MyCTS.Presentation.Reservations.Availability;

namespace VolarisTest.ViewTest
{
    [TestFixture]
    public class AvailabilityViewTest
    {

        [Test]
        public void Validate_ValidViewSingleTrip_ReturnsNothing()
        {

            IAvailabilityView view = new AvailabilityMockUpView();
            view.AdultsPassangers = 1;
            view.DepartureDate = DateTime.Now.AddDays(2);
            view.DepartureStation = "MEX";
            view.ArrivalStation = "CUN";
            view.IsSingleTrip = true;
            view.ValidateInput();
            Assert.IsTrue(view.IsValid);
        }

        [Test]
        public void Validate_ValidViewRoundTrip_ReturnsNothing()
        {

            IAvailabilityView view = new AvailabilityMockUpView();
            view.AdultsPassangers = 1;
            view.ChildrenPassangers = 2;
            view.DepartureDate = DateTime.Now;
            view.ReturningDate = DateTime.Now.AddDays(2);
            view.DepartureStation = "MEX";
            view.ArrivalStation = "CUN";
            view.IsRoundTrip = true;
            view.ValidateInput();
            Assert.IsTrue(view.IsValid);


        }

        [Test]
        public void Validate_InvalidViewNoDateSelected_ReturnsNothing()
        {
            IAvailabilityView view = new AvailabilityMockUpView();
            view.AdultsPassangers = 1;
            Assert.Throws<InvalidAvailabilityRequestException>(view.ValidateInput);

        }

        [Test]
        public void Validate_InvalidViewTooManyPassangers_ReturnsNothing()
        {
            IAvailabilityView view = new AvailabilityMockUpView();
            view.AdultsPassangers = 3;
            view.ChildrenPassangers = 4;
            view.SeniorsPassangers = 4;
            view.DepartureDate = DateTime.Now;
            view.DepartureStation = "MEX";
            view.ArrivalStation = "CUN";
            view.IsSingleTrip = true;
            Assert.Throws<InvalidNumberOfPassangersExeception>(view.ValidateInput);

        }

        [Test]
        public void Validate_InvalidViewTooManyInfants_ReturnsNothing()
        {
            IAvailabilityView view = new AvailabilityMockUpView();
            view.AdultsPassangers = 3;
            view.InfantPassangers = 4;
            view.DepartureDate = DateTime.Now;
            view.DepartureStation = "MEX";
            view.ArrivalStation = "CUN";
            view.IsSingleTrip = true;
            Assert.Throws<InvalidNumberOfPassangersExeception>(view.ValidateInput);

        }


        [Test]
        public void Validate_InvalidViewRoundTripWithOutRetuningDate_ReturnsNothing()
        {
            IAvailabilityView view = new AvailabilityMockUpView();
            view.AdultsPassangers = 3;
            view.InfantPassangers = 2;
            view.DepartureDate = DateTime.Now;
            view.DepartureStation = "MEX";
            view.ArrivalStation = "CUN";
            view.IsRoundTrip = true;
            Assert.Throws<InvalidAvailabilityRequestException>(view.ValidateInput);

        }




    }
}
