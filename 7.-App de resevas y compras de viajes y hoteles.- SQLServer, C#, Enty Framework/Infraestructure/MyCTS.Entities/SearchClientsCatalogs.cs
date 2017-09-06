using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
   public class SearchClientsCatalogs
    {
        private string attribute1;
        public string Attribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }

        private string remarklabelid;
        public string RemarkLabelID
        {
            get { return remarklabelid; }
            set { remarklabelid = value; }
        }

        private string valuetosearch;
        public string ValueToSearch
        {
            get { return valuetosearch; }
            set { valuetosearch = value; }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; }
        }

    }
}
