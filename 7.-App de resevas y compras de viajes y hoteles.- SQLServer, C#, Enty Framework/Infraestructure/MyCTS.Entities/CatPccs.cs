using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatPccs
    {
        private string strtosearch;
        public string StrToSearch
        {
            get { return strtosearch; }
            set { strtosearch = value; }
        }

        private string catpccid;
        public string CatPccId
        {
            get { return catpccid; }
            set { catpccid = value; }
        }

        private string catpccname;
        public string CatPccName
        {
            get { return catpccname; }
            set { catpccname = value; }
        }
    }
}
