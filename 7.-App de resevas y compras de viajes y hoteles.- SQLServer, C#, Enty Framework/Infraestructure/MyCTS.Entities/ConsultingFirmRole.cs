using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ConsultingFirmRole
    {
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string rolename;
        public string RoleName
        {
            get { return rolename; }
            set { rolename = value; }
        }

    }
}
