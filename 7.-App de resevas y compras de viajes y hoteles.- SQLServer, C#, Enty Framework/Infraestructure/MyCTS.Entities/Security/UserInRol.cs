using System;
using System.Text;
using System.Collections.Generic;

namespace MyCTS.Entities
{

    /// <summary>	
    /// Data Transfer Object UserInRol
    /// </summary>	
    /// <param name="Dto"></param>	
    [Serializable]
    public class UserInRol
    {

        // Atributos
        private Guid _userid;
        private Guid _roleid;

        public UserInRol()
        {
        }

        public UserInRol(Guid _userid, Guid _roleid)
        {
            this._userid = _userid;
            this._roleid = _roleid;
        }

        // Metodos
        public Guid UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public Guid RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        public override string ToString()
        {
            string buff = "";

            buff += base.ToString();
            buff += this._userid + "|";
            buff += this._roleid + "|";
            return buff;
        }
    }
}