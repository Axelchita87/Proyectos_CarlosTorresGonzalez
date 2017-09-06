using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using NUnit.Framework;

namespace VolarisTest.EntitiesTest
{
    [TestFixture]
    public class VolarisSegmentTest
    {
        [Test]
        public void Validate_ValidSegment_ReturnsNothing()
        {
            var segment = new VolarisSegment();
            segment.ID = "120";
            segment.DepartureStation = "MEX";
            segment.ArrivalStation = "CUN";
            segment.DepartureTime = DateTime.Now.AddHours(1);
            segment.ArrivalTime = DateTime.Now.AddHours(3);
            segment.Type = SegmentType.Connection;
            Assert.DoesNotThrow(segment.Validate);
        }
        [Test]
        public void Validate_InvalidArrivalStation_ReturnsNothing()
        {

            var segment = new VolarisSegment();
            segment.ID = "120";
            segment.DepartureStation = "MEX";
            segment.ArrivalStation = "";
            segment.DepartureTime = DateTime.Now;
            segment.ArrivalTime = DateTime.Now.AddHours(2);
            segment.Type = SegmentType.Connection;
            Assert.Throws<Exception>(segment.Validate);
        }

        [Test]
        public void Validate_InvalidDepartureStation_ReturnsNothing()
        {

            var segment = new VolarisSegment();
            segment.ID = "120";
            segment.DepartureStation = "";
            segment.ArrivalStation = "CUN";
            segment.DepartureTime = DateTime.Now;
            segment.ArrivalTime = DateTime.Now.AddHours(3);
            segment.Type = SegmentType.Connection;
            Assert.Throws<Exception>(segment.Validate);
        }
        [Test]
        public void Validate_InvalidArrivalTime_ReturnNohting()
        {

            var segment = new VolarisSegment();
            segment.ID = "120";
            segment.DepartureStation = "MEX";
            segment.ArrivalStation = "CUN";
            segment.DepartureTime = DateTime.Now;
            segment.ArrivalTime = DateTime.Now.AddHours(-8);
            segment.Type = SegmentType.Connection;
            Assert.Throws<Exception>(segment.Validate);
        }

        [Test]
        public void Validate_InvalidDepartureTime_ReturnNothing()
        {

            var segment = new VolarisSegment();
            segment.ID = "120";
            segment.DepartureStation = "MEX";
            segment.ArrivalStation = "CUN";
            segment.DepartureTime = DateTime.Now.AddHours(15);
            segment.ArrivalTime = DateTime.Now.AddHours(-8);
            segment.Type = SegmentType.Connection;
            Assert.Throws<Exception>(segment.Validate);
        }

        [Test]
        public void Validate_InvalidSegmentID_ReturnNothing()
        {

            var segment = new VolarisSegment();
            segment.ID = "";
            segment.DepartureStation = "MEX";
            segment.ArrivalStation = "CUN";
            segment.DepartureTime = DateTime.Now.AddHours(15);
            segment.ArrivalTime = DateTime.Now.AddHours(-8);
            segment.Type = SegmentType.Connection;
            Assert.Throws<Exception>(segment.Validate);
        }



    }
}
