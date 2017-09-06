using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CurrenciesCountries
    {

        private string catcurcoucode;
        public string CatCurCouCode
        {
            get { return catcurcoucode; }
            set { catcurcoucode = value; }
        }

        private string catcurcouname;
        public string CatCurCouName
        {
            get { return catcurcouname; }
            set { catcurcouname = value; }
        }

        private string catcouname;
        public string CatCouName
        {
            get { return catcouname; }
            set { catcouname = value; }
        }
        private int catcouid;
        public int CatCouId
        {
            get { return catcouid; }
            set { catcouid = value; }
        }

    }
}
