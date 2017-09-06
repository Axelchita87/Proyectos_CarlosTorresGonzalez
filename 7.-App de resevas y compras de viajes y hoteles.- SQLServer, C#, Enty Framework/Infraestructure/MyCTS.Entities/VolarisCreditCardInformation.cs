using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisCreditCardInformation
    {

        public VolarisCreditCardInformation()
        {

        }

        private Dictionary<VolarisCreditCardType, string> _converterCard = new Dictionary<VolarisCreditCardType, string>
                                                                               {
                                                                                   {VolarisCreditCardType.AmericanExpress, "AX"},
                                                                                   {VolarisCreditCardType.Visa, "VI"},
                                                                                   {VolarisCreditCardType.MasterCard, "CA"}
                                                                               };
        public string CreditCardStringType
        {
            get
            {
                if (_converterCard.ContainsKey(Type))
                {
                    return _converterCard[Type];
                }
                return string.Empty;
            }
        }

        public string AccountingLineCard
        {

            get
            {
                if (_converterCard.ContainsKey(Type))
                {
                    return string.Format("CC{0}{1}", _converterCard[Type], this.CreditCardNumber);
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public VolarisCreditCardType Type { get; set; }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        /// <value>
        /// The credit card number.
        /// </value>
        public string CreditCardNumber { get; set; }
        /// <summary>
        /// Gets or sets the security code.
        /// </summary>
        /// <value>
        /// The security code.
        /// </value>
        public string SecurityCode { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is from client.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is from client; otherwise, <c>false</c>.
        /// </value>
        public bool IsFromClient { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is from CTS.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is from CTS; otherwise, <c>false</c>.
        /// </value>
        public bool IsFromCts { get; set; }

        public string FullProtectedCard
        {
            get
            {

                if (!string.IsNullOrEmpty(CreditCardNumber))
                {
                    string protectedCard = "";
                    for (int number = 0; number < CreditCardNumber.Length - 3; number++)
                    {
                        protectedCard += "X";
                    }
                    string lastThreDigits = CreditCardNumber.Substring(CreditCardNumber.Length - 3, 3);

                    return string.Format("{0}{1}", protectedCard, lastThreDigits);
                }
                return "";
            }
        }



    }
}
