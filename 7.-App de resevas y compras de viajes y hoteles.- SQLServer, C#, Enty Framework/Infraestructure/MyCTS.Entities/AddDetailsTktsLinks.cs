using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class AddDetailsTktsLinks
    {
        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        private string pnr;
        public string PNR
        {
            get { return pnr; }
            set { pnr = value; }
        }

        private string ticket;
        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        private string paxname;
        public string PaxName
        {
            get { return paxname; }
            set { paxname = value; }
        }

        private string linkvt;
        public string LinkVT
        {
            get { return linkvt; }
            set { linkvt = value; }
        }

        private DateTime dateemition;
        public DateTime DateEmition
        {
            get { return dateemition; }
            set { dateemition = value; }
        }
    }
}
