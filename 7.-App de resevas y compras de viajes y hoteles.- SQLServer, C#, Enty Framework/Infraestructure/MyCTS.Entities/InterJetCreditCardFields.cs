using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetCreditCardFields
    {
        public string CreditCardName
        {
            get;
            set;
        }
        public decimal TotalAmount
        {
            get;
            set;
        }

        public string CreditCardNumber
        {
            get;
            set;
        }
        public string SecurityCodeNumber
        {
            get;
            set;
        }
        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public string OwnerName
        {
            get;
            set;
        }

        public string OwnerAddress
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string DK
        {
            get; set;
        }

        public bool IsClient
        {
            get; set;
        
        }

        public bool IsCTS
        {
            get; set; 
        }

        public static string CC
        {
            get; set;
        }

        public static string EmployeeNum
        {
            get; set;
        }
    }
}
