using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetLinkByTkt
    {
        private string ticket;
        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        private string linkinvoice;
        public string LinkInvoice
        {
            get { return linkinvoice; }
            set { linkinvoice = value; }
        }

        private string linkvirtuallythere;
        public string LinkVirtuallyThere
        {
            get { return linkvirtuallythere; }
            set { linkvirtuallythere = value; }
        }

        private string descriptiontype;
        public string DescriptionType
        {
            get { return descriptiontype; }
            set { descriptiontype = value; }
        }

        private string linkPassengerReceipt;
        public string LinkPassengerReceipt
        {
            get { return linkPassengerReceipt; }
            set { linkPassengerReceipt = value; }
        }

        private string linkTicketPrinter;
        public string LinkTicketPrinter 
        {
            get { return linkTicketPrinter; }
            set { linkTicketPrinter = value; }
        }

    }
}
