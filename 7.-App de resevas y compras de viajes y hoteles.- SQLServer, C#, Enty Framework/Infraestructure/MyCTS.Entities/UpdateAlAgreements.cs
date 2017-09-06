using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class UpdateAlAgreements
    {
        private string idalcode;
        public string IDAlCode
        {
            get { return idalcode; }
            set { idalcode = value; }
        }
        private string InternationalComission;
        public string internationalcomission
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
        private string iso;
        public string ISO
        {
            get { return iso; }
            set { iso = value; }
        }
    }
}
