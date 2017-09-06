using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyCTS.Entities
{
    public class InterJetFlightInformation
    {

        public string ClassOfService { get; set; }
        public DateTime Departure
        {
            get;
            set;
        }

        public DateTime Arrival
        {
            get;
            set;
        }

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
        public string FlightNumber
        {
            get;
            set;
        }

        public decimal PriceDecimal
        {
            get;
            set;
        }

        public string Price
        {
            get
            {
                return this.PriceDecimal.ToString();
            }
            set
            {
                this.PriceDecimal = Convert.ToDecimal(value);
            }
        }

        public string JourneySellKey
        {
            get;
            set;
        }

        public string FareSellKey
        {
            get;
            set;
        }

        public InterJetFlightDesignator FlightDesignator
        {
            get;
            set;
        }

        public InterJetFare Fare
        {
            get;
            set;
        }
    }
}
