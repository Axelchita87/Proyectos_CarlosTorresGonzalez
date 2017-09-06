using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatStars2ndLevel
    {
        private string pccid;
        public string Pccid
        {
            get { return pccid; }
            set { pccid = value; }
        }

        private string star1id;
        public string Star1id
        {
            get { return star1id; }
            set { star1id = value; }
        }

        private string star2name;
        public string Star2Name
        {
            get { return star2name; }
            set { star2name = value; }
        }
    }
}
