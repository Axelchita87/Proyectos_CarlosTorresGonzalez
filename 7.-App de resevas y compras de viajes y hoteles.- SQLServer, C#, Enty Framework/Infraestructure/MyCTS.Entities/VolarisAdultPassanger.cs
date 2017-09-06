using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisAdultPassanger : IVolarisPassanger
    {

        public bool HasAssignedAndInfant
        {
            get { return AssignedInfat != null; }
        }
        public VolarisInfantPassanger AssignedInfat { get; set; }
    }
}
