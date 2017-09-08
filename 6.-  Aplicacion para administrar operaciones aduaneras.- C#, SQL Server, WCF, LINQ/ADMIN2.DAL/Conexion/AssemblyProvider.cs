using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

namespace ADMIN2.DAL
{
    /// <summary>
    /// Assembly
    /// </summary>
    internal class AssemblyProvider
    {
        private static AssemblyProvider _assemblyProvider = null;

        private AssemblyName _assemblyName = null;
        private Assembly _assembly = null;

        private Hashtable _dbProviders = new Hashtable();
        private Hashtable _dbConnections = new Hashtable();
        private Hashtable _dbCommands = new Hashtable();
        private Hashtable _dbParameters = new Hashtable();
        private Hashtable _dbAdapters = new Hashtable();
        private Hashtable _dbAssemblies = new Hashtable();

        private const string SQL_SERVER_PROVIDER_KEY = "System.Data.SqlClient";
        private const string ORACLE_PROVIDER_KEY = "System.Data.OracleClient";
        private const string MY_SQL_PROVIDER_KEY = "MySql.Data.MySqlClient";
        private const string OLEDB_PROVIDER_KEY = "System.Data.OleDb";
        private const string ODBC_PROVIDER_KEY = "System.Data.Odbc";
        private const string COMPACT35_PROVIDER_KEY = "Microsoft.SqlServerCe.Client.3.5";
        private const string COMPACT4_PROVIDER_KEY = "Microsoft.SqlServerCe.Client.4.0";
        private const string MY_SQL_PROVIDER_KEY2 = "System.Data.MySqlClient";

        private const string SQL_SERVER_PROVIDER_VALUE = "System.Data, version=2.0.0.0, culture=Neutral, PublicKeyToken=b77a5c561934e089";
        private const string ORACLE_PROVIDER_VALUE = "System.Data.OracleClient, version=2.0.0.0, culture=Neutral, PublicKeyToken=b77a5c561934e089";
        private const string MY_SQL_PROVIDER_VALUE = "MySql.Data, version=6.7.4.0, culture=Neutral, PublicKeyToken=c5687fc88969c44d";
        private const string OLEDB_PROVIDER_VALUE = "System.Data, version=2.0.0.0, culture=Neutral, PublicKeyToken=b77a5c561934e089";
        private const string ODBC_PROVIDER_VALUE = "System.Data, version=2.0.0.0, culture=Neutral, PublicKeyToken=b77a5c561934e089";
        private const string COMPACT35_PROVIDER_VALUE = "System.Data.SqlServerCe, version=3.5.1.0, culture=Neutral, PublicKeyToken=89845dcd8080cc91";
        private const string COMPACT4_PROVIDER_VALUE = "System.Data.SqlServerCe, version=4.0.0.0, culture=Neutral, PublicKeyToken=89845dcd8080cc91";


        private const string SQL_SERVER_CONNECTION_TYPE_VALUE = "System.Data.SqlClient.SqlConnection";
        private const string ORACLE_CONNECTION_TYPE_VALUE = "System.Data.OracleClient.OracleConnection";
        private const string MY_SQL_CONNECTION_TYPE_VALUE = "MySql.Data.MySqlClient.MySqlConnection";
        private const string OLEDB_CONNECTION_TYPE_VALUE = "System.Data.OleDb.OleDbConnection";
        private const string ODBC_CONNECTION_TYPE_VALUE = "System.Data.Odbc.OdbcConnection";
        private const string COMPACT_CONNECTION_TYPE_VALUE = "System.Data.SqlServerCe.SqlCeConnection";

        private const string SQL_SERVER_COMMAND_TYPE_VALUE = "System.Data.SqlClient.SqlCommand";
        private const string ORACLE_COMMAND_TYPE_VALUE = "System.Data.OracleClient.OracleCommand";
        private const string MY_SQL_COMMAND_TYPE_VALUE = "MySql.Data.MySqlClient.MySqlCommand";
        private const string OLEDB_COMMAND_TYPE_VALUE = "System.Data.OleDb.OleDbCommand";
        private const string ODBC_COMMAND_TYPE_VALUE = "System.Data.Odbc.OdbcCommand";
        private const string COMPACT_COMMAND_TYPE_VALUE = "System.Data.SqlServerCe.SqlCeCommand";

        private const string SQL_SERVER_PARAMETER_TYPE_VALUE = "System.Data.SqlClient.SqlParameter";
        private const string ORACLE_PARAMETER_TYPE_VALUE = "System.Data.OracleClient.OracleParameter";
        private const string MY_SQL_PARAMETER_TYPE_VALUE = "MySql.Data.MySqlClient.MySqlParameter";
        private const string OLEDB_PARAMETER_TYPE_VALUE = "System.Data.OleDb.OleDbParameter";
        private const string ODBC_PARAMETER_TYPE_VALUE = "System.Data.Odbc.OdbcParameter";
        private const string COMPACT_PARAMETER_TYPE_VALUE = "System.Data.SqlServerCe.SqlCeParameter";

        private const string SQL_SERVER_ADAPTER_TYPE_VALUE = "System.Data.SqlClient.SqlDataAdapter";
        private const string ORACLE_ADAPTER_TYPE_VALUE = "System.Data.OracleClient.OracleDataAdapter";
        private const string MY_SQL_ADAPTER_TYPE_VALUE = "MySql.Data.MySqlClient.MySqlDataAdapter";
        private const string OLEDB_ADAPTER_TYPE_VALUE = "System.Data.OleDb.OleDbDataAdapter";
        private const string ODBC_ADAPTER_TYPE_VALUE = "System.Data.Odbc.OdbcDataAdapter";
        private const string COMPACT_ADAPTER_TYPE_VALUE = "System.Data.SqlServerCe.SqlCeDataAdapter";

        private const string MY_SQL_ASSEMBLY_TYPE_VALUE = "MySql.Data.dll";



        private string _providerName = string.Empty;
        private AssemblyProvider()
        {
            _providerName = Configuration.ProviderName;
            PopulateAssemblyParameters();
            LoadAssembly(_providerName);           
        }

        private AssemblyProvider(string providerName)
        {
            _providerName = providerName;
            PopulateAssemblyParameters();
            LoadAssembly(providerName);
        }

               
        #region "Internal Methods and Properties"
        
        internal string GetDataAdapterType()
        {
          //  _providerName = Configuration.ProviderName;
            string dbAdapterType = "";            
            dbAdapterType = _dbAdapters[_providerName].ToString();
            return dbAdapterType;
        }

        internal string GetParameterType()
        {
           // _providerName = Configuration.ProviderName;
            string parameterType = "";            
            parameterType = _dbParameters[_providerName].ToString();
            return parameterType;
        }

        internal string GetConnectionType()
        {
           // _providerName = Configuration.ProviderName;
            string connectionType = "";            
            connectionType = _dbConnections[_providerName].ToString();
            return connectionType;
        }

        internal string GetCommandType()
        {
            //_providerName = Configuration.ProviderName;
            string commandType = "";            
            commandType = _dbCommands[_providerName].ToString();
            return commandType;
        }
        
        internal Assembly DBProviderAssembly
        {
            get
            {
                return _assembly;
            }
        }

        internal Hashtable ConnectionTypes
        {
            get
            {
                return _dbConnections;
            }
        }

        internal Hashtable CommandTypes
        {
            get
            {
                return _dbCommands;
            }
        }

        internal Hashtable DBProviders
        {
            get
            {
                return _dbProviders;
            }
        }

        public static AssemblyProvider GetInstance(string providerName)
        {
            /*if (_assemblyProvider == null)
            {*/
            _assemblyProvider = new AssemblyProvider(providerName);
            //}
            return _assemblyProvider;
        }


        public static AssemblyProvider GetInstance()
        {
            /*if (_assemblyProvider == null)
            {*/
            _assemblyProvider = new AssemblyProvider();
            //}
            return _assemblyProvider;
        }
        #endregion


        #region "Private Methods"

       

        private void LoadAssembly(string providerName)
        {
            try
            {
                string assemblyName = _dbProviders[providerName].ToString();
                _assemblyName = new AssemblyName(assemblyName);
                _assembly = Assembly.Load(_assemblyName);
            }
            catch
            {
                //string path = @"C:\Users\david.santos\Downloads\DALGenericSourceCode\DALGeneric\bin\Debug\MySql.Data.dll";//System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string assemblyDll = _dbAssemblies[providerName].ToString();
                byte[] assembly = System.IO.File.ReadAllBytes(path + "\\" + assemblyDll);
                //byte[] assembly = System.IO.File.ReadAllBytes(path);
                _assembly = Assembly.Load(assembly);
            }
        }
      
        private void PopulateAssemblyParameters()
        {
            _dbProviders.Add(SQL_SERVER_PROVIDER_KEY, SQL_SERVER_PROVIDER_VALUE);
            _dbProviders.Add(ORACLE_PROVIDER_KEY, ORACLE_PROVIDER_VALUE);
            _dbProviders.Add(MY_SQL_PROVIDER_KEY, MY_SQL_PROVIDER_VALUE);
            _dbProviders.Add(OLEDB_PROVIDER_KEY, OLEDB_PROVIDER_VALUE);
            _dbProviders.Add(ODBC_PROVIDER_KEY, ODBC_PROVIDER_VALUE);
            _dbProviders.Add(COMPACT35_PROVIDER_KEY, COMPACT35_PROVIDER_VALUE);
            _dbProviders.Add(COMPACT4_PROVIDER_KEY, COMPACT4_PROVIDER_VALUE);
            _dbProviders.Add(MY_SQL_PROVIDER_KEY2, MY_SQL_PROVIDER_VALUE);

            _dbConnections.Add(SQL_SERVER_PROVIDER_KEY, SQL_SERVER_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(ORACLE_PROVIDER_KEY, ORACLE_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(MY_SQL_PROVIDER_KEY, MY_SQL_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(OLEDB_PROVIDER_KEY, OLEDB_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(ODBC_PROVIDER_KEY, ODBC_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(COMPACT35_PROVIDER_KEY, COMPACT_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(COMPACT4_PROVIDER_KEY, COMPACT_CONNECTION_TYPE_VALUE);
            _dbConnections.Add(MY_SQL_PROVIDER_KEY2, MY_SQL_CONNECTION_TYPE_VALUE);


            _dbCommands.Add(SQL_SERVER_PROVIDER_KEY, SQL_SERVER_COMMAND_TYPE_VALUE);
            _dbCommands.Add(ORACLE_PROVIDER_KEY, ORACLE_COMMAND_TYPE_VALUE);
            _dbCommands.Add(MY_SQL_PROVIDER_KEY, MY_SQL_COMMAND_TYPE_VALUE);
            _dbCommands.Add(OLEDB_PROVIDER_KEY, OLEDB_COMMAND_TYPE_VALUE);
            _dbCommands.Add(ODBC_PROVIDER_KEY, ODBC_COMMAND_TYPE_VALUE);
            _dbCommands.Add(COMPACT35_PROVIDER_KEY, COMPACT_COMMAND_TYPE_VALUE);
            _dbCommands.Add(COMPACT4_PROVIDER_KEY, COMPACT_COMMAND_TYPE_VALUE);
            _dbCommands.Add(MY_SQL_PROVIDER_KEY2, MY_SQL_COMMAND_TYPE_VALUE);

            _dbParameters.Add(SQL_SERVER_PROVIDER_KEY, SQL_SERVER_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(ORACLE_PROVIDER_KEY, ORACLE_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(MY_SQL_PROVIDER_KEY, MY_SQL_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(OLEDB_PROVIDER_KEY, OLEDB_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(ODBC_PROVIDER_KEY, ODBC_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(COMPACT35_PROVIDER_KEY, COMPACT_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(COMPACT4_PROVIDER_KEY, COMPACT_PARAMETER_TYPE_VALUE);
            _dbParameters.Add(MY_SQL_PROVIDER_KEY2, MY_SQL_PARAMETER_TYPE_VALUE);

            _dbAdapters.Add(SQL_SERVER_PROVIDER_KEY, SQL_SERVER_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(ORACLE_PROVIDER_KEY, ORACLE_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(MY_SQL_PROVIDER_KEY, MY_SQL_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(OLEDB_PROVIDER_KEY, OLEDB_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(ODBC_PROVIDER_KEY, ODBC_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(COMPACT35_PROVIDER_KEY, COMPACT_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(COMPACT4_PROVIDER_KEY, COMPACT_ADAPTER_TYPE_VALUE);
            _dbAdapters.Add(MY_SQL_PROVIDER_KEY2, MY_SQL_ASSEMBLY_TYPE_VALUE);
            
            _dbAssemblies.Add(MY_SQL_PROVIDER_KEY, MY_SQL_ASSEMBLY_TYPE_VALUE);
        }
        #endregion
    }
}
