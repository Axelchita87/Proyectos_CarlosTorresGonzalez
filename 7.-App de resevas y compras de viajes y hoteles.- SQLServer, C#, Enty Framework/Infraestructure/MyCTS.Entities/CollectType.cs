using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public enum CollectType
    {
        SellerChargeable = 0,
        ExternalChargeable = 1,
        SellerNonChargeable = 2,
        ExternalNonChargeable = 3,
        ExternalChargeableImmediate = 4,
        Unmapped = -1,
    }
}
