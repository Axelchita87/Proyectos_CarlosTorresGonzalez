using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class UserSelectByPCC
    {
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
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

        private string queue;
        public string Queue
        {
            get { return queue; }
            set { queue = value; }
        }

        private string ta;
        public string TA
        {
            get { return ta; }
            set { ta = value; }
        }

        private string usermail;
        public string UserMail
        {
            get { return usermail; }
            set { usermail = value; }
        }

        private string userid;
        public string UserId
        {
            get { return userid; }
            set { userid = value; }
        }
    }
}
