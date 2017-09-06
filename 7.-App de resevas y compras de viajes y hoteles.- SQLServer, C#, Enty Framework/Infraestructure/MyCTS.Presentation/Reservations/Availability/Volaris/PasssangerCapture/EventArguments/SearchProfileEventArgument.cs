using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.EventArguments
{
    public class SearchProfileEventArgument : EventArgs
    {

        public string FristLevelProfile { get; set; }
        public string SecondLevelProfile { get; set; }
        public IVolarisPassanger Passanger { get; set; }

    }
}
