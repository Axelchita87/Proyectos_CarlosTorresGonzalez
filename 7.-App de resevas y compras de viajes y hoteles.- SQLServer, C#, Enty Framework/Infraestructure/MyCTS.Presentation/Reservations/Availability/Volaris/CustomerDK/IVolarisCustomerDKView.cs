using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CustomerDK
{
    public interface IVolarisCustomerDKView : IBaseView
    {
        VolarisCustomerDk CustomerDk { get; set; }
    }
}
