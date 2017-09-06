using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class UpdateUsers
    {
        private string codeagent;
        public string CodeAgent
        {
            get { return codeagent; }
            set { codeagent = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string loweredusername;
        public string LoweredUserName
        {
            get { return loweredusername; }
            set { loweredusername = value; }
        }

    }
}
