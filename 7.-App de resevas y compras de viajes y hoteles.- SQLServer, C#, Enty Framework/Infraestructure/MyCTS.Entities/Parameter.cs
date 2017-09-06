using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class Parameter
    {
        private string parametername;
        public string ParameterName
        {
            get { return parametername; }
            set { parametername = value; }
        }

        private string values;
        public string Values
        {
            get { return values; }
            set { values = value; }
        }

    }
}
