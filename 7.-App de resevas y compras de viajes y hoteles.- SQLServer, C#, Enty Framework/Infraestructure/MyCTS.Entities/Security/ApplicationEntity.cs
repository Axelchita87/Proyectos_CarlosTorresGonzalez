using System;
using System.Text;
using System.Collections.Generic;

namespace MyCTS.Entities
{

    /// <summary>	
    /// Data Transfer Object Application
    /// </summary>	
    /// <param name="Dto"></param>	
    [Serializable]
    public class ApplicationEntity
    {

        // Atributos
        private String _applicationname;
        private String _loweredapplicationname;
        private Guid _applicationid;
        private String _description;

        public ApplicationEntity()
        {
        }

        public ApplicationEntity(String _applicationname, String _loweredapplicationname, Guid _applicationid, String _description)
        {
            this._applicationname = _applicationname;
            this._loweredapplicationname = _loweredapplicationname;
            this._applicationid = _applicationid;
            this._description = _description;
        }

        // Metodos
        public String ApplicationName
        {
            get { return _applicationname; }
            set { _applicationname = value; }
        }

        public String LoweredApplicationName
        {
            get { return _loweredapplicationname; }
            set { _loweredapplicationname = value; }
        }

        public Guid ApplicationId
        {
            get { return _applicationid; }
            set { _applicationid = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public override string ToString()
        {
            string buff = "";

            buff += base.ToString();
            buff += this._applicationname + "|";
            buff += this._loweredapplicationname + "|";
            buff += this._applicationid + "|";
            buff += this._description + "|";
            return buff;
        }
    }
}