using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisContactTelephone
    {

        public VolarisContactTelephone()
        {
            Type = VolarisPhoneType.Any;
        }
        public string TelephoneCityCode { get; set; }
        public string Telephone { get; set; }
        public string FullNumber {get { return string.Format("{0}-{1}", TelephoneCityCode, Telephone); }}

        public VolarisPhoneType Type { get; set; }

    }
}
