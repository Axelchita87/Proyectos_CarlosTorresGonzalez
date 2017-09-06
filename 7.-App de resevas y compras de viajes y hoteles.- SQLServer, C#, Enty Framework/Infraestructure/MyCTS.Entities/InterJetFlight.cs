using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.ComponentModel;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFlight : IFlight
    {

        public InterJetFlight()
        {
            Information = new InterJetFlightInformation();
            Segments = new Segments();
        }
        /// <summary>
        /// Gets or sets the previous princig.
        /// </summary>
        /// <value>
        /// The previous princig.
        /// </value>
        [Browsable(false)]
        public InterJetPreviousPricing PreviousPrincig { get; set; }
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        [Browsable(false)]
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// Escalas que puede tener un vuelo
        /// </summary>
        [Browsable(false)]
        public InterJetScales Scales
        {
            get;
            set;

        }

        [Browsable(false)]
        public InterJetTicket Ticket
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets the extra charge for infant.
        /// </summary>
        /// <value>
        /// The extra charge for infant.
        /// </value>
        [Browsable(false)]
        public decimal ExtraChargeForInfant
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the total payed.
        /// </summary>
        [Browsable(false)]
        public decimal TotalPayed
        {
            get
            {

                decimal total = 0;
                if (this.Ticket.Passangers.HasAdults)
                {
                    total += this.PriceDetail.Adult.Total;
                }
                if (this.Ticket.Passangers.HasSeniorAdult)
                {
                    total += this.PriceDetail.Senior.Total;
                }
                if (this.Ticket.Passangers.HasChildren)
                {
                    total += this.PriceDetail.Child.Total;
                }
                return total;

            }
        }


        /// <summary>
        /// Gets the total discount.
        /// </summary>
        [Browsable(false)]
        public decimal TotalDiscount
        {
            get
            {
                decimal totalDiscount = 0;
                if (this.Ticket.Passangers.HasAdults)
                {
                    totalDiscount += this.PriceDetail.Adult.Discount;
                }
                if (this.Ticket.Passangers.HasSeniorAdult)
                {
                    totalDiscount += this.PriceDetail.Senior.Discount;
                }
                if (this.Ticket.Passangers.HasChildren)
                {
                    totalDiscount += this.PriceDetail.Child.Discount;
                }
                return totalDiscount;

            }
        }
        /// <summary>
        /// Gets the total base price.
        /// </summary>
        [Browsable(false)]
        public decimal TotalBasePrice
        {
            get
            {
                decimal totalDiscount = 0;
                if (this.Ticket.Passangers.HasAdults)
                {
                    totalDiscount += this.PriceDetail.Adult.BasePrice;
                }
                if (this.Ticket.Passangers.HasSeniorAdult)
                {
                    totalDiscount += this.PriceDetail.Senior.BasePrice;
                }
                if (this.Ticket.Passangers.HasChildren)
                {
                    totalDiscount += this.PriceDetail.Child.BasePrice;
                }
                return totalDiscount;

            }
        }


        /// <summary>
        /// Gets the total extra taxes.
        /// </summary>
        [Browsable(false)]
        public decimal TotalExtraTaxes
        {
            get
            {
                decimal totalExtra = 0;
                if (this.Ticket.Passangers.HasAdults)
                {
                    totalExtra += this.PriceDetail.Adult.TotalExtraTaxes;
                }
                if (this.Ticket.Passangers.HasSeniorAdult)
                {
                    totalExtra += this.PriceDetail.Senior.TotalExtraTaxes;
                }
                if (this.Ticket.Passangers.HasChildren)
                {
                    totalExtra += this.PriceDetail.Child.TotalExtraTaxes;
                }

                return totalExtra;


            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance has infants.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has infants; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool HasInfants
        {

            get
            {
                PriceTotalResponseInterjet.isInfant = this.Ticket.Passangers.GetInfants().Any(); 
                return this.Ticket.Passangers.GetInfants().Any();
            }
        }








        /// <summary>
        /// Gets the segment string.
        /// </summary>
        [Browsable(false)]
        public string SegmentString
        {
            get
            {

                return string.Format("({0}-{1})", this.DepartureStation, this.ArrivalStation);
            }

        }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        [Browsable(false)]
        public InterJetFlightInformation Information
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the arrival station.
        /// </summary>
        /// <value>
        /// The arrival station.
        /// </value>
        [Browsable(false)]
        public string ArrivalStation
        {
            get
            {

                return this.Information.ArrivalStation;
            }
            set
            {

                this.Information.ArrivalStation = value;
            }
        }
        /// <summary>
        /// Gets the intinerary string.
        /// </summary>
        [Browsable(false)]
        public string IntineraryString
        {
            get
            {
                return string.Format("{0} - {1}", this.Information.DepartureStation, this.Information.ArrivalStation);
            }

        }
        /// <summary>
        /// Gets or sets the departure station.
        /// </summary>
        /// <value>
        /// The departure station.
        /// </value>
        [Browsable(false)]
        public string DepartureStation
        {
            get
            {
                return this.Information.DepartureStation;
            }
            set
            {
                this.Information.DepartureStation = value;

            }
        }
        /// <summary>
        /// Gets the departure.
        /// </summary>
        public string Departure
        {
            get
            {
                return string.Format("{0} hrs", this.Information.Departure.ToString("HH:mm"));
            }

        }
        /// <summary>
        /// Gets the arrival.
        /// </summary>
        public string Arrival
        {
            get
            {
                return string.Format("{0} hrs", this.Information.Arrival.ToString("HH:mm"));
            }

        }


        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public string Price
        {
            get
            {
                return this.Information.PriceDecimal.ToString("c", new CultureInfo("es-MX"));
            }
            set
            {
                this.Information.Price = value;
                this.Information.PriceDecimal = Convert.ToDecimal(value);
            }
        }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        /// <value>
        /// The flight number.
        /// </value>
        public string FlightNumber
        {
            get
            {
                return this.Information.FlightNumber;
            }
            set
            {
                this.Information.FlightNumber = value;

            }
        }
        /// <summary>
        /// Gets or sets the journey sell key.
        /// </summary>
        /// <value>
        /// The journey sell key.
        /// </value>
        [Browsable(false)]
        public string JourneySellKey
        {
            get
            {
                return this.Information.JourneySellKey;
            }
            set
            {

                this.Information.JourneySellKey = value;
            }
        }
        /// <summary>
        /// Gets or sets the fare sell key.
        /// </summary>
        /// <value>
        /// The fare sell key.
        /// </value>
        [Browsable(false)]
        public string FareSellKey
        {
            get
            {
                return this.Information.FareSellKey;

            }
            set
            {
                this.Information.FareSellKey = value;
            }
        }
        /// <summary>
        /// Gets or sets the flight designator.
        /// </summary>
        /// <value>
        /// The flight designator.
        /// </value>
        [Browsable(false)]
        public InterJetFlightDesignator FlightDesignator
        {
            get
            {
                return this.Information.FlightDesignator;
            }
            set
            {
                this.Information.FlightDesignator = value;
            }
        }
        [Browsable(false)]
        public InterJetFare Fare
        {
            get
            {
                return this.Information.Fare;
            }
            set
            {
                this.Information.Fare = value;

            }
        }
        /// <summary>
        /// Gets or sets the arrival date time.
        /// </summary>
        /// <value>
        /// The arrival date time.
        /// </value>
        [Browsable(false)]
        public DateTime ArrivalDateTime
        {
            get
            {
                return this.Information.Arrival;
            }
            set
            {
                this.Information.Arrival = value;
            }
        }
        [Browsable(false)]
        public DateTime DepartureTime
        {
            get
            {
                return this.Information.Departure;
            }
            set
            {
                this.Information.Departure = value;
            }
        }
        [Browsable(false)]
        public InterJetFlightDetailPrice PriceDetail
        {
            get;
            set;
        }



        [Browsable(false)]
        public decimal IvaTotal
        {
            get
            {
                if (this.PriceDetail != null)
                {
                    decimal totalIva = 0;
                    if (this.PriceDetail.Adult != null)
                    {
                        totalIva += this.PriceDetail.Adult.IVA;
                    }
                    if (this.PriceDetail.Child != null)
                    {
                        totalIva += this.PriceDetail.Child.IVA;
                    }
                    if (this.PriceDetail.Senior != null)
                    {
                        totalIva += this.PriceDetail.Senior.IVA;
                    }

                    return totalIva;
                }
                return 0;
            }
        }

        [Browsable(false)]
        public decimal TUATotal
        {
            get
            {
                if (this.PriceDetail != null)
                {
                    decimal totalIva = 0;
                    if (this.PriceDetail.Adult != null)
                    {
                        totalIva += this.PriceDetail.Adult.TUA;
                    }
                    if (this.PriceDetail.Child != null)
                    {
                        totalIva += this.PriceDetail.Child.TUA;
                    }
                    if (this.PriceDetail.Senior != null)
                    {
                        totalIva += this.PriceDetail.Senior.TUA;
                    }

                    return totalIva;
                }
                return 0;
            }
        }


        public bool Equals(InterJetFlight flightToCompare)
        {
            if (this.DepartureTime.TimeOfDay == flightToCompare.DepartureTime.TimeOfDay &&
              this.DepartureStation.Equals(flightToCompare.DepartureStation) &&
              this.ArrivalStation.Equals(flightToCompare.ArrivalStation) &&
              this.FlightNumber == flightToCompare.FlightNumber)
            {
                return false;
            }

            return false;
        }

        public bool OverLap(InterJetFlight flightToCompare)
        {

            if (this.DepartureTime.TimeOfDay > flightToCompare.DepartureTime.TimeOfDay)
            {
                return false;
            }


            return false;
        }
        [Browsable(false)]
        public string DetailPriceHeader
        {
            get
            {

                return string.Format("Vuelo : {0} - {1} \r\nSalida : {2} hrs Llegada : {3} hrs", this.DepartureStation, this.ArrivalStation, this.DepartureTime.ToString("HH:mm"), this.ArrivalDateTime.ToString("HH:mm"));

            }
        }

        [Browsable(false)]
        public bool IsInternational
        {

            get;
            set;
        }

        [Browsable(false)]
        public bool IsRoundTrip
        {

            get;
            set;
        }





        #region Miembros de IFlight
        [Browsable(false)]
        public Segments Segments { get; set; }
        [Browsable(false)]
        public string OwnerCompany { get; set; }

        [Browsable(false)]
        public DateTime ArrivalTime { get; set; }

        [Browsable(false)]
        public decimal BasePrice { get; set; }
        [Browsable(false)]
        public bool IsSelected { get; set; }

        [Browsable(false)]
        public string Class { get; set; }

        public void Validate()
        {

        }

        #endregion


        public decimal TotalPrice
        {
            get;
            set;
        }


        public decimal Tax
        {
            get;
            set;
        }


        public bool IsSingleTrip { get; set; }
    }
}
