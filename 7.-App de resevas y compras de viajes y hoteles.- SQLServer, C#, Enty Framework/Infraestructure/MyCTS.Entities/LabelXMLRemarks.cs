using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class LabelXMLRemarks
    {

        private string attribute1;
        public string Attribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }

        private string idprocess;
        public string IDProcess
        {
            get { return idprocess; }
            set { idprocess = value; }
        }

        private string remarkvalue;
        public string RemarkValue
        {
            get { return remarkvalue; }
            set { remarkvalue = value; }
        }

        private string ticketposition;
        public string TicketPosition
        {
            get{return ticketposition;}
            set{ticketposition=value;}
        }

        private string xmlactuallabel;
        public string XMLActualLabel
        {
            get { return xmlactuallabel; }
            set { xmlactuallabel = value; }
        }

        private string xmlfuturelabel;
        public string XMLFutureLabel
        {
            get { return xmlfuturelabel; }
            set { xmlfuturelabel = value; }
        }
    }
}
