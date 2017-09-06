using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class SabreErrorMsg
    {
        private string sabreerrmsg;
        public string SabreErrMsg
        {
            get { return sabreerrmsg; }
            set { sabreerrmsg = value; }
        }

        private int modulesid;
        public int ModulesId
        {
            get { return modulesid; }
            set { modulesid = value; }
        }

        private string cuserrmsgusermsg;
        public string CusErrMsgUserMsg
        {
            get { return cuserrmsgusermsg; }
            set { cuserrmsgusermsg = value; }
        }

        private string cuserrmsgmodulesrc;
        public string CusErrMsgModuleSrc
        {
            get { return cuserrmsgmodulesrc; }
            set { cuserrmsgmodulesrc = value; }
        }

    }
}
