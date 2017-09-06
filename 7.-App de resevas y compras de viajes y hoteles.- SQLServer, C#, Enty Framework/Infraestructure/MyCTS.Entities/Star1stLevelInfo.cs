using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class Star1stLevelInfo
    {
        public String Id { get; set; }
        private string pccid;
        public string Pccid
        {
            get { return pccid; }
            set { pccid = value; }
        }

        private string level1;
        public string Level1
        {
            get { return level1; }
            set { level1 = value; }
        }

        private int line;
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private bool purged;
        public bool Purged
        {
            get { return purged; }
            set { purged = value; }
        }
    }
}
