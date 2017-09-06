using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using NUnit.Framework;

namespace VolarisTest.EntitiesTest
{
    [TestFixture]
    public class RequestedPassangersTest
    {
        [TearDown]
        public void Setup()
        {


        }

        [Test]
        public void Constructor_ValidInitialization_Void()
        {
            var requestPassanger = new RequestedPassengers();
            Assert.IsTrue(requestPassanger.Adult != null, "Es Invalida la inicialización");
            Assert.IsTrue(requestPassanger.Senior != null, "Es Invalida la inicializaicón");
            Assert.IsTrue(requestPassanger.Child != null, "Es Invalida la inicializaicón");
            Assert.IsTrue(requestPassanger.Infant != null, "Es Invalida la inicializaicón");
        }

        /// <summary>
        /// Validate_s the valid number of passangers_ returns nothing.
        /// </summary>
        [Test]
        public void Validate_ValidNumberOfPassangers_ReturnsNothing()
        {
            var requestPassanger = new RequestedPassengers();
            requestPassanger.Adult.Count = 2;
            requestPassanger.Senior.Count = 2;
            requestPassanger.Child.Count = 3;
            requestPassanger.Infant.Count = 1;
            requestPassanger.Validate();
            Assert.IsTrue(requestPassanger.Total == 8, "Fallo en la suma total de pasajeros.");


        }

        [Test]
        public void Validate_InvalidNumberOfPassangers_ReturnsNothing()
        {
            var requestPassanger = new RequestedPassengers();
            requestPassanger.Adult.Count = 3;
            requestPassanger.Senior.Count = 3;
            requestPassanger.Child.Count = 3;
            requestPassanger.Infant.Count = 1;
            Assert.Throws<InvalidNumberOfPassangersExeception>(requestPassanger.Validate, "Fallo al validar el numero de pasajeros.");

        }

        [Test]
        public void Validate_ValidNumberOfInfants_ReturnsNothing()
        {
            var requestPassanger = new RequestedPassengers();
            requestPassanger.Adult.Count = 1;
            requestPassanger.Senior.Count = 1;
            requestPassanger.Infant.Count = 2;
            Assert.DoesNotThrow(requestPassanger.Validate, "Fallo al validar el numero de pasajeros infantes.");

        }


        [Test]
        public void Validate_InvalidNumberOfInfants_ReturnsNothing()
        {
            var requestPassanger = new RequestedPassengers();
            requestPassanger.Adult.Count = 1;
            requestPassanger.Senior.Count = 1;
            requestPassanger.Infant.Count = 4;
            Assert.Throws<InvalidNumberOfPassangersExeception>(requestPassanger.Validate, "Permite introducir mas pasajeros infantes que adultos..");

        }







    }
}
