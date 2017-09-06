using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatAllStars
    {
        private string pccid;
        public string PccId
        {
            get { return pccid; }
            set { pccid = value; }
        }

        private string starname;
        public string StarName
        {
            get { return starname; }
            set { starname = value; }
        }

        private string level;
        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        private string star1ref;
        public string Star1Ref
        {
            get { return star1ref; }
            set { star1ref = value; }
        }

        private bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        private bool isNew;
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string dk;
        public string DK
        {
            get { return dk; }
            set { dk = value; }
        }

        /// <summary>
        /// Obtiene StartName y PCCID
        /// </summary>
        public override string ToString()
        {
            return string.Concat(starname, " ", pccid);
        }
    }
}
