using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetRemarks
    {

        private readonly List<string> _remarks = new List<string>();

        public void Add(List<string> remarks)
        {

            if (remarks != null && remarks.Any())
            {
                _remarks.AddRange(remarks);
            }
        }

        public void Add(string remark)
        {

            Add(new List<string>() { remark });
        }



        public List<string> GetRemarks()
        {
            return _remarks;
        }

    }
}
