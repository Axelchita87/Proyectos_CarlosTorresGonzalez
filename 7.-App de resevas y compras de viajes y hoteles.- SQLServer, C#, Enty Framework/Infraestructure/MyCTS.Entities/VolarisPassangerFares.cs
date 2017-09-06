using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisPassangerFares
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="VolarisPassangerFares"/> class.
        /// </summary>
        public VolarisPassangerFares()
        {
            Adult = new VolarisPassangerFare();
            Child = new VolarisPassangerFare();
            Infant = new VolarisPassangerFare();

        }
        /// <summary>
        /// Gets or sets the adult.
        /// </summary>
        /// <value>
        /// The adult.
        /// </value>
        public VolarisPassangerFare Adult { get; set; }

        /// <summary>
        /// Gets or sets the child.
        /// </summary>
        /// <value>
        /// The child.
        /// </value>
        public VolarisPassangerFare Child { get; set; }

        /// <summary>
        /// Gets or sets the infant.
        /// </summary>
        /// <value>
        /// The infant.
        /// </value>
        public VolarisPassangerFare Infant { get; set; }

        /// <summary>
        /// Gets the passanger fares.
        /// </summary>
        /// <returns></returns>
        public List<VolarisPassangerFare> GetPassangerFares()
        {
            var passangerFares = new List<VolarisPassangerFare>();

            if (Adult.Count > 0)
            {
                passangerFares.Add(Adult);
            }
            if (Child.Count > 0)
            {
                passangerFares.Add(Child);
            }

            if (Infant.Count > 0)
            {
                passangerFares.Add(Infant);
            }
            return passangerFares;
        }


    }
}
