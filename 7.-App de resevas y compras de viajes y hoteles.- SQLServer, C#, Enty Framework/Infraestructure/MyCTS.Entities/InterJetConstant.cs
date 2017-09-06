using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetConstant
    {
        public const string CarrierCode =  "  ";
        public const string CarrierCodeInternational = "  ";
        public static readonly string[] FareTypes = new string[] { "R" };
        public const string CurrencyCode = "MXN";
        public const string ActionStatusCode = "NN";
        public const string AmericanExpressPaymentCode = "AX";
        public const string VisaMasterCardCode = "VI";
        public const string UniversalAirTravelPlanCode = "TP";
        public const string MasterCard = "MC";
        public const string AMEX3 = "A3";
        public const string ElectronicPurse = "AG";

        public const string CreditCardAccount = "ACCTNO";

        public const string AccountHolderName = "CC::AccountHolderName";

        public const string ExpirationDate = "EXPDAT";

        public const string VerificationCode = "CC::VerificationCode";

        public const string Amount = "AMT";
        public const string IssueByCode = "MX";
        public const string DocTypeCode = "F";

        public const string PostalCode = "Avs::PostalCode";

        public const string GENERIC_ERROR_INTERJET = "OCURRIO UN ERROR AL CONTACTAR AL SERVIDOR, POR FAVOR INTENTE MAS TARDE.";



    }
}
