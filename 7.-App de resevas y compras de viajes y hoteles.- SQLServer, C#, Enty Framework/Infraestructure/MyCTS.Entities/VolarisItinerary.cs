using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisItinerary
    {
        public VolarisItinerary()
        {
            Departure = new VolarisFlight();
            Return = new VolarisFlight();
            BaseFare = new VolarisItineraryFare();
        }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public ItineraryType Type { get; set; }

        /// <summary>
        /// Gets or sets the departure.
        /// </summary>
        /// <value>
        /// The departure.
        /// </value>
        public VolarisFlight Departure { get; set; }

        /// <summary>
        /// Gets or sets the return.
        /// </summary>
        /// <value>
        /// The return.
        /// </value>
        public VolarisFlight Return { get; set; }

        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        /// <value>
        /// The reservation.
        /// </value>
        public VolarisReservation Reservation { get; set; }


        public List<string> GetItineraryHostCommandFormat()
        {

            var commandSegments = new List<string>();

            commandSegments.AddRange(GetItineraryHostCommand(Departure));
            if (Type == ItineraryType.RoundTrip)
            {
                commandSegments.AddRange(GetItineraryHostCommand(Return));
            }


            return commandSegments;
        }

        private IEnumerable<string> GetItineraryHostCommand(VolarisFlight flight)
        {

            var commandSegments = new List<string>();

            commandSegments.AddRange(GetSegmentHostCommand(flight.Segments.GetAll().Cast<VolarisSegment>()));

            return commandSegments;
        }


        private const string ItinerarySegment = @"04O{0}{1}{2}{3}{4}YK{5}*{6}";
        private IEnumerable<string> GetSegmentHostCommand(IEnumerable<VolarisSegment> segments)
        {

            if (segments != null && segments.Any())
            {
                var commandSegments = new List<string>();
                foreach (var segment in segments)
                {
                    //TODO:agregar el pnr al linea del itinerary
                    string command = string.Format(@"0Y4{0}{1}{2}{3}{4}YK{5}*{6}",
                                                                    segment.ID,
                                                                    segment.ClassOfService,
                                                                    segment.DepartureTime.ToString("ddMMM", new CultureInfo("en-US")),
                                                                    segment.DepartureStation,
                                                                    segment.ArrivalStation,
                                                                    Reservation.Passangers.GetAdultsAndChildren().Count,
                                                                    Reservation.RecordLocator.Record
                                                                     );
                    commandSegments.Add(command);

                }
                return commandSegments;
            }

            return new List<string>();
        }

        public decimal TotalBasePrice
        {
            get
            {
                if(UseFinalItineraryPrice)
                {
                    return TotalFinalBasePrice;
                }

                decimal departurePrice = Departure.PassangerFares.GetPassangerFares().Sum(p => p.BasePrice.Total);
                decimal returnPrice = 0;
                if (Type == ItineraryType.RoundTrip)
                {
                    returnPrice = Return.PassangerFares.GetPassangerFares().Sum(p => p.BasePrice.Total);

                }
                return departurePrice + returnPrice;
            }
        }

        public bool UseFinalItineraryPrice { get; set; }

        public VolarisItineraryFare BaseFare { get; set; }




        public bool IsInternational
        {
            get
            {
                if (Type == ItineraryType.RoundTrip)
                {
                    if (Departure != null && Return != null)
                    {
                        return Departure.IsInternational || Return.IsInternational;
                    }
                }
                else
                {
                    if (Departure != null)
                    {
                        return Departure.IsInternational;
                    }
                }
                return false;
            }
        }


        public bool NeedSpecialServiceRequest
        {
            get { return this.IsInternational || this.Reservation.Passangers.HasInfants; }
        }

        public decimal TotalPrice
        {
            get
            {
                if(UseFinalItineraryPrice)
                {
                    return TotalFinalPrice;
                }

                decimal departurePrice = Departure.PassangerFares.GetPassangerFares().Sum(p => p.Total);
                decimal returnPrice = 0;
                if (Type == ItineraryType.RoundTrip)
                {
                    returnPrice = Return.PassangerFares.GetPassangerFares().Sum(p => p.Total);

                }
                return departurePrice + returnPrice;
            }
        }
        public decimal TotalTaxes
        {
            get
            {

                if(UseFinalItineraryPrice)
                {

                    return TotalFinalTaxes;
                }

                decimal departureTaxes = Departure.PassangerFares.GetPassangerFares().Sum(p => p.TotalTaxes);
                decimal returnTaxes = 0;
                if (Type == ItineraryType.RoundTrip)
                {
                    returnTaxes = Return.PassangerFares.GetPassangerFares().Sum(p => p.TotalTaxes);

                }
                return departureTaxes + returnTaxes;
            }
        }

        public decimal TotalFinalBasePrice { get; set; }

        public decimal TotalFinalTaxes { get; set; }

        public decimal TotalFinalPrice { get; set; }





    }
}
