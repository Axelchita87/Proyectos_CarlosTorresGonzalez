using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatTransaction
    {
        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        private string recloc;
        public string RecLoc
        {
            get { return recloc; }
            set { recloc = value; }
        }

        private string command;
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        private string areaGuid;
        public string AreaGuid
        {
            get { return areaGuid; }
            set { areaGuid = value; }

        }


    }
}

