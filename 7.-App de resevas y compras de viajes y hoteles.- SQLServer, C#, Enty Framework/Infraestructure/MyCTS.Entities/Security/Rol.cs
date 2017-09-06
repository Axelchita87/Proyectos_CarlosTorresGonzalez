using System;
using System.Text;
using System.Collections.Generic;

namespace MyCTS.Entities
{

    /// <summary>	
    /// Data Transfer Object Rol
    /// </summary>	
    /// <param name="Dto"></param>	
    [Serializable]
    public class Rol
    {

        // Atributos
        private Guid _applicationid;
        private Guid _roleid;
        private String _rolename;
        private String _loweredrolename;
        private String _description;

        public Rol()
        {
        }

        public Rol(Guid _applicationid, Guid _roleid, String _rolename, String _loweredrolename, String _description)
        {
            this._applicationid = _applicationid;
            this._roleid = _roleid;
            this._rolename = _rolename;
            this._loweredrolename = _loweredrolename;
            this._description = _description;
        }

        // Metodos
        public Guid ApplicationId
        {
            get { return _applicationid; }
            set { _applicationid = value; }
        }

        public Guid RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        public String RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }

        public String LoweredRoleName
        {
            get { return _loweredrolename; }
            set { _loweredrolename = value; }
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
            buff += this._applicationid + "|";
            buff += this._roleid + "|";
            buff += this._rolename + "|";
            buff += this._loweredrolename + "|";
            buff += this._description + "|";
            return buff;
        }
    }
}