using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetSeniorAdultPassanger : InterJetPassanger
    {
   
        public InterJetSeniorAdultPassanger()
        {
            this.CanBeInfantAssigned = true;
            this.TypeTitle = "Adulto Mayor";
        }



        public InterJetPassangerInfant AssignedInfant
        {
            get;
            set;
        }

        public bool HasAlreadyAInfant
        {
            get
            {
                return this.AssignedInfant != null;
            }
        }
    }
}
