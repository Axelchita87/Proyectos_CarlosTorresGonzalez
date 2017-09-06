using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatHotels
    {
        private string strtosearch;
        public string StrToSearch
        {
            get { return strtosearch; }
            set { strtosearch = value; }
        }

        private string cathotcode;
        public string CatHotCode
        {
            get { return cathotcode; }
            set { cathotcode = value; }
        }

        private string cathotnamechain;
        public string CatHotNameChain
        {
            get { return cathotnamechain; }
            set { cathotnamechain = value; }
        }
    }
}
