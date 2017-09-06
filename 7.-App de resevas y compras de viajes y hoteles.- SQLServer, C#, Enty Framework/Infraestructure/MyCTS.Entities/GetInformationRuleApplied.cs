using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetInformationRuleApplied
    {
        private int numberrule;
        public int NumberRule
        {
            get { return numberrule; }
            set { numberrule = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private decimal defaultfee;
        public decimal DefaultFee
        {
            get { return defaultfee; }
            set { defaultfee = value; }
        }

        private decimal defaultmount;
        public decimal DefaultMount
        {
            get { return defaultmount; }
            set { defaultmount = value; }
        }

        private bool mandatory;
        public bool Mandatory
        {
            get { return mandatory; }
            set { mandatory = value; }
        }

        private string value2;
        public string Value2
        {
            get { return value2; }
            set { value2 = value; }
        }

        private string target;
        public string Target
        {
            get { return target; }
            set { target = value; }
        }
    }
}
