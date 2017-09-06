using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ComissionAgreements
    {
        private string domesticcommision;
        public string DomesticCommision
        {
            get { return domesticcommision; }
            set { domesticcommision = value; }
        }

        private string internationalcommision;
        public string InternationalCommision
        {
            get { return internationalcommision; }
            set { internationalcommision = value; }
        }

        private string tourcode;
        public string TourCode
        {
            get { return tourcode; }
            set { tourcode = value; }
        }

        private string osi;
        public string OSI
        {
            get { return osi; }
            set { osi = value; }
        }

        private string itcode;
        public string ITCode
        {
            get { return itcode; }
            set { itcode = value; }
        }

        private string itccommand;
        public string ITCCommand
        {
            get { return itccommand; }
            set { itccommand = value; }
        }
    }
}
