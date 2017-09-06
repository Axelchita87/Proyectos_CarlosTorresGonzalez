using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisContactEmail
    {
        public VolarisContactEmail()
        {
            Type = VolarisEmailType.Any;
        }
        public string Email { get; set; }
        public VolarisEmailType Type { get; set; }

    }
}
