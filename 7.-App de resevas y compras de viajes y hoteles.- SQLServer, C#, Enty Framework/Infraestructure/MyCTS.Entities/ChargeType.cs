using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public enum ChargeType
    {
        FarePrice = 0,
        Discount = 1,
        IncludedTravelFee = 2,
        IncludedTax = 3,
        TravelFee = 4,
        Tax = 5,
        ServiceCharge = 6,
        PromotionDiscount = 7,
        ConnectionAdjustmentAmount = 8,
        AddOnServicePrice = 9,
        IncludedAddOnServiceFee = 10,
        AddOnServiceFee = 11,
        Calculated = 12,
        Note = 13,
        AddOnServiceMarkup = 14,
        FareSurcharge = 15,
        Loyalty = 16,
        FarePoints = 17,
        DiscountPoints = 18,
        AddOnServiceCancelFee = 19,
        Unmapped = -1,
    }
}
