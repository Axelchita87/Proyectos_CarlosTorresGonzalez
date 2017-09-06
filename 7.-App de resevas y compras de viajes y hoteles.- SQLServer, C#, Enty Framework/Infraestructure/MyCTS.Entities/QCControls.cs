using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
   public class QCControls
    {
        private string qcid;
        public string QCId
        {
            get { return qcid; }
            set { qcid = value; }
        }

        private string acvalue;
        public string QCValue
        {
            get { return acvalue; }
            set { acvalue = value; }
        }

        private string qcdescription;
        public string QCDescription
        {
            get { return qcdescription; }
            set { qcdescription = value; }
        }

        private string ctrltype;
        public string CtrlType
        {
            get { return ctrltype; }
            set { ctrltype = value; }
        }

        private string ctrlname;
        public string CtrlName
        {
            get { return ctrlname; }
            set { ctrlname = value; }
        }

        private string ctrldescription;
        public string CtrlDescription
        {
            get { return ctrldescription; }
            set { ctrldescription = value; }
        }

        private int ctrllen;
        public int CtrlLen
        {
            get { return ctrllen; }
            set { ctrllen = value; }
        }

        private string ctrlcurrentcriteria;
        public string CtrlCurrentCriteria
        {
            get { return ctrlcurrentcriteria; }
            set { ctrlcurrentcriteria = value; }
        }

        private string ctrlcatalogues;
        public string CtrlCatalogues
        {
            get { return ctrlcatalogues; }
            set { ctrlcatalogues = value; }
        }

        private bool allowinsertvalues;
        public bool AllowInsertvalues
        {
            get { return allowinsertvalues; }
            set { allowinsertvalues = value; }
        }


    }
}
