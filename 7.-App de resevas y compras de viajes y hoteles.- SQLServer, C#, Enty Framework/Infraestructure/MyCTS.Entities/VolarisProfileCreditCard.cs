using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisProfileCreditCard
    {
        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        /// <value>
        /// The credit card number.
        /// </value>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public VolarisProfileCreditCardLevel Level { get; set; }

        public VolarisCreditCardType Type { get; set; }

        public bool IsValid { get; set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="InterJetProfileCreditCard"/> class.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="isFristLevel">if set to <c>true</c> [is frist level].</param>
        public VolarisProfileCreditCard(string creditCardNumber, bool isFristLevel)
        {
            if (!string.IsNullOrEmpty(creditCardNumber))
            {
                if (isFristLevel)
                {
                    this.ParseCreditCardFromFristLevel(creditCardNumber);
                }
                else
                {
                    this.ParseCreditCardFromSecondLevel(creditCardNumber);
                }
            }


        }

        /// <summary>
        /// Parses the credit card from second level.
        /// </summary>
        /// <param name="creditCard">The credit card.</param>
        private void ParseCreditCardFromSecondLevel(string creditCard)
        {
            string[] creditCardParts = creditCard.Split("*#*".ToCharArray());
            bool isValidCard = creditCardParts.Count() >= 10 && !string.IsNullOrEmpty(creditCardParts[0]);
            if (isValidCard)
            {
                IsValid = true;
                if (creditCardParts[0].Equals("AX"))
                {
                    Type = VolarisCreditCardType.AmericanExpress;

                }

                if (creditCardParts[0].Equals("TP"))
                {
                    Type = VolarisCreditCardType.UniversalTravelPlan;
                }

                if (creditCardParts[0].Equals("VI"))
                {
                    Type = VolarisCreditCardType.Visa;

                }

                if (creditCardParts[0].Equals("CA"))
                {
                    Type = VolarisCreditCardType.MasterCard;
                }
                string expiration = string.Format("01/{0}/{1}", creditCardParts[6], creditCardParts[9]);
                ExpirationDate = DateTime.Parse(expiration);
                CreditCardNumber = creditCardParts[3];
                Level = VolarisProfileCreditCardLevel.Second;


            }
            else
            {
                IsValid = false;
            }




        }
        /// <summary>
        /// Parses the credit card from frist level.
        /// </summary>
        /// <param name="creditCard">The credit card.</param>
        private void ParseCreditCardFromFristLevel(string creditCard)
        {

            string[] creditCardParts = creditCard.Split('*');
            bool isValidCard = creditCardParts.Count() == 4 && !string.IsNullOrEmpty(creditCardParts[0]);
            if (isValidCard)
            {
                IsValid = true;
                if (creditCardParts[0].Equals("AX"))
                {
                    Type = VolarisCreditCardType.AmericanExpress;
                }

                if (creditCardParts[0].Equals("TP"))
                {
                    Type = VolarisCreditCardType.UniversalTravelPlan;
                }
                if (creditCardParts[0].Equals("VI"))
                {
                    Type = VolarisCreditCardType.Visa;
                }

                if (creditCardParts[0].Equals("CA"))
                {
                    Type = VolarisCreditCardType.MasterCard;
                }

                ExpirationDate = GetExpirationFromFristLevelCards(creditCardParts[3]);
                CreditCardNumber = creditCardParts[1];
                Level = VolarisProfileCreditCardLevel.Frist;

            }
            else
            {
                IsValid = false;
            }


        }

        private DateTime GetExpirationFromFristLevelCards(string date)
        {
            try
            {
                const string defaultMonth = "01";
                DateTime expirationTime = DateTime.Parse(string.Format("{0}/{1}", defaultMonth, date));
                return expirationTime;
            }
            catch
            {
                return DateTime.Now;
            }

        }


        /// <summary>
        /// Gets the full protected card.
        /// </summary>
        public string FullProtectedCard
        {
            get
            {

                var stringType = "";
                if (Type == VolarisCreditCardType.AmericanExpress)
                {
                    stringType = "AX";
                }
                if (Type == VolarisCreditCardType.UniversalTravelPlan)
                {
                    stringType = "TP";
                }
                if (Type == VolarisCreditCardType.Visa)
                {
                    stringType = "VI";
                }
                if (Type == VolarisCreditCardType.MasterCard)
                {
                    stringType = "MC";
                }
                return string.Format("{0}-{1}", stringType, this.CreditCardNumberProtected);
            }
        }

        /// <summary>
        /// Gets the credit card number protected.
        /// </summary>
        public string CreditCardNumberProtected
        {
            get
            {
                if (!string.IsNullOrEmpty(CreditCardNumber))
                {
                    int stringLength = this.CreditCardNumber.Length;
                    string lastFourDigits = this.CreditCardNumber.Substring(stringLength - 4, 4);
                    int xValues = stringLength - 4;

                    string newProtectedCard = "";
                    for (int value = 0; value < xValues; value++)
                    {
                        newProtectedCard = string.Concat(newProtectedCard, "X");
                    }
                    return string.Format("{0}{1}", newProtectedCard, lastFourDigits);
                }
                return "";

            }
        }

    }
}
