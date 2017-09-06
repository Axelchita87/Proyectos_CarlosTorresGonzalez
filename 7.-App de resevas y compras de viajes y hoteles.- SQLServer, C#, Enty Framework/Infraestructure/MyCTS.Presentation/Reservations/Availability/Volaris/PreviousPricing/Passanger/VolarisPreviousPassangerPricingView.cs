using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Passanger
{
    public interface VolarisPreviousPassangerPricingView : IBaseView
    {
        void SetFare(VolarisPassangerFare fare);
        decimal BasePrice { get; set; }
        decimal Taxes { get; set; }
        decimal Total { get; set; }
        string PassangerCount { get; set; }
        VolarisPassangerType PassangerType { get; set; }

    }
}
