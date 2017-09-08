using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;

namespace ADMIN2.DAL
{
    /// <summary>
    /// Conexión a BD configurada en web.config o app.config.
    /// </summary>
    internal class ConnectionManager
    {

        private string _connectionName = string.Empty;
        private string _connectionString = string.Empty;
        private string _providerName = string.Empty;

        internal ConnectionManager()
        {
            _connectionName = Configuration.DefaultConnection;
            _connectionString = Configuration.ConnectionString;
            _providerName = Configuration.ProviderName;
        }


        internal ConnectionManager(string connectionName)
        {
            _connectionName = connectionName;
            _connectionString = Configuration.GetConnectionString(connectionName);
            _providerName = Configuration.GetProviderName(connectionName);            
        }

        internal ConnectionManager(string connectionString, int op)
        {
            _connectionString = connectionString;
            _providerName = "System.Data.SqlClient";
        }
        //internal ConnectionManager(string connectionName)
        //{
        //    _connectionName = connectionName;
        //    _connectionString = Configuration.GetProviderName(connectionName);
        //    _providerName = Configuration.GetProviderName(connectionName);
        //}

        internal ConnectionManager(string connectionString, string providerName)
        {
            _connectionString = connectionString;
            _providerName = providerName;
            _connectionName = string.Empty;
        }

        internal string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        internal string ProviderName
        {
            get
            {
                return _providerName;
            }
        }


        /// <summary>
        /// Establece la conexión a la BD solicitada
        /// </summary>
        /// <returns>Conexión a la BD</returns>
        internal IDbConnection GetConnection()
        {
            string typeName = AssemblyProvider.GetInstance(_providerName).GetConnectionType();
            IDbConnection connection = (IDbConnection)AssemblyProvider.GetInstance(_providerName).DBProviderAssembly.CreateInstance(typeName);
            connection.ConnectionString = _connectionString;

            try
            {
                connection.Open();
            }
            catch (Exception err)
            {
                throw err;
            }

            return connection;
        }      

       
    }
}
