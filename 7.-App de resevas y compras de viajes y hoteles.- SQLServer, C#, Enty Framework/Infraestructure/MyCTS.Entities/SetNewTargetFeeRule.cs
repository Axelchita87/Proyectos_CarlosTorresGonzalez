using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class SetNewTargetFeeRule
    {
        private int rulenumber;
        public int RuleNumber
        {
            get { return rulenumber; }
            set { rulenumber = value; }
        }

        private int idte;
        public int IDTE
        {
            get { return idte; }
            set { idte = value; }
        }

        private string value2;
        public string Value2
        {
            get { return value2; }
            set { value2 = value; }
        }
    }
}
