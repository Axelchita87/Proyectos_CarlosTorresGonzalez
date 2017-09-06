using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CatConfirmDK
    {
        private string dktosearch;
        public string DKToSearch
        {
            get { return dktosearch; }
            set { dktosearch = value; }
        }

        private string iddk;
        public string IDDK
        {
            get { return iddk; }
            set { iddk = value; }
        }

        private string dkname;
        public string DKName
        {
            get { return dkname; }
            set { dkname = value; }
        }
    }
}
