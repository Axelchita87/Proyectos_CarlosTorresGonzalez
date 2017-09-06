using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CurrencyCountry
    {
        private string currencycode;
        public string CurrencyCode
        {
            get { return currencycode; }
            set { currencycode = value; }
        }
        
        private string currencyname;
        public string CurrencyName
        {
            get { return currencyname; }
            set { currencyname = value; }
        }
        
        private string countryid;
        public string CountryID
        {
            get { return countryid; }
            set { countryid = value; }
        }

        private string countryname;
        public string CountryName
        {
            get { return countryname; }
            set { countryname = value; }
        }

    }
}
