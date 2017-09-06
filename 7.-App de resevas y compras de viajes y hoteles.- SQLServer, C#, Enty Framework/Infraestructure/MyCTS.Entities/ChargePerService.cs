using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ChargePerService
    {
        private string strtosearch;
        public string StrToSearch
        {
            get{return strtosearch;}
            set{strtosearch=value;}
        }


        private string idpaymentform;
        public string IDPaymentForm
        {
            get { return idpaymentform; }
            set { idpaymentform = value; }
        }


        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private string import;
        public string Import
        {
            get { return import; }
            set { import = value; }
        }

    }
}
