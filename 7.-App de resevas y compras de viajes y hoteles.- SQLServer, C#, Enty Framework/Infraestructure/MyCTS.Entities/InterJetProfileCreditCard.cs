using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetProfileCreditCard
    {
        /// <summary>
        /// Gets or sets the titular name.
        /// </summary>
        /// <value>
        /// Thetitular name.
        /// </value>
        public string titular { get; set; }

        /// <summary>
        /// Gets or sets the CVV number.
        /// </summary>
        /// <value>
        /// The CVV number.
        /// </value>
        public string CVV { get; set; }

        /// <summary>
        /// Gets or sets the Code Postal
        /// </summary>
        /// <value>
        /// The Code Postal.
        /// </value>
        public string CP { get; set; }

        /// <summary>
        /// Gets or sets the Code Postal
        /// </summary>
        /// <value>
        /// The Code Postal.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Code Postal
        /// </summary>
        /// <value>
        /// The Code Postal.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Code Postal
        /// </summary>
        /// <value>
        /// The Code Postal.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public InterJetProfileCrediCardType Type { get; set; }

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

        public bool AirService { get; set; }

        public bool HtlService { get; set; }

        public bool CarService { get; set; }

        public String ServDesc { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public InterJetProfileCrediCardLevelType Level { get; set; }


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
                    return string.Format("{0}{1}    {2}{3}", newProtectedCard, lastFourDigits, ((AirService) ? "AIR  " : string.Empty) + ((HtlService) ? "HTL  " : string.Empty) + ((CarService) ? "CAR  " : string.Empty), ServDesc);
                }

                return "";
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="InterJetProfileCreditCard"/> class.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="isFristLevel">if set to <c>true</c> [is frist level].</param>
        public InterJetProfileCreditCard(string creditCardNumber, bool isFristLevel)
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
            try
            {
                string[] creditCardParts = creditCard.Split(new string[] { "*#*" }, StringSplitOptions.None);
                bool isValidCard = creditCardParts.Count() >= 10 && !string.IsNullOrEmpty(creditCardParts[0]);
                if (isValidCard)
                {
                    IsValid = true;
                    if (creditCardParts[0].Equals("AX"))
                    {
                        Type = InterJetProfileCrediCardType.AmericanExpress;

                    }

                    if (creditCardParts[0].Equals("TP"))
                    {
                        Type = InterJetProfileCrediCardType.UniversalTravelPlan;
                    }

                    if (creditCardParts[0].Equals("VI"))
                    {
                        Type = InterJetProfileCrediCardType.Visa;

                    }

                    if (creditCardParts[0].Equals("CA"))
                    {
                        Type = InterJetProfileCrediCardType.MasterCard;
                    }
                    string expiration = string.Format("01/{0}/{1}", creditCardParts[2], creditCardParts[3]);
                    ExpirationDate = DateTime.Parse(expiration);
                    CreditCardNumber = creditCardParts[1];
                    Level = InterJetProfileCrediCardLevelType.Second;
                    CVV = creditCardParts.Length > 14 ? creditCardParts[14] : string.Empty;
                    CP = creditCardParts[9];
                    State = creditCardParts[7];
                    City = creditCardParts[6];
                    Address = creditCardParts[5] + " " + creditCardParts[6] + " " + creditCardParts[7];

                    titular = creditCardParts[4];
                }
                else
                {
                    IsValid = false;
                }
            }catch{}
        }
        /// <summary>
        /// Parses the credit card from frist level.
        /// </summary>
        /// <param name="creditCard">The credit card.</param>
        private void ParseCreditCardFromFristLevel(string creditCard)
        {
            string[] creditCardParts = creditCard.Split('*');
            bool isValidCard = creditCardParts.Count() >= 2 && !string.IsNullOrEmpty(creditCardParts[0]);
            if (isValidCard)
            {
                IsValid = true;
                if (creditCardParts[0].Equals("AX"))
                {
                    Type = InterJetProfileCrediCardType.AmericanExpress;
                }

                if (creditCardParts[0].Equals("TP"))
                {
                    Type = InterJetProfileCrediCardType.UniversalTravelPlan;
                }
                if (creditCardParts[0].Equals("VI"))
                {
                    Type = InterJetProfileCrediCardType.Visa;
                }

                if (creditCardParts[0].Equals("CA"))
                {
                    Type = InterJetProfileCrediCardType.MasterCard;
                }

                //TP*1231231231231231^09/14^RdCCXs17QJU=^Y*N*Y*EMPLEADO
                CreditCardNumber = creditCardParts[1].Split('^')[0];
                string day = creditCardParts[1].Split('^')[1].Split('/')[0];
                string month = creditCardParts[1].Split('^')[1].Split('/')[1];
                string expiration = string.Format("01/{0}/{1}", day, month);
                ExpirationDate = DateTime.Parse(expiration);
                CVV = creditCardParts[1].Split('^')[2];
                Level = InterJetProfileCrediCardLevelType.Frist;

                List<string> serviceType = creditCard.Split('^').ToList();
                if (serviceType.Count >= 4)
                {
                    var typeOfServ = serviceType[3].Split('*');
                    if (typeOfServ.Length >= 4)
                    {
                        AirService = typeOfServ[0] == "Y" ? true : false;
                        HtlService = typeOfServ[1] == "Y" ? true : false;
                        CarService = typeOfServ[2] == "Y" ? true : false;
                        ServDesc = typeOfServ[3].Replace('¨', ' ');
                    }
                }
            }
            else
            {
                IsValid = false;
            }
        }



        /// <summary>
        /// Gets the full protected card.
        /// </summary>
        public string FullProtectedCard
        {//proteger tarjeta
            get
            {

                var stringType = "";
                if (Type == InterJetProfileCrediCardType.AmericanExpress)
                {
                    stringType = "AX";
                }
                if (Type == InterJetProfileCrediCardType.UniversalTravelPlan)
                {
                    stringType = "TP";
                }
                if (Type == InterJetProfileCrediCardType.Visa)
                {
                    stringType = "VI";
                }
                if (Type == InterJetProfileCrediCardType.MasterCard)
                {
                    stringType = "CA";
                }
                return string.Format("{0}-{1}", stringType, this.CreditCardNumberProtected);
            }
        }
    }
}
