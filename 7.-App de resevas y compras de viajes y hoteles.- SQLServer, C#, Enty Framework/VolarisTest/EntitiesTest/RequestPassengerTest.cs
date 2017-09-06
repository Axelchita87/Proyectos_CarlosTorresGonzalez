using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MyCTS.Entities;

namespace VolarisTest.EntitiesTest
{
    [TestFixture]
    public class RequestedPassengerTest
    {

        [Test]
        public void Constructor_ValidInitialization_Void()
        {
            var requestedPassanger = new RequestedPassanger();
            Assert.AreEqual(0, requestedPassanger.Count);

        }

    }
}
