using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class SetNewFeeRule
    {
        private string attribute1;
        public string Atribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }

        private int priority;
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string extendeddescription;
        public string ExtendedDescription
        {
            get { return extendeddescription; }
            set { extendeddescription = value; }
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

        private bool activationstate;
        public bool ActivationSatate
        {
            get { return activationstate; }
            set { activationstate = value; } 
        }

        private DateTime startdate;
        public DateTime StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        private DateTime expirationdate;
        public DateTime ExpirationDate
        {
            get { return expirationdate; }
            set { expirationdate = value; }
        }

        private string createdbyagent;
        public string CreatedByAgent
        {
            get { return createdbyagent; }
            set { createdbyagent = value; }
        }

        private int idrulenumber;
        public int IDRuleNumber
        {
            get { return idrulenumber; }
            set { idrulenumber = value; }
        }

    }
}
