using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ViewCars
    {
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
