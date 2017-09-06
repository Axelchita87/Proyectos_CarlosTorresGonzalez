using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetAdultPassanger : InterJetPassanger
    {
        public InterJetAdultPassanger()
        {
            this.CanBeInfantAssigned = true;
            this.TypeTitle = "Adulto";
        }




        public InterJetPassangerInfant AssignedInfant
        {
            get;
            set;
        }

        public bool HasAlreadyAInfant
        {
            get{
                return this.AssignedInfant != null;
            }
        }

    }
}
