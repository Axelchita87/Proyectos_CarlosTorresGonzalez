using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisDestinationNotFoundException : Exception
    {
        public VolarisDestinationNotFoundException(string message) : base(message)
        {
            
        }

    }
}
