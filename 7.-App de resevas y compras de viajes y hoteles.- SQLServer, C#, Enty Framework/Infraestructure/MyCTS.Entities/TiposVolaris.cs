using System;

namespace MyCTS.Entities
{
    [Serializable]
    public class TiposVolaris
    {
        public enum PassengerType
        { Infant = 0, Children = 1, Adult = 2 }

        public enum FlightTypes
        { OnlyTrip = 1, RoundTrip = 2 }

        public enum FlightFullType
        { Inbound = 0, Outbound = 1 }

        public enum FirstTittle
        { MASTER = 0, MR = 1, MRS = 2, MS = 3, CHD = 4, INF = 5 }

        public enum Gender
        { M = 0, F = 1 }

        public enum PaymentType
        { AX = 0, MC = 1, VI = 2 }

        public enum CountryCode
        { MX = 0 }

        public enum PaymentMethodType
        {
            PrePaid = 0,
            ExternalAccount = 1,
            AgencyAccount = 2,
            CreditShell = 3,
            CreditFile = 4,
            Voucher = 5,
            Loyalty = 6,
            Unmapped = -1,
        }
    }    
}
