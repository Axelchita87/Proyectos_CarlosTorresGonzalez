using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class LogsApplication
    {
        private int logid;
        public int LogID
        {
            get { return logid; }
            set { logid = value; }
        }

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

        private string usercontrolname;
        public string UserControlName
        {
            get { return usercontrolname; }
            set { usercontrolname = value; }
        }

        private string errordescription;
        public string ErrorDescription
        {
            get { return errordescription; }
            set { errordescription = value; }
        }

        private string stacktrace;
        public string StackTrace
        {
            get { return stacktrace; }
            set { stacktrace = value; }
        }
    }
}
