using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetQCbyAttribute1
    {
        private string idctrl;
        public string IdCtrl
        {
            get { return idctrl; }
            set { idctrl = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string valuectrl;
        public string ValueCtrl
        {
            get { return valuectrl; }
            set { valuectrl = value; }
        }
    }
}
