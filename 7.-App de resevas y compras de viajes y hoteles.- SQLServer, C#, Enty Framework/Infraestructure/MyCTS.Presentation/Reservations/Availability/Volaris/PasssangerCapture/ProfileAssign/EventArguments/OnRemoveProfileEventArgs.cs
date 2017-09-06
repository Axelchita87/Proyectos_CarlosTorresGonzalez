using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments
{
    public class OnRemoveProfileEventArgs : EventArgs
    {

        public VolarisAdultPassanger Passanger { get; set; }
    }
}
