using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.ContactInformation
{
    public interface IVolarisContactInformationView : IBaseView
    {
        VolarisContact Contact { get; set; }
    }
}
