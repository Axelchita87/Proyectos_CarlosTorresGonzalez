using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments
{
    public class OnDynamicControlsBuiltEventArgs : EventArgs
    {

        public Control Control { get; set; }
    }
}
