using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisFlight : IFlight
    {

        public VolarisFlight()
        {
            Segments = new Segments();
            PassangerFares = new VolarisPassangerFares();

        }
        #region Miembros de IFlight

        public Segments Segments { get; set; }
        public bool IsInternational { get; set; }
        public string OwnerCompany { get; set; }
        public string ID { get; set; }
        public string DepartureStation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        #endregion

        #region Miembros de IFlight


        public string SegmentItineraryString
        {
            get
            {
                if (Segments != null && Segments.GetAll().Any())
                {
                    return Segments.ItineraryString;
                }

                return "";
            }
        }

        public VolarisPassangerFares PassangerFares { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }

        #endregion

        #region Miembros de IFlight


        /// <summary>
        /// Gets or sets the arrival station.
        /// </summary>
        /// <value>
        /// The arrival station.
        /// </value>
        public string ArrivalStation { get; set; }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            ValidateDepartureAndArrivalStation();
            ValidateArrivalDateTime();
            ValidateDepartureDateTime();
            ValidateOwnerCompany();
            ValidateFlightId();
        }


        /// <summary>
        /// Validates the departure and arrival station.
        /// </summary>
        private void ValidateDepartureAndArrivalStation()
        {

            bool IsValidDepartureStation = DepartureStation.Length == 3 && !string.IsNullOrEmpty(DepartureStation);
            bool IsValidArrivalStation = ArrivalStation.Length == 3 && !string.IsNullOrEmpty(ArrivalStation);
            if (!IsValidArrivalStation)
            {

                throw new Exception("Invalid Arrival Station ");
            }

            if (!IsValidDepartureStation)
            {

                throw new Exception("Invalid Departure Station");

            }
        }

        /// <summary>
        /// Validates the arrival date time.
        /// </summary>
        private void ValidateArrivalDateTime()
        {
            if (ArrivalTime <= DepartureTime)
            {
                throw new Exception("Invalid Arrival Time");
            }

        }


        /// <summary>
        /// Validates the departure date time.
        /// </summary>
        private void ValidateDepartureDateTime()
        {
            if (DepartureTime <= DateTime.Now)
            {

                throw new Exception("Invalid Departure Time");
            }

        }

        /// <summary>
        /// Validates the owner company.
        /// </summary>
        private void ValidateOwnerCompany()
        {

            if (string.IsNullOrEmpty(OwnerCompany))
            {

                throw new Exception("Invalid Company Name");
            }

        }


        /// <summary>
        /// Validates the flight id.
        /// </summary>
        private void ValidateFlightId()
        {

            if (string.IsNullOrEmpty(ID))
            {

                throw new Exception("Invalid Flight ID");
            }
        }
        #endregion

        #region Miembros de IFlight


        public bool IsSelected { get; set; }

        #endregion


        public decimal Tax { get; set; }


        public bool IsSingleTrip { get; set; }


        public string Class { get; set; }
            
    }
}
