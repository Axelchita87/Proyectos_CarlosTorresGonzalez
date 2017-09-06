using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture
{
    public interface IVolarisPassangerCaptureView : IBaseView
    {
        VolarisReservation Reservation { get; set; }
    }
}
