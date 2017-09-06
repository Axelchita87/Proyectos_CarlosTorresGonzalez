using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ClientCreditCard
    {
        private string creditcardnumber;
        public string CreditCardNumber
        {
            get { return creditcardnumber; }
            set { creditcardnumber = value; }
        }

        private string client;
        public string Client
        {
            get { return client; }
            set { client = value; }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
