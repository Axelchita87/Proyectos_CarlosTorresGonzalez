using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class AirLinesFare
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
        private bool ccaut;
        public bool CCAut
        {
            get { return ccaut; }
            set { ccaut = value; }
        }

        private bool ccman;
        public bool CCMan
        {
            get { return ccman; }
            set { ccman = value; }
        }
        private bool cash;
        public bool Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        private bool pmix;
        public bool PMix
        {
            get { return pmix; }
            set { pmix = value; }
        }

        private bool misc;
        public bool Misc
        {
            get { return misc; }
            set { misc = value; }
        }

        private bool opmanual;
        public bool OpManual
        {
            get { return opmanual; }
            set { opmanual = value; }
        }

    }
}
