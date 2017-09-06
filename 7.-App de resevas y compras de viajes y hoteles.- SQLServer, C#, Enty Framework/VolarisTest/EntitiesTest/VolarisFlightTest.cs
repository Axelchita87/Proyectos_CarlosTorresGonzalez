using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using NUnit.Framework;
namespace VolarisTest.EntitiesTest
{

    [TestFixture]
    public class VolarisFlightTest
    {
        [Test]
        public void Validate_InvalidDepartureStation_ReturnException()
        {


            var flight = new VolarisFlight
                             {
                                 ID = "120",
                                 DepartureStation = "",
                                 ArrivalStation = "TIJ",
                                 DepartureTime = DateTime.Now.AddHours(1),
                                 ArrivalTime = DateTime.Now.AddHours(8),
                                 BasePrice = 2000.00m,
                                 OwnerCompany = "Volaris",
                                 Segments = null

                             };

            Assert.Throws<Exception>(flight.Validate);


        }
        [Test]
        public void Validate_ValidDepartureStation_ReturnNothing()
        {


            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "CUN",
                ArrivalStation = "TIJ",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(8),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.DoesNotThrow(flight.Validate);
        }

        [Test]
        public void Validate_ValidArrivalStation_ReturnNothing()
        {


            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "TIJ",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(8),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.DoesNotThrow(flight.Validate);

        }


        [Test]
        public void Validate_InvalidArrivalStation_ReturnException()
        {


            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(8),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.Throws<Exception>(flight.Validate);

        }

        [Test]
        public void Validate_ValidDepartureTime_ReturnNothing()
        {
            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "CUN",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(8),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.DoesNotThrow(flight.Validate);

        }
        [Test]
        public void Validate_InvalidDepartureTime_ReturnNothing()
        {
            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "CUN",
                DepartureTime = DateTime.Now.AddHours(-5),
                ArrivalTime = DateTime.Now.AddHours(2),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };

            Assert.Throws<Exception>(flight.Validate);
        }

        [Test]
        public void Validate_ValidArrivalTime_ReturnNothing()
        {
            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "CUN",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(8),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.DoesNotThrow(flight.Validate);

        }
        [Test]
        public void Validate_InvalidArrivalTime_ReturnException()
        {
            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "CUN",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(-1),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.Throws<Exception>(flight.Validate);

        }

        [Test]
        public void Validate_ValidOwnerCompany_ReturnNothing()
        {
            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "CUN",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(2),
                BasePrice = 2000.00m,
                OwnerCompany = "Volaris",
                Segments = null

            };
            Assert.DoesNotThrow(flight.Validate);
        }
        [Test]
        public void Validate_InvalidOwnerCompany_ReturnException()
        {
            var flight = new VolarisFlight
            {
                ID = "120",
                DepartureStation = "MEX",
                ArrivalStation = "CUN",
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(-1),
                BasePrice = 2000.00m,
                OwnerCompany = "",
                Segments = null

            };
            Assert.Throws<Exception>(flight.Validate);

        }




    }
}
