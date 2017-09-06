using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using NUnit.Framework;
namespace VolarisTest.EntitiesTest
{
    [TestFixture]
    public class VolarisReservationTest
    {
        [Test]
        public void Constructor_CorrectInitialization_ReturnsNothing()
        {
            var reservation = new VolarisReservation();
            bool result = reservation.Itinerary != null && reservation.Passangers != null;
            Assert.IsTrue(result, "No se inicializo correctamente la reservacion");
        }


    }
}
