using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisRemarks
    {
        private readonly List<string> _remarks;

        public VolarisRemarks()
        {
            _remarks = new List<string>();
        }

        public void Add(string remark)
        {

            if (!string.IsNullOrEmpty(remark))
            {
                _remarks.Add(remark);
            }

        }
        public void Add(List<string> remarks)
        {

            if (remarks != null &&(remarks.Any()))
            {
                _remarks.AddRange(remarks);
            }

        }

        public List<string> Get()
        {
            return _remarks;
        }




    }
}
