using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatCountries
    {
        private string strtosearch;
        public string StrToSearch
        {
            get { return strtosearch; }
            set { strtosearch = value; }
        }

        private string catcouid;
        public string CatCouId
        {
            get { return catcouid; }
            set { catcouid = value; }
        }

        private string catcouname;
        public string CatCouName
        {
            get { return catcouname; }
            set { catcouname = value; }
        }
    }
}
