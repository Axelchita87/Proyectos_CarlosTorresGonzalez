using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PassangerConfirmation
{
    public interface IVolarisPassangerConfirmationView : IBaseView
    {

       VolarisPassangers Passangers { get; set; }

       
    }
}
