using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetContact :InterJetPassanger
    {

        public string Address
        {
            get
            {

                return string.Format("{0} {1} {2}", this.Address1, this.Address2, this.Address3);
            }
        }

        public string Address1
        {
            get;
            set;
        }

        public string Address2
        {
            get;
            set;
        }
        public string Address3
        {
            get;
            set;
        }

        public string PrimaryTelephone
        {
            get;
            set;
        }

        public string AlternTelephone
        {
            get;
            set;
        }

        public string CellPhone
        {
            get;
            set;
        }
        public string Fax
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            set;
            get;
        }

        public string Email
        {
            set;
            get;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }




    }
}
