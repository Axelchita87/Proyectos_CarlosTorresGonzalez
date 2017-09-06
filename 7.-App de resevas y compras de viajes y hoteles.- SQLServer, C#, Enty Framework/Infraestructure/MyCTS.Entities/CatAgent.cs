using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
   public class CatAgent
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
    }
}
