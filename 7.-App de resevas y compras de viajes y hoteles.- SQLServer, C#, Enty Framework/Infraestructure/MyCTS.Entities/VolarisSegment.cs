using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisSegment : ISegment
    {
        #region Miembros de ISegment

        public string ID { get; set; }

        public string DepartureStation
        {
            get;
            set;
        }

        public string ArrivalStation
        {
            get;
            set;
        }

        public DateTime DepartureTime
        {
            get;
            set;
        }

        public DateTime ArrivalTime
        {
            get;
            set;
        }

        public int NumberInParty { get; set; }


        public string ClassOfService { get; set; }
        public SegmentType Type { get; set; }
        public string ItineraryString
        {
            get
            {
                return string.Format("{0}-{1}", DepartureStation, ArrivalStation);
            }
        }

        #endregion

        #region Miembros de ISegment


        public void Validate()
        {
            ValidateArrivalAndDepartureStation();
            ValidateArrivalAndDepartureTime();
            ValidateSegmentID();
        }


        /// <summary>
        /// Validates the arrival and departure station.
        /// </summary>
        private void ValidateArrivalAndDepartureStation()
        {
            bool IsValidArrivalStationLength = ArrivalStation.Length == 3 && !string.IsNullOrEmpty(ArrivalStation);
            bool IsValidDepartureStationLength = DepartureStation.Length == 3 && !string.IsNullOrEmpty(DepartureStation);
            if (!IsValidArrivalStationLength)
            {
                throw new Exception("Invalid Arrival station.");

            }

            if (!IsValidDepartureStationLength)
            {
                throw new Exception("Invalid Departure station.");
            }
        }

        /// <summary>
        /// Validates the arrival and departure time.
        /// </summary>
        private void ValidateArrivalAndDepartureTime()
        {
            if (ArrivalTime <= DepartureTime)
            {

                throw new Exception("Invalid Arrival Time");
            }

            if (DepartureTime <= DateTime.Now)
            {
                throw new Exception("Invalid Departure Time");
            }


        }

        /// <summary>
        /// Validates the segment ID.
        /// </summary>
        public void ValidateSegmentID()
        {

            if (string.IsNullOrEmpty(ID))
            {

                throw new Exception("Invalid Segment ID");
            }

        }

        #endregion
    }
}
