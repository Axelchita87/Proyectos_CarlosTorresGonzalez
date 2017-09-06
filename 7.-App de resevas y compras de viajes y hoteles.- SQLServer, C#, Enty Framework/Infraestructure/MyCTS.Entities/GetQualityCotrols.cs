using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GetQualityCotrols
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string iDCtrl;
        public string IDCtrl
        {
            get { return iDCtrl; }
            set { iDCtrl = value; }
        }

        private string ctrlType;
        public string CtrlType
        {
            get { return ctrlType; }
            set { ctrlType = value; }
        }

        private string ctrlDescription;
        public string CtrlDescription
        {
            get { return ctrlDescription; }
            set { ctrlDescription = value; }
        }

        private int ctrlLen;
        public int CtrlLen
        {
            get { return ctrlLen; }
            set { ctrlLen = value; }
        }

        private string ctrlCurrentCriteria;
        public string CtrlCurrentCriteria
        {
            get { return ctrlCurrentCriteria; }
            set { ctrlCurrentCriteria = value; }
        }

        private string ctrlCatalogues;
        public string CtrlCatalogues
        {
            get { return ctrlCatalogues; }
            set { ctrlCatalogues = value; }
        }

        private bool allowInsertValues;
        public bool AllowInsertValues
        {
            get { return allowInsertValues; }
            set { allowInsertValues = value; }
        }
    }
}
