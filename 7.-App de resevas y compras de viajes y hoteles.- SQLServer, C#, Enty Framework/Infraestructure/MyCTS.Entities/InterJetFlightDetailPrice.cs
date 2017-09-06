using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetFlightDetailPrice
    {

        public InterJetPassangerDetailPrice Adult
        {
            get;
            set;
        }

        public InterJetPassangerDetailPrice Senior
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the child.
        /// </summary>
        /// <value>
        /// The child.
        /// </value>
        public InterJetPassangerDetailPrice Child
        {
            get;
            set;
        }



       




        //TODO: Crear los impuestos general para los vuelos internacionales
        public decimal TotalDetailPrice
        {
            get{

                return this.Adult.Total + this.Senior.Total + this.Child.Total;
            }
        }
        public string DateTimeFlight
        {
            get;
            set;
        }


    }
}
