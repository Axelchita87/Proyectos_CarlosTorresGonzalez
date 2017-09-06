using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GroupCodeLabel
    {
        private string remarkvalue;
        public string RemarkValue
        {
            get { return remarkvalue; }
            set { remarkvalue = value; }
        }

        private string xmlfuturelabel;
        public string XMLFutureLabel
        {
            get { return xmlfuturelabel; }
            set { xmlfuturelabel = value; }
        }
    }
}
