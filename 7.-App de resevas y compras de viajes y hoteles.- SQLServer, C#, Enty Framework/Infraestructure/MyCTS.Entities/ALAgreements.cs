using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ALAgreements
    {
        private string idalcode;
        public string IDAlCode
        {
            get { return idalcode; }
            set { idalcode = value; }
        }
        private string internationalcomission;
        public string InternationalComission
        {
            get { return internationalcomission; }
            set { internationalcomission = value; }
        }
        private string domesticcomission;
        public string DomesticComission
        {
            get { return domesticcomission; }
            set { domesticcomission = value; }
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
    }
}
