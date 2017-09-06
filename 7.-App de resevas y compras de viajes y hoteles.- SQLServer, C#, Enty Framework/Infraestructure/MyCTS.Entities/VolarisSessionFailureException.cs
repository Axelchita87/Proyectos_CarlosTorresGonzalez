using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisSessionFailureException : Exception
    {
        public VolarisSessionFailureException(string message)
            : base(message)
        {

        }

    }
}
