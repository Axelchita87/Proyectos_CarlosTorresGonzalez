using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ADMIN2.DAL
{
    internal static class Configuration
    {
        const string DEFAULT_CONNECTION_KEY = "defaultConnection";


        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.AppSettings[DEFAULT_CONNECTION_KEY];
            }
        }

        public static string ConnectionName
        {
            get;
            set;
        }

        public static string ProviderName
        {
            get
            {
              return ConnectionName == null ?
                        ConfigurationManager.ConnectionStrings[DefaultConnection].ProviderName :
                        ConfigurationManager.ConnectionStrings[ConnectionName].ProviderName;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ConnectionString;
            }
        }

        public static string GetConnectionString(string connectionName)
        {
            if (connectionName == "conxDia")
            {
                //return DALDIA.decriptD("08081001", ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
                return "";
            }
            else
            {
                return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            }
        }

        public static string GetProviderName(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

    }
}
