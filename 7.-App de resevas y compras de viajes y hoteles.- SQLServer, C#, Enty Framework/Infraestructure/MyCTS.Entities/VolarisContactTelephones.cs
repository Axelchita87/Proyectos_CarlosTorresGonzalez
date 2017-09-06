using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisContactTelephones
    {

        public VolarisContactTelephones()
        {
            _telephones = new List<VolarisContactTelephone>();
        }

        public void Add(List<VolarisContactTelephone> telephones)
        {
            if (telephones != null && telephones.Any())
            {
                _telephones.AddRange(telephones);
            }
        }
        public void Add(VolarisContactTelephone telephone)
        {
            Add(new List<VolarisContactTelephone>() { telephone });
        }

        public List<VolarisContactTelephone> GetAll()
        {
            return _telephones;
        }

        private readonly List<VolarisContactTelephone> _telephones;

    }
}
