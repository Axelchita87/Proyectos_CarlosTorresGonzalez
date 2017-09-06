using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ConsultingFirm
    {
        private string firm;
        public string Firm
        {
            get { return firm; }
            set { firm = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string familyname;
        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string usermail;
        public string UserMail
        {
            get { return usermail; }
            set { usermail = value; }
        }

        private string agent;
        public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }


        private string agentmail;
        public string AgentMail
        {
            get { return agentmail; }
            set { agentmail = value; }
        }

        private string queue;
        public string Queue
        {
            get { return queue; }
            set { queue = value; }
        }

        private string pcc;
        public string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }

        private string ta;
        public string TA
        {
            get { return ta; }
            set { ta = value; }
        }

        private string statusfirm;
        public string StatusFirm
        {
            get { return statusfirm; }
            set { statusfirm = value; }
        }

        private string myctsversion;
        public string MyCTSVersion
        {
            get { return myctsversion; }
            set { myctsversion = value; }
        }

        private bool ismysabreblocked;
        public bool IsMySabreBlocked
        {
            get { return ismysabreblocked; }
            set { ismysabreblocked = value; }
        }
    }
}
