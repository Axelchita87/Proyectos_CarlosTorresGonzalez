using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class SabreMessages
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int moduleid;
        public int ModuleID
        {
            get { return moduleid; }
            set { moduleid = value; }
        }

        private string apimessage;
        public string APIMessage
        {
            get { return apimessage; }
            set { apimessage = value; }
        }

        private string usermessage;
        public string UserMessage
        {
            get { return usermessage; }
            set { usermessage = value; }
        }

        private bool showcontrol;
        public bool ShowControl
        {
            get { return showcontrol; }
            set { showcontrol = value; }
        }

        private bool isConditional;
        public bool IsConditional
        {
            get { return isConditional; }
            set { isConditional = value; }
        }


    }
}
