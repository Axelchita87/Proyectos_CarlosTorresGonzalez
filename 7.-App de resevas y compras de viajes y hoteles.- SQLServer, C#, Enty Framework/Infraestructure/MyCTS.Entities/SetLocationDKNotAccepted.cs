using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class SetLocationDKNotAccepted
    {
        private int rulenumber;
        public int RuleNumber
        {
            get { return rulenumber; }
            set { rulenumber = value; }
        }

        private string locationdk;
        public string LocationDK
        {
            get { return locationdk; }
            set { locationdk = value; }
        }
    }
}
