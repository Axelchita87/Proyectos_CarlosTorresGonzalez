using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatCities
    {
        private string catcitid;
        public string CatCitId
        {
            get { return catcitid; }
            set { catcitid = value; }
        }

        private string catcitname;
        public string CatCitName
        {
            get { return catcitname; }
            set { catcitname = value; }
        }
    }
}
