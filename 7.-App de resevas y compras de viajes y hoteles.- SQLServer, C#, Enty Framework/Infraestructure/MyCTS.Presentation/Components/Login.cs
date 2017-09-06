using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public class Login
    {
        #region UserSabre
        static private string firm;
        static public string Firm
        {
            get { return firm; }
            set { firm = value; }
        }
        #endregion

        #region PassWordSabre
        static private string password;
        static public string passWord
        {
            get { return password; }
            set { password = value; }

        }
        #endregion

        #region PCC
        static private string pcc;
        static public string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }
        #endregion

        #region TA
        static private string ta;
        static public string TA
        {
            get { return ta; }
            set { ta = value; }
        }
        #endregion

        #region GuidUser
        static private Guid userId;
        static public Guid UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        #endregion

        #region Queue
        static private string queue;
        static public string Queue
        {
            get { return queue; }
            set { queue = value; }
        }
        #endregion

        #region Mail
        static private string mail;
        static public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        #endregion

        #region NombreCompleto
        static private string nombreCompleto;
        static public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }
        #endregion

        #region BannerText
        static private string bannertext;
        static public string BannerText
        {
            get { return bannertext; }
            set { bannertext = value; }
        }
        static private Profile userProfile;
        static public Profile UserProfile
        {
            get { return userProfile; }
            set { userProfile = value; }
        }
        #endregion

        #region IsFirstTime
        static private bool isFirstTime;
        static public bool IsFirstTime
        {
            get { return isFirstTime; }
            set { isFirstTime = value; }
        }
        #endregion

        #region AGENT
        static private string agent;
        static public string Agent
        {
            get { return agent; }
            set { agent = value; }
        }
        #endregion

        #region ByParameters
        static private bool byparameters;
        static public bool ByParameters
        {
            get { return byparameters; }
            set { byparameters = value; }
        }
        #endregion

        #region UpgradeStatus
        static private int upgradestatus;
        static public int UpgradeStatus
        {
            get { return upgradestatus; }
            set { upgradestatus = value; }
        }
        #endregion

        static private string labelconn;
        static public string LabelConn
        {
            get { return labelconn; }
            set { labelconn = value; }
        }

        static private bool _isMySabreBlocked;
        static public bool IsMySabreBlocked
        {
            get { return _isMySabreBlocked; }
            set { _isMySabreBlocked = value; }
        }

        static private bool _isFramework35Installed;
        static public bool IsFramework35Installed
        {
            get { return _isFramework35Installed; }
            set { _isFramework35Installed = value; }
        }

        static private string _profileallaccess;
        static public string ProfileAllAccess
        {
            get { return _profileallaccess; }
            set { _profileallaccess = value; }
        }

        static private string _applicationname;
        static public string ApplicationName
        {
            get { return _applicationname; }
            set { _applicationname = value; }
        }

        static private int _orgid;
        static public int OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        static public bool Supervisor { get; set; }
    }
}
