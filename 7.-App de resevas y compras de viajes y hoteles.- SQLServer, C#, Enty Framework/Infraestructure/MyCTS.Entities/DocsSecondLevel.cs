using System;
using System.Collections.Generic;
using System.Text;


namespace MyCTS.Entities
{
    public class DocsSecondLevel
    {
        private int imageId;
        public int ImageId
        {
            get { return imageId; }
            set { imageId = value; }
        }

        private int profileId;
        public int ProfileId
        {
            get { return profileId; }
            set { profileId = value; }
        }

        private int fieldKey;
        public int FieldKey
        {
            get { return fieldKey; }
            set { fieldKey = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        private DateTime insertDate;
        public DateTime InsertDate
        {
            get { return insertDate; }
            set { insertDate = value; }
        }

        private DateTime updateDate;
        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }

        private DateTime deleteDate;
        public DateTime  DeleteDate
        {
            get { return deleteDate; }
            set { deleteDate = value; }
        }

        private bool enable;
        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }
        private string nameDocument;
        public string NameDocument
        {
            get { return nameDocument; }
            set { nameDocument = value; }
        }
    }
}
