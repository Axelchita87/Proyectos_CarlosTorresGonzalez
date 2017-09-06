using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InsertFirmRole
    {
        private string firm;
        public string Firm
        {
            get { return firm; }
            set { firm = value; }
        }

        private string pcc;
        public string Pcc
        {
            get { return pcc; }
            set { pcc = value; }
        }

        private string rolename;
        public string RoleName
        {
            get { return rolename; }
            set { rolename = value; }
        }

        private bool exist;
        public bool Exist
        {
            get { return exist; }
            set { exist = value; }
        }
    }
}
