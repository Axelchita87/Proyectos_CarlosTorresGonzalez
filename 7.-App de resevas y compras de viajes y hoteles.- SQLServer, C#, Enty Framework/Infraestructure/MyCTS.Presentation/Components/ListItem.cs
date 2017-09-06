using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Presentation.Components
{
    public class ListItem2
    {

        private string m_text;
        public string Text
        {
            get { return m_text; }
            set { m_text = value; }
        }

        private string m_value;
        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public ListItem2() { }
        public ListItem2(string text, string value)
        {
            this.m_text = text;
            this.m_value = value;
        }

    }
}
