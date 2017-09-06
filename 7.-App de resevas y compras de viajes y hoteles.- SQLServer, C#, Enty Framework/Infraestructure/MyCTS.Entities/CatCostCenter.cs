using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatCostCenter
    {
        private string dktosearch;
        public string DKToSearch
        {
            get { return dktosearch; }
            set { dktosearch = value; }
        }

        private string strtosearch;
        public string StrToSearch
        {
            get { return strtosearch; }
            set { strtosearch = value; }
        }


        private string idcc;
        public string IDCC
        {
            get { return idcc; }
            set { idcc = value; }
        }
        

        private string ccname;
        public string CCName
        {
            get { return ccname; }
            set { ccname = value; }
        }
    }
}
