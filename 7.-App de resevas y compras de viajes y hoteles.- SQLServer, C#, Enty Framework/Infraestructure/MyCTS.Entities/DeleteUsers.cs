using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class DeleteUsers
    {
        private string firm;
        public string Firm
        {
            get { return firm; }
            set { firm = value; }
        }

        private string pcc;
        public string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }
    }
}
