using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class UsersSelectByPCC
    {
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string firm;
        public string Firm
        {
            get { return firm; }
            set { firm = value; }
        }

        private string familyname;
        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value; }
        }

        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }
    }
}
