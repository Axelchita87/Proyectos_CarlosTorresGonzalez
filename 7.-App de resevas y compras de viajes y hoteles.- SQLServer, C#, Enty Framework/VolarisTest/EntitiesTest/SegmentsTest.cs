using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using NUnit.Framework;

namespace VolarisTest.EntitiesTest
{
    [TestFixture]
    public class SegmentsTest
    {
        [Test]
        public void Constructot_CorrectInitialization_ReturnNothing()
        {
            var segments = new Segments();

            Assert.IsTrue(segments.GetAll().Count == 0);


        }
        [Test]
        public void Add_CorrectAddingOfSegments_ReturnsNothing()
        {

            var segments = new Segments();

            var segmentTest1 = new VolarisSegment
                              {
                                  ID = "120",
                                  DepartureStation = "MEX",
                                  ArrivalStation = "CUN",
                                  DepartureTime = DateTime.Now,
                                  ArrivalTime = DateTime.Now.AddHours(3),
                                  Type = SegmentType.Connection
                              };

            var segmentTest2 = new VolarisSegment
            {
                ID = "123",
                DepartureStation = "MEX",
                ArrivalStation = "MTY",
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now.AddHours(2),
                Type = SegmentType.Connection
            };

            segments.Add(segmentTest1);
            segments.Add(segmentTest2);
            Assert.IsTrue(segments.GetAll().Count == 2, "No se agregaron correctamentate los segmentos");


        }
        [Test]
        public void Remove_CorrectRemoveOfSegments_ReturnsNothing()
        {

            var segments = new Segments();

            var segmentTest1 = new VolarisSegment
                                   {
                                       ID = "120",
                                       DepartureStation = "MEX",
                                       ArrivalStation = "CUN",
                                       DepartureTime = DateTime.Now,
                                       ArrivalTime = DateTime.Now.AddHours(3),
                                       Type = SegmentType.Connection
                                   };

            var segmentTest2 = new VolarisSegment
                                   {
                                       ID = "123",
                                       DepartureStation = "MEX",
                                       ArrivalStation = "MTY",
                                       DepartureTime = DateTime.Now,
                                       ArrivalTime = DateTime.Now.AddHours(2),
                                       Type = SegmentType.Connection
                                   };

            segments.Add(segmentTest1);
            segments.Add(segmentTest2);

            segments.Remove(segmentTest1);
            Assert.IsTrue(segments.GetAll().Count == 1, "No se removieron correctamente los segmentos");

        }

    }
}
