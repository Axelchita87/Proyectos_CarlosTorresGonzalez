using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class BannerImage
    {
        private byte[] content;
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string extension;
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string activate;
        public string Activate
        {
            get { return activate; }
            set { activate = value; }
        }
    }
}
