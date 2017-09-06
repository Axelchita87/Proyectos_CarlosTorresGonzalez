using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetMailByUser
    {
        private string usermail;
        public string UserMail
        {
            get { return usermail; }
            set { usermail = value; }
        }

        private string familyname;
        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value; }
        }
    }
}
