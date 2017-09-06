using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisInfantPassanger : IVolarisPassanger
    {
        public VolarisAdultPassanger AssignedPassanger { get; set; }

        public string SSRCommand
        {
            get
            {
                var dateOfBirth = DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US"));
                return string.Format("{0}/{1}/{2}", LastName, Name, dateOfBirth.ToUpper());
            }
        }

        public string SSRCommandForHost
        {
            get
            {
                if (AssignedPassanger != null)
                {
                    return string.Format("3INFT/{0}-{1}.1", SSRCommand, AssignedPassanger.ID);
                }
                return "";
            }
        }

        private readonly Dictionary<VolarisPassangerGenderType, string> _gendetDictionaryConverter = new Dictionary
    <VolarisPassangerGenderType, string>()
                                                                                                {
                                                                                                    { VolarisPassangerGenderType.Hombre, "MI"},
                                                                                                    {VolarisPassangerGenderType.Mujer, "FI"}
                                                                                                };
        public override string SecureFlightCommand
        {
            get
            {
                var dateOfBirth = this.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US"));

                const string template = "DB/{0}/{1}/{2}/{3}";

                return string.Format(template, dateOfBirth.ToUpper(), _gendetDictionaryConverter[Gender], LastName, Name);
            }
        }
        public override string SecureFlightCommandForHost
        {
            get
            {
                if (AssignedPassanger != null)
                {
                    return string.Format("3DOCSA/{0}-{1}.1", SecureFlightCommand, AssignedPassanger.ID);
                }
                return "";
            }
        }
        public override string NameInRecord
        {
            get { return string.Format("-I/{0}/{1}", LastName, Name); }
        }

    }
}
