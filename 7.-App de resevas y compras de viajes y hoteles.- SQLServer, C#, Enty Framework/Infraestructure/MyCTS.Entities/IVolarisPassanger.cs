using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class IVolarisPassanger : IPassanger
    {
        public IVolarisPassanger()
        {
            SpecialServices = new VolarisPassangerSpecialServices();

        }


        public string eTicket { get; set; }

        private string _nameInTicket;
        public string NameInTicket
        {
            get
            {


                if (!string.IsNullOrEmpty(_nameInTicket))
                {
                    return _nameInTicket;
                }
                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(LastName))
                {
                    string nameInTicket = Name.Substring(0, 1);

                    string lastNameInTicket;
                    if (LastName.Length < 5)
                    {
                        lastNameInTicket = LastName;
                    }
                    else
                    {
                        lastNameInTicket = LastName.Substring(0, 5);
                    }

                    _nameInTicket = string.Format("{0}/{1}", lastNameInTicket, nameInTicket).ToUpper();
                    return _nameInTicket;
                }
                return string.Empty;
            }
        }


        private string PassangerWithNumber
        {
            get
            {

                string type = "";
                if (this is VolarisAdultPassanger)
                {
                    type = "Adulto";
                }
                if (this is VolarisChildPassanger)
                {
                    type = "Menor";
                }
                if (this is VolarisInfantPassanger)
                {
                    type = "Infante";
                }
                return string.Format("{0} {1}", type, Number);
            }
        }
        public virtual string NameInRecord
        {
            get { return string.Format("-{0}/{1}", LastName, Name); }
        }



        private readonly Dictionary<VolarisPassangerGenderType, string> _gendetDictionaryConverter = new Dictionary
            <VolarisPassangerGenderType, string>()
                                                                                                {
                                                                                                    { VolarisPassangerGenderType.Hombre, "M"},
                                                                                                    {VolarisPassangerGenderType.Mujer, "F"}
                                                                                                };
        public virtual string SecureFlightCommand
        {
            get
            {
                var dateOfBirth = this.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US"));

                const string template = "DB/{0}/{1}/{2}/{3}";

                return string.Format(template, dateOfBirth.ToUpper(), _gendetDictionaryConverter[Gender], LastName, Name);
            }
        }


        public virtual string SecureFlightCommandForHost
        {
            get { return string.Format("3DOCSA/{0}-{1}.1", SecureFlightCommand, ID); }
        }

        public VolarisPassangerGenderType Gender { get; set; }
        /// Gets or sets the reservation.
        /// 
        /// <value>
        /// The reservation.
        /// </value>
        public VolarisReservation Reservation { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public VolarisPassangerTitleType Title { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the special service.
        /// </summary>
        /// <value>
        /// The special service.
        /// </value>
        public VolarisPassangerSpecialServices SpecialServices { get; set; }


        private string _fullName;
        public string FullName
        {
            get
            {
                _fullName = string.Format("{0} {1} {2}", Title, Name, LastName);
                return _fullName;
            }
            set { _fullName = value; }
        }

        public string Autorizacion { get; set; }
       
        public string Operacion { get; set; }
       
        public bool IsNotAPassanger { get; set; }

        public override string ToString()
        {

            if (IsNotAPassanger)
            {
                ID = "-1";
                return "Todos los pasajeros";
            }

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(LastName))
            {
                return FullName;
            }

            return PassangerWithNumber;
        }

        public bool HasValue
        {
            get
            {
                return !string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(LastName);
            }
        }


        #region Miembros de IPassanger


        /// <summary>
        /// TODO: Verificar que se tenga el numero de pasajero setteado.
        /// </summary>

        public string ID
        {
            get { return Number.ToString(CultureInfo.InvariantCulture); }
            set
            {

            }
        }

        public string PassangerStringType
        {
            get { return GetPassangerType(this); }
        }

        public string PassangeTypeInRecord
        {
            get
            {

                if (!string.IsNullOrEmpty(PassangerStringType) && !string.IsNullOrEmpty(ID))
                {
                    return string.Format("PDT{0}-{1}.1", PassangerStringType, ID);
                }
                return string.Empty;
            }
        }

        public string PassangerNameInAccountingLine
        {

            get
            {

                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(LastName))
                {
                    return string.Format("{0}.1{1} {2}", ID, LastName, Name[0]);

                }
                return string.Empty;
            }
        }

        private string GetPassangerType(IVolarisPassanger pax)
        {

            if (pax != null)
            {
                if (pax is VolarisAdultPassanger)
                {
                    return "ADT";
                }

                if (pax is VolarisChildPassanger)
                {
                    return "CNN";
                }

                if (pax is VolarisInfantPassanger)
                {
                    return "INF";
                }
            }
            return string.Empty;
        }

        #endregion

    }
}
