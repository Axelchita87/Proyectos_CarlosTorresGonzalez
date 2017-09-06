using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ListItem
    {

        private string m_text;
        public string Text
        {
            get { return m_text; }
            set { m_text = value; }
        }

        private string m_text2;
        public string Text2
        {
            get { return m_text2; }
            set { m_text2 = value; }
        }

        private string m_text3;
        public string Text3
        {
            get { return m_text3; }
            set { m_text3 = value; }
        }

        private string m_text4;
        public string Text4
        {
            get { return m_text4; }
            set { m_text4 = value; }
        }

        private string m_text5;
        public string Text5
        {
            get { return m_text5; }
            set { m_text5 = value; }
        }

        private string m_text6;
        public string Text6
        {
            get { return m_text6; }
            set { m_text6 = value; }
        }

        private string m_text7;
        public string Text7
        {
            get { return m_text7; }
            set { m_text7 = value; }
        }


        private string m_text8;
        public string Text8
        {
            get { return m_text8; }
            set { m_text8 = value; }
        }



        private string m_value;
        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public ListItem() { }
        public ListItem(string text, string value)
        {
            this.m_text = text;
            this.m_value = value;
        }

        public ListItem(string text, string text2, string value)
        {
            this.m_text = text;
            this.m_text2 = text2;
            this.m_value = value;
        }

        public ListItem(string text, string text2, string text3, string value)
        {
            this.m_text = text;
            this.m_text2 = text2;
            this.m_text3 = text3;
            this.m_value = value;
        }

        public ListItem(string text, string text2, string text3, string text4, string text5 , string text6 , string text7, string text8 ,string value)
        {
            this.m_text = text;
            this.m_text2 = text2;
            this.m_text3 = text3;
            this.m_text4 = text4;
            this.m_text5 = text5;
            this.m_text6 = text6;
            this.m_text7 = text7;
            this.m_text8 = text8;
            this.m_value = value;
        }

    }

    
}
