using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatQueue
    {

        private string queuetosearch;
        public string QueueToSearch
        {
            get { return queuetosearch; }
            set { queuetosearch = value; }
        }

        private string pcctosearch;
        public string PCCToSearch
        {
            get { return pcctosearch; }
            set { pcctosearch = value; }
        }

        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }
        private string queue;
        public string Queue
        {
            get { return queue; }
            set { queue = value; }
        }
        private string pcc;
        public string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }
    }
}
