using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InvalidAvailabilityRequestException : Exception
    {

        public InvalidAvailabilityRequestException(string message)
            : base(message)
        {

        }

        public ErrorCode ErrorCode
        {

            set { this.Data["ErrorCode"] = value; }
        }
    }
}
