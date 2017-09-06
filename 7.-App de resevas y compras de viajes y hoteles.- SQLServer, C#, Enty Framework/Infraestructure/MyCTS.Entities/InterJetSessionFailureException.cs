using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetSessionFailureException : Exception
    {

        public InterJetSessionFailureException(string message)
            : base(message)
        {

        }
    }
}
