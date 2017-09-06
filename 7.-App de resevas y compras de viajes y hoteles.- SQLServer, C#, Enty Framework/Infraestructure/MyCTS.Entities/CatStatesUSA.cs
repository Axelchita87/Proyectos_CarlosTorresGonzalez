using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatStatesUSA
    {
        private string catstausacode;
        public string CatStaUSACode
        {
            get { return catstausacode; }
            set { catstausacode = value; }
        }

        private string catstausaname;
        public string CatStaUSAName
        {
            get { return catstausaname; }
            set { catstausaname = value; }
        } 
    }
}
