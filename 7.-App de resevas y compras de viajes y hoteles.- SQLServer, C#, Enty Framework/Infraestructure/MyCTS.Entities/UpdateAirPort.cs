using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class UpdateAirPort
    {

        private string catairporcode;
        public string CatAirPorCode
        {
            get { return catairporcode; }
            set { catairporcode = value; }
        }

        private string catairporname;
        public string CatAirPorName
        {
            get { return catairporname; }
            set { catairporname = value; }
        }

        private string catairporcountryid;
        public string CatAirPorCountryId
        {
            get { return catairporcountryid; }
            set { catairporcountryid = value; }
        }
    }
}
