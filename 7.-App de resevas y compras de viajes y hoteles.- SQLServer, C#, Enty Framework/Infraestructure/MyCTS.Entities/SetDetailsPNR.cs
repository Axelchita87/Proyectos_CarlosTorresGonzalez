using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class SetDetailsPNR
    {
        private static string recloc;
        public static string RecLoc
        {
            get { return recloc; }
            set { recloc = value; }
        }

        private static string origin;
        public static string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private static string destination;
        public static string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private static string departuretime;
        public static string DepartureTime
        {
            get { return departuretime; }
            set { departuretime = value; }
        }

        private static string arrivaltime;
        public static string ArrivalTime
        {
            get { return arrivaltime; }
            set { arrivaltime = value; }
        }

        private static string airlinecode;
        public static string AirlineCode
        {
            get { return airlinecode; }
            set { airlinecode = value; }
        }

        private static string flightnumber;
        public static string FlightNumber
        {
            get { return flightnumber; }
            set { flightnumber = value; }
        }

        private static DateTime departuredate;
        public static DateTime DepartureDate
        {
            get { return departuredate; }
            set { departuredate = value; }
        }

        private static string airlineref;
        public static string AirlineRef
        {
            get { return airlineref; }
            set { airlineref = value; }
        }

        private static DateTime traveldate;
        public static DateTime TravelDate
        {
            get { return traveldate; }
            set { traveldate = value; }
        }

        private static string location_dk;
        public static string Location_DK
        {
            get { return location_dk; }
            set { location_dk = value; }
        }

        private static decimal paxnumber;
        public static decimal PaxNumber
        {
            get { return paxnumber; }
            set { paxnumber = value; }
        }

        private static string paxtype;
        public static string PaxType
        {
            get { return paxtype; }
            set { paxtype = value; }
        }

        private static string paxname;
        public static string PaxName
        {
            get { return paxname; }
            set { paxname = value; }
        }

        private static string paxlastname;
        public static string PaxLastName
        {
            get { return paxlastname; }
            set { paxlastname = value; }
        }

        private static string ticketnumber;
        public static string TicketNumber
        {
            get { return ticketnumber; }
            set { ticketnumber = value; }
        }

        private static string segmenttype;
        public static string SegmentType
        {
            get { return segmenttype; }
            set { segmenttype = value; }
        }

        private static string farebasis;
        public static string FareBasis
        {
            get { return farebasis; }
            set { farebasis = value; }
        }

        private static string pcc;
        public static string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }

        private static string idgroup;
        public static string IDGroup
        {
            get { return idgroup; }
            set { idgroup = value; }
        }

        private static string masterpnr;
        public static string MasterPNR
        {
            get { return masterpnr; }
            set { masterpnr = value; }
        }

    }
}