using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class AirPort
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
