using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetDestinationNotFoundException : Exception
    {
        public InterJetDestinationNotFoundException(string message)
            : base(message)
        {

        }

    }
}
