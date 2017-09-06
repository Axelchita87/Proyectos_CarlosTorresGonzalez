using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class QCExist
    {
        private string qcdescription;
        public string QCDescription
        {
            get { return qcdescription; }
            set { qcdescription = value; }
        }

        private string qclabel;
        public string QCLabel
        {
            get { return qclabel; }
            set { qclabel = value; }
        }

    }
}
