using System;
using System.Text;
using System.Collections.Generic;

namespace MyCTS.Entities
{

    /// <summary>	
    /// Data Transfer Object User
    /// </summary>	
    /// <param name="Dto"></param>	
    [Serializable]
    public class User
    {

        // Atributos
        private Guid _applicationid;
        private Guid _userid;
        private String _username;
        private String _loweredusername;
        private String _usermail;
        private DateTime _lastactivitydate;
        private String _firm;
        private String _password;
        private String _familyname;
        private String _agent;
        private String _agentmail;
        private String _statusfirm;
        private String _queue;
        private String _pcc;
        private String _ta;
        private String _agentFirm;
        private bool _isMySabreBlocked;
        private bool _installFramework35;
        private bool _isFramework35Installed;
        private string _profileallaccess;
        private string _applicationname;
        private int _orgid;
        private int _upgradestatus;

        public User()
        {
        }

        public User(Guid _applicationid, Guid _userid, String _username, String _loweredusername, String _usermail, String agentMail, String statusFirm, DateTime _lastactivitydate, String _firm, String _password, String _familyname, String _agent, String _queue, String _pcc, String _ta, String _agentFirm)
        {
            this._applicationid = _applicationid;
            this._userid = _userid;
            this._username = _username;
            this._loweredusername = _loweredusername;
            this._usermail = _usermail;
            this._agentmail = _agentmail;
            this._statusfirm = _statusfirm;
            this._lastactivitydate = _lastactivitydate;
            this._firm = _firm;
            this._password = _password;
            this._familyname = _familyname;
            this._agent = _agent;
            this._queue = _queue;
            this._pcc = _pcc;
            this._ta = _ta;
            this._agentFirm = _agentFirm;
        }

        // Metodos
        public Guid ApplicationId
        {
            get { return _applicationid; }
            set { _applicationid = value; }
        }

        public Guid UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public String UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public String LoweredUserName
        {
            get { return _loweredusername; }
            set { _loweredusername = value; }
        }

        public String UserMail
        {
            get { return _usermail; }
            set { _usermail = value; }
        }

        public String AgentMail
        {
            get { return _agentmail; }
            set { _agentmail = value; }
        }

        public String StatusFirm
        {
            get { return _statusfirm; }
            set { _statusfirm = value; }
        }


        public DateTime LastActivityDate
        {
            get { return _lastactivitydate; }
            set { _lastactivitydate = value; }
        }

        public String Firm
        {
            get { return _firm; }
            set { _firm = value; }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public String FamilyName
        {
            get { return _familyname; }
            set { _familyname = value; }
        }

        public String Agent
        {
            get { return _agent; }
            set { _agent = value; }
        }

        public String Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        public String PCC
        {
            get { return _pcc; }
            set { _pcc = value; }
        }

        public String TA
        {
            get { return _ta; }
            set { _ta = value; }
        }

        public bool IsMySabreBlocked
        {
            get { return _isMySabreBlocked; }
            set { _isMySabreBlocked = value; }

        }

        public bool InstallFramework35
        {
            get { return _installFramework35; }
            set { _installFramework35 = value; }
        }

        public bool IsFramework35Installed
        {
            get { return _isFramework35Installed; }
            set { _isFramework35Installed = value; }
        }

        private Profile profileuser;
        public Profile ProfileUser
        {
            get { return profileuser; }
            set { profileuser = value; }

        }

        private string profileallaccess;
        public string ProfileAllAccess
        {
            get { return profileallaccess; }
            set { profileallaccess = value; }

        }

        public string ApplicationName
        {
            get { return _applicationname; }
            set { _applicationname = value; }
        }

        public int OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int UpgradeStatus
        {
            get { return _upgradestatus; }
            set { _upgradestatus = value; }
        }

        public bool Supervisor { get; set; }

        public override string ToString()
        {
            string buff = "";

            buff += base.ToString();
            buff += this._applicationid + "|";
            buff += this._userid + "|";
            buff += this._username + "|";
            buff += this._loweredusername + "|";
            buff += this._usermail + "|";
            buff += this._lastactivitydate + "|";
            buff += this._firm + "|";
            buff += this._password + "|";
            buff += this._familyname + "|";
            buff += this._agent + "|";
            buff += this._queue + "|";
            buff += this._pcc + "|";
            buff += this._ta + "|";
            //buff += this._agentFirm + "|";
            return buff;
        }
    }
}
