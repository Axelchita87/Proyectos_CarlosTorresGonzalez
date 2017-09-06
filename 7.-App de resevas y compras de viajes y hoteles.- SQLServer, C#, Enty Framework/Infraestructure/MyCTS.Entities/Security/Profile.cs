using System;
using System.Text;
using System.Collections.Generic;

namespace MyCTS.Entities
{

    /// <summary>	
    /// Data Transfer Object Profile
    /// </summary>	
    /// <param name="Dto"></param>	
    [Serializable]
    public class Profile
    {

        // Atributos
        private Guid _userid;
        private String _propertynames;
        private String _propertyvaluesstring;
        private Byte[] _propertyvaluesbinary;
        private DateTime _lastupdateddate;

        public Profile()
        {
        }

        public Profile(Guid _userid, String _propertynames, String _propertyvaluesstring, Byte[] _propertyvaluesbinary, DateTime _lastupdateddate)
        {
            this._userid = _userid;
            this._propertynames = _propertynames;
            this._propertyvaluesstring = _propertyvaluesstring;
            this._propertyvaluesbinary = _propertyvaluesbinary;
            this._lastupdateddate = _lastupdateddate;
        }

        // Metodos
        public Guid UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public String PropertyNames
        {
            get { return _propertynames; }
            set { _propertynames = value; }
        }

        public String PropertyValuesString
        {
            get { return _propertyvaluesstring; }
            set { _propertyvaluesstring = value; }
        }

        public Byte[] PropertyValuesBinary
        {
            get { return _propertyvaluesbinary; }
            set { _propertyvaluesbinary = value; }
        }

        public DateTime LastUpdatedDate
        {
            get { return _lastupdateddate; }
            set { _lastupdateddate = value; }
        }

        public override string ToString()
        {
            string buff = "";

            buff += base.ToString();
            buff += this._userid + "|";
            buff += this._propertynames + "|";
            buff += this._propertyvaluesstring + "|";
            buff += this._propertyvaluesbinary + "|";
            buff += this._lastupdateddate + "|";
            return buff;
        }
    }
}