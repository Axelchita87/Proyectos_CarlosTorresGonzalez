using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments
{
    public class OnSearchingProfileCompletedEventArgs : EventArgs
    {

        public bool Found { get { return Profile != null; } }
        public VolarisProfile Profile { get; set; }
        public IVolarisPassanger Passanger { get; set; }
    }
}
