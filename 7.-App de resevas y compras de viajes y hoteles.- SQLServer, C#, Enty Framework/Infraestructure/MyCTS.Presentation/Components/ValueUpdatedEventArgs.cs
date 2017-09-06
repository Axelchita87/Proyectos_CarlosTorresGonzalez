using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Presentation.Components
{
   public class ValueUpdatedEventArgs:EventArgs
    {
        /// <summary>
        /// Used to store the new value
        /// </summary>
        private string newValue;

        /// <summary>
        /// Create a new instance of the ValueUpdatedEventArgs class.
        /// </summary>
        /// <param name="newValue">represents the change to the value</param>
        public ValueUpdatedEventArgs(string newValue)
        {
            this.newValue = newValue;
        }

        /// <summary>
        /// Gets the updated value
        /// </summary>
        public string NewValue
        {
            get
            {
                return this.newValue;
            }
        }
    }
}
