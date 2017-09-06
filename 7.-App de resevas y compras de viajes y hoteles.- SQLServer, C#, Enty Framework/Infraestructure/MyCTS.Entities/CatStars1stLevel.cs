using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatStars1stLevel
    {
        private string pccid;
        public string Pccid
        {
            get { return pccid; }
            set { pccid = value; }
        }

        private string star1name;
        public string Star1Name
        {
            get { return star1name; }
            set { star1name = value; }
        }


        private bool starl2exist;
        public bool StarL2Exist
        {
            get { return starl2exist; }
            set { starl2exist = value; }
        }
    }
}
