using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatPAirlinesFare
    {
        private string catairlinfarid;
        public string CatAirLinFarId
        {
            get { return catairlinfarid; }
            set { catairlinfarid = value; }
        }

        private string catairlinfarname;
        public string CatAirLinFarName
        {
            get { return catairlinfarname; }
            set { catairlinfarname = value; }
        }
    }
}
