using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
   public class AirportCodes
    {
        private string cityid;
        public string CityID
        {
            get { return cityid; }
            set { cityid = value; }
        }
       
        private string cityname;
        public string CityName
        {
            get { return cityname; }
            set { cityname = value; }
        }

        private string countryid;
        public string CountryID
        {
            get {return countryid;}
            set {countryid = value;}
        }

        private string countryname;
        public string CountryName
        {
            get {return countryname;}
            set {countryname = value;}
        }




    }
}
