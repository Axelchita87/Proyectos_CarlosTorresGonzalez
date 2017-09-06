using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class Bank
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string bankName;
        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
    }
}
