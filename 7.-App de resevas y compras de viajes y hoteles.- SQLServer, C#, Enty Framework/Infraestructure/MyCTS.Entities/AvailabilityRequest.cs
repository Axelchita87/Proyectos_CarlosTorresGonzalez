using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class AvailabilityRequest
    {

        public AvailabilityRequest()
        {
            Pasengers = new RequestedPassengers();
            BecomeSingleTrip();
        }


        public string DepartureItinerary
        {
            get { return string.Format("{0}-{1}", DepartureStation, ArrivalStation); }
        }

        public string ReturningItinerary
        {
            get { return string.Format("{0}-{1}", ArrivalStation, DepartureStation); }
        }

        public string DepartureDateString
        {

            get { return DepartureDateTime.ToString("dd MMMM yyyy"); }
        }

        public string ReturningDateString
        {
            get { return ReturningDateTime.HasValue ? ReturningDateTime.Value.ToString("dd MMMM yyyy") : ""; }
        }

        /// <summary>
        /// Gets or sets the departure station.
        /// </summary>
        /// <value>
        /// The departure station.
        /// </value>
        public string DepartureStation { get; set; }

        /// <summary>
        /// Gets or sets the arrival station.
        /// </summary>
        /// <value>
        /// The arrival station.
        /// </value>
        public string ArrivalStation { get; set; }

        /// <summary>
        /// Gets or sets the departure date time.
        /// </summary>
        /// <value>
        /// The departure date time.
        /// </value>
        public DateTime DepartureDateTime { get; set; }

        /// <summary>
        /// Gets or sets the returning date time.
        /// </summary>
        /// <value>
        /// The returning date time.
        /// </value>
        public DateTime? ReturningDateTime { get; set; }

        /// <summary>
        /// Gets or sets the pasengers.
        /// </summary>
        /// <value>
        /// The pasengers.
        /// </value>
        public RequestedPassengers Pasengers { get; set; }

        private AvailabilityRequestType _type;

        /// <summary>
        /// Gets the type.
        /// </summary>
        public AvailabilityRequestType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            Pasengers.Validate();
            ValidateInternalData();
        }

        public bool HasAdultOrSenior
        {
            get { return HasAdults || HasSenior; }
        }

        public int TotalAdults
        {
            get { return Pasengers.Adult.Count + Pasengers.Senior.Count; }
        }
        public int TotalOfPassangers
        {
            get { return this.TotalAdults + this.Pasengers.Child.Count; }
        }

        public bool HasAdults { get { return Pasengers.Adult.Count > 0; } }
        public bool HasSenior { get { return Pasengers.Senior.Count > 0; } }
        public bool HasChild { get { return Pasengers.Child.Count > 0; } }
        public bool HasInfant { get { return Pasengers.Infant.Count > 0; } }

        /// <summary>
        /// Validates the internal data.
        /// </summary>
        private void ValidateInternalData()
        {
            ValidateDepartureDate();
            ValidateRoundTripDate();
            ValidateDepartureAndArrivalStation();

        }

        /// <summary>
        /// Validates the departure date.
        /// </summary>
        private void ValidateDepartureDate()
        {
            if (DepartureDateTime < DateTime.Today)
            {
                throw new InvalidAvailabilityRequestException("La fecha de salida es menor que la fecha actual.")
                          {
                              ErrorCode = ErrorCode.DepartureDateIsLessThanToday
                          };

            }
        }

        /// <summary>
        /// Validates the round trip date.
        /// </summary>
        private void ValidateRoundTripDate()
        {
            if (Type == AvailabilityRequestType.RoundTrip)
            {

                if (ReturningDateTime.HasValue)
                {

                    if (DepartureDateTime > ReturningDateTime.Value)
                    {
                        throw new InvalidAvailabilityRequestException("La fecha de salida es mayor que la de regreso.")
                                  {
                                      ErrorCode = ErrorCode.ReturningDateIsBiggerThanReturningDate
                                  };
                    }
                }
                else
                {
                    throw new InvalidAvailabilityRequestException("No se ha especificado la fecha de regreso.")
                              {
                                  ErrorCode = ErrorCode.IsRoundTripAndNoReturningDate
                              };
                }
            }
        }
        /// <summary>
        /// Validates the departure and arrival station.
        /// </summary>
        private void ValidateDepartureAndArrivalStation()
        {

            if (string.IsNullOrEmpty(DepartureStation))
            {
                throw new InvalidAvailabilityRequestException("No se ha especificado la cuidad de salida.")
                          {
                              ErrorCode = ErrorCode.NoDepartureStation
                          };
            }

            if (string.IsNullOrEmpty(ArrivalStation))
            {
                throw new InvalidAvailabilityRequestException("No se ha especificado la cuidad de llegada.")
                          {
                              ErrorCode = ErrorCode.NoArrivalStation
                          };
            }

            if (!string.IsNullOrEmpty(DepartureStation) && DepartureStation.Length > 0 && DepartureStation.Length > 3)
            {
                throw new InvalidAvailabilityRequestException("La cuidad de destino no puede ser mayor a 3 caracteres.") { ErrorCode = ErrorCode.IncorrecDepartureStation };
            }

            if (!string.IsNullOrEmpty(ArrivalStation) && ArrivalStation.Length > 0 && ArrivalStation.Length > 3)
            {
                throw new InvalidAvailabilityRequestException("La cuidad de llegada no puede ser mayor a 3 caracteres.")
                          {
                              ErrorCode = ErrorCode.IncorrectArrivalStation
                          };
            }

            if (!string.IsNullOrEmpty(ArrivalStation) && !string.IsNullOrEmpty(DepartureStation))
            {
                if (ArrivalStation.Equals(DepartureStation))
                {
                    throw new InvalidAvailabilityRequestException("La cuidad destino y llegada no puede ser igual.")
                              {
                                  ErrorCode = ErrorCode.SameDepartureAndArrivalStation
                              };
                }
            }
        }

        /// <summary>
        /// Becomes the single trip.
        /// </summary>
        public void BecomeSingleTrip()
        {
            _type = AvailabilityRequestType.SingleTrip;
        }

        /// <summary>
        /// Becomes the round trip.
        /// </summary>
        public void BecomeRoundTrip()
        {
            _type = AvailabilityRequestType.RoundTrip;
        }
        public AvailabilityRequest GetAvailabilityForRoundTrip()
        {
            var request = new AvailabilityRequest();
            request.ArrivalStation = this.DepartureStation;
            request.DepartureStation = this.ArrivalStation;

            request.DepartureDateTime = this.ReturningDateTime.HasValue ? ReturningDateTime.Value : DateTime.Now;
            request.ReturningDateTime = this.ReturningDateTime;
            request.Pasengers = Pasengers;
            request._type = _type;
            return request;
        }

    }
}
