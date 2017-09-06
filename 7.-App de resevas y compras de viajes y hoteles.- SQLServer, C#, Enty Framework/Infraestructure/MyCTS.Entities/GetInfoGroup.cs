using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetInfoGroup
    {
        private string pnr;
        public string PNR
        {
            get { return pnr; }
            set { pnr = value; }
        }

        private string recloc;
        public string RecLoc
        {
            get { return recloc; }
            set { recloc = value; }
        }

        private string origin;
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private string departuretime;
        public string DepartureTime
        {
            get { return departuretime; }
            set { departuretime = value; }
        }

        private string arrivaltime;
        public string ArrivalTime
        {
            get { return arrivaltime; }
            set { arrivaltime = value; }
        }

        private string airlinecode;
        public string AirlineCode
        {
            get { return airlinecode; }
            set { airlinecode = value; }
        }

        private string airlineref;
        public string AirlineRef
        {
            get { return airlineref; }
            set { airlineref = value; }
        }

        private string flightnumber;
        public string FlightNumber
        {
            get { return flightnumber; }
            set { flightnumber = value; }
        }

        private DateTime departuredate;
        public DateTime DepartureDate
        {
            get { return departuredate; }
            set { departuredate = value; }
        }

        private string paxname;
        public string PaxName
        {
            get { return paxname; }
            set { paxname = value; }
        }

        private string paxlastname;
        public string PaxLastName
        {
            get { return paxlastname; }
            set { paxlastname = value; }
        }

        private decimal paxnumber;
        public decimal PaxNumber
        {
            get { return paxnumber; }
            set { paxnumber = value; }
        }

        private string masterpnr;
        public string MasterPNR
        {
            get { return masterpnr; }
            set { masterpnr = value; }
        }
        private string idgroup;
        public string IDGroup
        {
            get { return idgroup; }
            set { idgroup = value; }
        }

    }
}
