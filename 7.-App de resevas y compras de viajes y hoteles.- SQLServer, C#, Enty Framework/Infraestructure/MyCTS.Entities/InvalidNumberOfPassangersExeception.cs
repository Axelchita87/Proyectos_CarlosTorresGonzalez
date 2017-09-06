using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InvalidNumberOfPassangersExeception : Exception
    {

        public InvalidNumberOfPassangersExeception(string message)
            : base(message)
        {

        }


        public ErrorCode ErrorCode
        {

            set { this.Data["ErrorCode"] = value; }
        }

    }
}
