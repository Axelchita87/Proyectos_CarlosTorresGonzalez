using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation.Components
{
    public class CurrencyFormats
    {
        public static bool ValidaDecimales(String sMonto)
        {
            if ((!string.IsNullOrEmpty(sMonto) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(sMonto))))
            {                
                return true;
            }
            return false;
        }

        public static string AgregaDosDecimales(String sMonto)
        {
            Decimal dMonto;

            if (sMonto == null)
                return sMonto;
            if (sMonto == String.Empty)
                return sMonto;

            if (ValidateRegularExpression.ValidateNumbers(sMonto))
            {
                Decimal.TryParse(sMonto, out dMonto);
                return String.Format("{0:0.00}", dMonto);
            }

            return sMonto;
        }
    }
}
