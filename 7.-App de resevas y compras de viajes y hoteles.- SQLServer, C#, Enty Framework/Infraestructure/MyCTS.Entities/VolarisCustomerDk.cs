using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisCustomerDk
    {

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        public string Attribute { get; set; }

        public bool IsActive { get; set; }

        public bool Exist { get; set; }


        public bool IsEventual
        {
            get
            {
                if (!string.IsNullOrEmpty(Value))
                {

                    return Value.EndsWith("990");

                }
                return false;
            }
        }
    }
}
