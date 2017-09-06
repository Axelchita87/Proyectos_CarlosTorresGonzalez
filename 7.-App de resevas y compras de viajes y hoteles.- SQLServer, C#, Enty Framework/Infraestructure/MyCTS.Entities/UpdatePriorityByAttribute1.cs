using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class UpdatePriorityByAttribute1
    {
        private int newpriority;
        public int NewPriority
        {
            get { return newpriority; }
            set { newpriority = value; }
        }

        private string attribute1;
        public string Attribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }
    }
}
