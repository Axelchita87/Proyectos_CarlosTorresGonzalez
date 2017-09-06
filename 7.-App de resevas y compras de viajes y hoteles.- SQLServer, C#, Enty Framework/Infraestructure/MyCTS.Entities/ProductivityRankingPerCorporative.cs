
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ProductivityRankingPerCorporative
    {
        

        private string initialdate;
        public string InitialDate
        {
            get { return initialdate; }
            set { initialdate = value; }
        }

        private string finaldate;
        public string FinalDate
        {
            get { return finaldate; }
            set { finaldate = value; }
        }

        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        private string familyname;
        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value; }
        }

        private int airproductivity;
        public int AirProductivity
        {
            get { return airproductivity; }
            set { airproductivity = value; }
        }

      
        private int hotelproductivity;
        public int HotelProductivity
        {
            get { return hotelproductivity; }
            set { hotelproductivity = value; }
        }

        private int autoproductivity;
        public int AutoProductivity
        {
            get { return autoproductivity; }
            set { autoproductivity = value; }
        }

        private int pnrproductivity;
        public int PNRProductivity
        {
            get { return pnrproductivity; }
            set { pnrproductivity = value; }
        }


        private int cancelledpnrproductivity;
        public int CancelledPNRProductivity
        {
            get { return cancelledpnrproductivity; }
            set { cancelledpnrproductivity = value; }
        }

        private int avgscanperpnrproductivity;
        public int AvgScanPerPNRProductivity
        {
            get { return avgscanperpnrproductivity; }
            set { avgscanperpnrproductivity = value; }
        }

        private int emittedtktproductivity;
        public int EmittedTKTProductivity
        {
            get { return emittedtktproductivity; }
            set { emittedtktproductivity = value; }
        }


        private int cancelledtktproductivity;
        public int CancelledTKTProductivity
        {
            get { return cancelledtktproductivity; }
            set { cancelledtktproductivity = value; }
        }

        private int totalpnrvstktproductivity;
        public int TotalPNRVsTKTProductivity
        {
            get { return totalpnrvstktproductivity; }
            set { totalpnrvstktproductivity = value; }
        }

        
    }
}
