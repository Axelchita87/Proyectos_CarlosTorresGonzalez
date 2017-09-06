using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetOnlyAttribute1
    {
        private string locationdk;
        public string LocationDK
        {
            get { return locationdk; }
            set { locationdk = value; }
        }
    }
}
