using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class Documents
    {
        //DocId, Documento, NombreDoc, Extension

        private int docid;
        public int DocID
        {
            get { return docid; }
            set { docid = value; }
        }

        private byte[] content;
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }

        private string filename;
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        private string extension;
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }





    }
}
