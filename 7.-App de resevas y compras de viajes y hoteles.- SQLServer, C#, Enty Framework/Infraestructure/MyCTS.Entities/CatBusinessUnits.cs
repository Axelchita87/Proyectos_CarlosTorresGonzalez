using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatBusinessUnits
    {

        private string idbusinessunits;
        public string IDBusinessUnits
        {
            get { return idbusinessunits; }
            set { idbusinessunits = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string idintegra;
        public string IDIntegra
        {
            get { return idintegra; }
            set { idintegra = value; }
        }
    }
}
