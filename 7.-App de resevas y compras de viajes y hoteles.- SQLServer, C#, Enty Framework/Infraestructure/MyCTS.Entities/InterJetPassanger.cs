using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyCTS.Entities
{
    public class InterJetPassanger : IPassanger
    {
        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._name = value;
                }
                else
                {
                    throw new Exception(string.Format("Por favor introduzca el nombre del pasajero {0}.", this.ID));
                }

            }
        }

        public string Nationality
        {
            get;
            set;

        }

        public bool Departure
        {
            get;
            set;
        }

        public bool Arrival
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the internal ID.
        /// </summary>
        /// <value>
        /// The internal ID.
        /// </value>
        public short InternalID
        {
            get;
            set;

        }
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Title))
                {
                    return string.Format("{0} {1} {2}", this.Title, this.Name, this.LastName);
                }
                else
                {
                    return string.Format("{0} {1}", this.Name, this.LastName);
                }


            }
            set
            {

            }
        }

        public string LastName
        {
            set;
            get;

        }

        public string Suffix
        {
            get;
            set;
        }
        public string ID
        {
            get;
            set;
        }

        public bool IsNotAPassanger
        {
            get;
            set;
        }


        public string Autorizacion
        {
            get;
            set;
        }

        public string Operacion
        {
            get;
            set;
        }

        public string GroupBoxTitle
        {
            get
            {
                return string.Format("{0} {1}", this.ID, this.TypeTitle);
            }

        }

        public string TypeTitle
        {
            get;
            set;
        }


        private string _uniqueID;

        public string UniqueID
        {
            get
            {

                if (string.IsNullOrEmpty(this._uniqueID))
                {
                    if (!VolarisSession.IsVolarisProcess)
                    {
                        this._uniqueID = NumeroBoleto.FligthNumber;
                        return string.Format("7{0}", this._uniqueID);
                    }
                    else
                    {
                        this._uniqueID = VolarisSession.Boleto;
                        return string.Format("7{0}", this._uniqueID);
                    }
                }
                else
                {
                    return string.Format("7{0}", this._uniqueID);
                }
            }
        }

        public string Title
        {
            get;
            set;
        }


        public int TripInfant
        {
            get;
            set;
        }

        public string InterJetClubCode
        {
            get;
            set;
        }

        public string NameAndLastName
        {
            get
            {
                return string.Format("{0} {1}", this.Name, this.LastName);
            }
        }
        public bool CanBeInfantAssigned
        {
            get;
            set;
        }

        public string AccountLineParameter
        {
            get
            {
                return string.Format("{0}{1} {2}", SabrePassangerID, this.LastName, this.Name[0]);
            }

        }

        public bool IsAdult
        {
            get
            {
                return this is InterJetAdultPassanger;

            }
        }

        public bool IsSeniorAdult
        {
            get
            {
                return this is InterJetSeniorAdultPassanger;

            }
        }

        public bool IsChild
        {
            get
            {
                return this is InterJetChildPassanger;

            }
        }

        public bool IsTheContact
        {
            get;
            set;
        }

        public string PassangerType
        {
            get
            {
                if (this is InterJetChildPassanger)
                {
                    return "CNN";
                }
                if (this is InterJetSeniorAdultPassanger || this is InterJetAdultPassanger)
                {
                    return "ADT";
                }

                if (this is InterJetPassangerInfant)
                {
                    return "INF";
                }
                return "";
            }


        }

        public string Gender
        {
            get
            {

                if (this.Title.Equals("MR"))
                {
                    return "M";
                }

                if (this.Title.Equals("MRS") || this.Title.Equals("MS"))
                {
                    return "F";
                }

                if (this.Title.Equals("CHD"))
                {
                    return "M";
                }
                return "";
            }
        }
        public virtual string SecureFlightCommand
        {
            get
            {
                var dateOfBirth = this.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US"));

                const string template = "DB/{0}/{1}/{2}/{3}";

                return string.Format(template, dateOfBirth.ToUpper(), Gender, LastName, Name);
            }
        }


        public virtual string SecureFlightCommandForHost
        {
            get { return string.Format("3DOCSA/{0}-{1}.1", SecureFlightCommand, ID); }
        }

        public string PassangerTypeInRecord
        {
            get { return string.Format("PDT{0}-{1}.1", PassangerType, ID); }

        }

        public virtual string PassangerNameInRecord
        {
            get
            {
                return string.Format("-{0}/{1}", LastName, Name);
            }
        }

        public string SabrePassangerID
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public override string ToString()
        {
            return FullName;
        }

       


    }
}
