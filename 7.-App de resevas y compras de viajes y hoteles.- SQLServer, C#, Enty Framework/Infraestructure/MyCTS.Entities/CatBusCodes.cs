using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatBusCodes
    {
        private string strtosearch;
        public string StrToSearch
        {
            get { return strtosearch; }
            set { strtosearch = value; }
        }

        private string catbuscodcode;
        public string CatBusCodCode
        {
            get { return catbuscodcode; }
            set { catbuscodcode = value; }
        }

        private string catbuscodname;
        public string CatBusCodName
        {
            get { return catbuscodname; }
            set { catbuscodname = value; }
        }
    }
}
