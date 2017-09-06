using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class NoReturningFlightSelectedException : Exception
    {

        public NoReturningFlightSelectedException(string message)
            : base(message)
        {


        }


    }
}
