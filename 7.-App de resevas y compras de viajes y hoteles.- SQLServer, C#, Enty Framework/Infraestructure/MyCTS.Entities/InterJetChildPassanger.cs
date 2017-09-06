using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetChildPassanger : InterJetPassanger
    {
        public InterJetChildPassanger()
        {
            this.CanBeInfantAssigned = false;
            this.TypeTitle = "Menor";
        }

    }
}
