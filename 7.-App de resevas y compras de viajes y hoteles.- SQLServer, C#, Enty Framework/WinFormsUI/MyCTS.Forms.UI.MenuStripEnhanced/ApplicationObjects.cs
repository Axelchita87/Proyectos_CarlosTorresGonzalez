using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Forms.UI.Entities
{
    public class ApplicationObjects
    {
        //algun cambio
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string eventname;
        public string EventName
        {
            get { return eventname; }
            set { eventname = value; }
        }

        private string roles;
        public string Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        private int parentid;
        public int ParentID
        {
            get { return parentid; }
            set { parentid = value; }
        }

        private string shortcut;
        public string ShortCut
        {
            get { return shortcut; }
            set { shortcut = value; }
        }

        private string imagename;
        public string ImageName
        {
            get { return imagename; }
            set { imagename = value; }
        }

        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }




    }
}
