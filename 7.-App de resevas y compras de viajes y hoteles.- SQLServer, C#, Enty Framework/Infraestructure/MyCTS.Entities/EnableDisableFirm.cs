using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class EnableDisableFirm
    {
        private string firm;
        public string Firm
        {
            get { return firm; }
            set { firm = value; }
        }

        private int active;
        public int Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
