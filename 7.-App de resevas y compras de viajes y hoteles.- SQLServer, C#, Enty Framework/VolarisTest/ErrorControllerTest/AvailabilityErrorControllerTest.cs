using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability;
using NUnit.Framework;
using VolarisTest.ViewTest;

namespace VolarisTest.ErrorControllerTest
{
    [TestFixture]
    public class AvailabilityErrorControllerTest
    {

        [Test]
        public void HandleError_ErrorHandledNoPassangerSelected_ReturnsNothing()
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

            var errorController = new AvailabilityErrorControllerMockUp();

            try
            {
                presenter.SearchFlights();
            }
            catch (Exception exe)
            {
                errorController.HandleError(exe);

            }

            Assert.IsTrue(errorController.ErrorWasHandled, "El error no fue controlado por el controlador de errores.");
        }


        [Test]
        public void HandleError_ErrorHandledDepartureDateIsLessThanActual_ReturnsNothing()
        {
            var presenter = new AvailabiltyPresenter
            {
                View = new AvailabilityMockUpView
                {
                    AdultsPassangers = 1,
                    DepartureDate = DateTime.Now.AddDays(-3),
                    DepartureStation = "MEX",
                    ArrivalStation = "CUN",
                    IsSingleTrip = true
                },
                Repository = new AvailabilityRepository()
            };

            var errorController = new AvailabilityErrorControllerMockUp();

            try
            {
                presenter.SearchFlights();
            }
            catch (Exception exe)
            {
                errorController.HandleError(exe);

            }

            Assert.IsTrue(errorController.ErrorWasHandled, "El error no fue controlado por el controlador de errores.");
        }

        [Test]
        public void HandleError_ErrorHandledDepartureDateIsBiggerThanReturningDate_ReturnsNothing()
        {
            var presenter = new AvailabiltyPresenter
            {
                View = new AvailabilityMockUpView
                {
                    AdultsPassangers = 1,
                    DepartureDate = DateTime.Now,
                    ReturningDate = DateTime.Now.AddDays(-3),
                    DepartureStation = "MEX",
                    ArrivalStation = "CUN",
                    IsRoundTrip = true
                },
                Repository = new AvailabilityRepository()
            };

            var errorController = new AvailabilityErrorControllerMockUp();

            try
            {
                presenter.SearchFlights();
            }
            catch (Exception exe)
            {
                errorController.HandleError(exe);

            }

            Assert.IsTrue(errorController.ErrorWasHandled, "El error no fue controlado por el controlador de errores.");
        }

        [Test]
        public void HandleError_ErrorHandledIsRoundTripAndNoReturningDateSelected_ReturnsNothing()
        {
            var presenter = new AvailabiltyPresenter
            {
                View = new AvailabilityMockUpView
                {
                    AdultsPassangers = 1,
                    DepartureDate = DateTime.Now,
                    ReturningDate = null,
                    DepartureStation = "MEX",
                    ArrivalStation = "CUN",
                    IsRoundTrip = true
                },
                Repository = new AvailabilityRepository()
            };

            var errorController = new AvailabilityErrorControllerMockUp();

            try
            {
                presenter.SearchFlights();
            }
            catch (Exception exe)
            {
                errorController.HandleError(exe);

            }

            Assert.IsTrue(errorController.ErrorWasHandled, "El error no fue controlado por el controlador de errores.");
        }

        [Test]
        public void HandleError_ErrorHandledGenericExceptionThrowed_ReturnsNothing()
        {
            var presenter = new AvailabiltyPresenter
            {
                View = new AvailabilityMockUpView
                {
                    AdultsPassangers = 1,
                    DepartureDate = DateTime.Now,
                    ReturningDate = DateTime.Now.AddDays(2),
                    DepartureStation = "MEX",
                    ArrivalStation = "CUN",
                    IsRoundTrip = true
                },
                Repository = new AvailabilityRepository()
            };

            var errorController = new AvailabilityErrorControllerMockUp();
            
            try
            {
                throw new Exception("No se quien soy?¿");
                
            }
            catch (Exception exe)
            {
                errorController.HandleError(exe);

            }

            Assert.IsFalse(errorController.ErrorWasHandled, "El error no fue controlado por el controlador de errores.");
        }

    }
}
