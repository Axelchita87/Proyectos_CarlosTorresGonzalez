using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetPassangerInfant : InterJetPassanger
    {

        public InterJetPassangerInfant()
        {
            Title = "Menor";
        }

        public InterJetPassanger Adult
        {
            get;
            set;
        }


        public override string PassangerNameInRecord
        {
            get
            {
                return string.Format("-I/{0}/{1}", LastName, Name);
            }
        }

        public string SsrCommand
        {
            get
            {
                if (AssignedPassanger != null)
                {
                    return string.Format("3INFT/{0}-{1}.1", SsrCommand, AssignedPassanger.ID);
                }
                return "";
            }
        }

        public override string SecureFlightCommand
        {
            get
            {
                var dateOfBirth = this.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US"));

                const string template = "DB/{0}/{1}/{2}/{3}";

                return string.Format(template, dateOfBirth.ToUpper(), this.Sex, LastName, Name);
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

        private string _randomId;

        public string Sex
        {
            get;
            set;
        }



        public string Country
        {
            set;
            get;
        }

        public InterJetPassanger AssignedPassanger
        {
            get;
            set;
        }


    }
}
