using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetInfantPassanger : InterJetPassanger
    {
        public InterJetInfantPassanger()
        {
            this.CanBeInfantAssigned = false;
            this.TypeTitle = "Infante";
        }
    }
}
