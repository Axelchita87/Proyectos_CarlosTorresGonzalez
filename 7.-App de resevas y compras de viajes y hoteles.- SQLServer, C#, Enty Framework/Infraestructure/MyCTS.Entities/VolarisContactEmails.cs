using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisContactEmails
    {
        private readonly List<VolarisContactEmail> _emails;
        public VolarisContactEmails()
        {
            _emails = new List<VolarisContactEmail>();
        }

        public void Add(List<VolarisContactEmail> emails)
        {
            if (emails != null && emails.Any())
            {
                _emails.AddRange(emails);
            }
        }


        public void Add(VolarisContactEmail email)
        {
            Add(new List<VolarisContactEmail>() { email });
        }

        public List<VolarisContactEmail> GetAll()
        {
            return _emails;
        }



    }
}
