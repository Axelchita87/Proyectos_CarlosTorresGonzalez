using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
   public  class CatCarTypeCodes
    {
        private string strtosearch;
        public string StrToSearch
        {
            get { return strtosearch; }
            set { strtosearch = value; }
        }


        private string catcartypcodcode;
        public string CatCarTypCodCode
        {
            get { return catcartypcodcode; }
            set { catcartypcodcode = value; }
        }

        private string catcartypcoddescription;
        public string CatCarTypCodDescription
        {
            get { return catcartypcoddescription; }
            set { catcartypcoddescription = value; }
        }
    }
}
