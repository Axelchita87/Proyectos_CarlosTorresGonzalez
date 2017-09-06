using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace MyCTS.Entities
{
    public class CommonENT
    {
        public static string MYCTSDB_CONNECTION
        {
            get { return MyCTSDbConnection(); }
        }
        public static string MYCTSDBSECURITY_CONNECTION
        {
            get { return MyCTSDbSecurityConnection(); }
        }
        public static string MYCTSDBPRODUCTIVITY_CONNECTION
        {
            get { return MyCTSDbProductivityConnection(); }
        }
        public static string MYCTSDBPROFILES_CONNECTION
        {
            get { return MyCTSDbProfilesConnection(); }
        }

        public static string SCDC_Conection
        {
            get { return SCDCConnection(); }
        }

        public const string DATE_FORMAT_DEFAULT = "dd-MM-yyyy";
        public const string DATETIME_FORMAT_DEFAULT = "dd-MM-yyyy HH:mm:ss";

        const string CONST_MYCTSDB_CONNECTION = "MyCTSDb";
        public const string MYCTSDBBACKUP_CONNECTION = "MyCTSDb_Mirror";

        const string CONST_MYCTSDBSECURITY_CONNECTION = "MyCTSSecurityDB";
        public const string MYCTSDBSECURITYBACKUP_CONNECTION = "MyCTSSecurityDB_Mirror";

        const string CONST_MYCTSDBPRODUCTIVITY_CONNECTION = "MyCTSProductivityDB";
        public const string MYCTSDBPRODUCTIVITYBACKUP_CONNECTION = "MyCTSProductivityDB_Mirror";

        const string CONST_MYCTSDBPROFILES_CONNECTION = "MyCTSProfilesDB";
        public const string MYCTSDBPROFILESBACKUP_CONNECTION = "MyCTSProfilesDB_Mirror";

        const string CONST_SCDC_CONNECTION = "SCDC";
        public const string SCDCBACKUP_CONNECTION = "SCDC_Mirror";

        internal static string MyCTSDbConnection()
        {
            return (ConfigurationManager.AppSettings["MirrorOn"] == "Off") ? CONST_MYCTSDB_CONNECTION : MYCTSDBBACKUP_CONNECTION;
        }

        internal static string MyCTSDbSecurityConnection()
        {
            return (ConfigurationManager.AppSettings["MirrorOn"] == "Off") ? CONST_MYCTSDBSECURITY_CONNECTION : MYCTSDBSECURITYBACKUP_CONNECTION;
        }

        internal static string MyCTSDbProductivityConnection()
        {
            return (ConfigurationManager.AppSettings["MirrorOn"] == "Off") ? CONST_MYCTSDBPRODUCTIVITY_CONNECTION : MYCTSDBPRODUCTIVITYBACKUP_CONNECTION;
        }

        internal static string MyCTSDbProfilesConnection()
        {
            return (ConfigurationManager.AppSettings["MirrorOn"] == "Off") ? CONST_MYCTSDBPROFILES_CONNECTION : MYCTSDBPROFILESBACKUP_CONNECTION;
        }

        internal static string SCDCConnection()
        {
            return (ConfigurationManager.AppSettings["MirrorOn"] == "Off") ? CONST_SCDC_CONNECTION : SCDCBACKUP_CONNECTION;
        }
    }
}
