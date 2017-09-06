using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisContact
    {
        public VolarisContact()
        {
            Emails = new VolarisContactEmails();
            Phones = new VolarisContactTelephones();
        }
        public VolarisContactEmails Emails { get; set; }
        public VolarisContactTelephones Phones { get; set; }
    }
}
