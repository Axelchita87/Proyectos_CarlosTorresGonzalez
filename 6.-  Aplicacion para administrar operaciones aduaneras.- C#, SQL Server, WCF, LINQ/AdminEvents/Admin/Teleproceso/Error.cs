using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEvents
{
    class Error
    {
        private string _desError;

        public string desError
        {
            get { return _desError; }
            set { _desError = value; }
        }

        private int _error;

        public int error
        {
            get { return _error; }
            set { _error = value; }
        }

        private int _idc;

        public int idc
        {
            get { return _idc; }
            set { _idc = value; }
        }
    }
}
