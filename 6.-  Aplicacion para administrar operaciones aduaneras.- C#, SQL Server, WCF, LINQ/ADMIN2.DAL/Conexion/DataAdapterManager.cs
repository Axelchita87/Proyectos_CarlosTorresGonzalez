using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace ADMIN2.DAL
{
    /// <summary>
    /// IDataAdapter
    /// </summary>
    internal class DataAdapterManager
    {
        private CommandBuilder _commandBuilder = new CommandBuilder();
        

        /// <summary>
        /// Crea y regresa el IDataAdapter necesario según el Query
        /// </summary>
        /// <param name="sqlCommand">Sql Command</param>
        /// <param name="connection">connection</param>
        /// <returns>IDataAdapter</returns>
        internal IDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection)
        {
            return GetDataAdapter(sqlCommand, connection, CommandType.Text);
        }


        /// <summary>
        /// Crea y regresa el IDataAdapter necesario según el Query/Stored Procedure
        /// </summary>
        /// <param name="sqlCommand">Sql Command/ Stored Proc</param>
        /// <param name="connection">Connection</param>
        /// <param name="param">DBParameter</param>
        /// <param name="commandType">Text/StoredProc)</param>
        /// <returns>IDataAdapter</returns>
        internal IDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection, DBParameter param , CommandType commandType)
        {            
            IDataAdapter adapter = null;
            IDbCommand command = _commandBuilder.GetCommand(sqlCommand, connection, param , commandType);
            adapter = GetDataAdapter(command);
            return adapter;
        }


        /// <summary>
        /// Crea y regresa el IDataAdapter necesario según el Query/Stored Procedure
        /// </summary>
        /// <param name="sqlCommand">Sql Command/ Stored Proc</param>
        /// <param name="connection">Connection</param>
        /// <param name="paramCollection">Colección de parámetros</param>
        /// <param name="commandType">Text/StoredProc)</param>
        /// <returns>IDataAdapter</returns>
        internal IDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection, DBParameterCollection paramCollection, CommandType commandType,string provinam= null)
        {
            IDataAdapter adapter = null;
            IDbCommand command = _commandBuilder.GetCommand(sqlCommand, connection, paramCollection, commandType,provinam);
            adapter = GetDataAdapter(command, provinam);            
            return adapter;
        }


        /// <summary>
        /// Crea y regresa el IDataAdapter necesario según el Query/Stored Procedure
        /// </summary>
        /// <param name="sqlCommand">Query/Stored Proc</param>
        /// <param name="connection">Connection</param>
        /// <param name="commandType">Text/StoredProc)</param>
        /// <returns></returns>
        internal IDataAdapter GetDataAdapter(string sqlCommand, IDbConnection connection, CommandType commandType)
        {          
            IDataAdapter adapter = null;
            IDbCommand command = _commandBuilder.GetCommand(sqlCommand, connection, commandType);
            adapter = GetDataAdapter(command);           
            return adapter;
        } 


        /// <summary>
        /// Obtiene una tabla según un query proporcionado
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paramCollection"></param>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        internal DataTable GetDataTable(string sqlCommand, DBParameterCollection paramCollection, IDbConnection connection, string tableName, CommandType commandType)
        {
            DataTable table = null;

            if(tableName != string.Empty)
                table = new DataTable(tableName);
            else
                table = new DataTable();

            IDbCommand command = null;
            if (paramCollection != null)
            {
                if(paramCollection.Parameters.Count > 0)
                    command = _commandBuilder.GetCommand(sqlCommand, connection, paramCollection, commandType);
                else
                    command = _commandBuilder.GetCommand(sqlCommand, connection, commandType);
            }
            else
                command = _commandBuilder.GetCommand(sqlCommand, connection, commandType);


            IDataAdapter adapter = GetDataAdapter(command);
            string typeName = AssemblyProvider.GetInstance(Configuration.ProviderName).GetDataAdapterType();


            Type cmdType = AssemblyProvider.GetInstance(Configuration.ProviderName).DBProviderAssembly.GetType(AssemblyProvider.GetInstance(Configuration.ProviderName).GetCommandType());
            Type dataAdapterType = AssemblyProvider.GetInstance(Configuration.ProviderName).DBProviderAssembly.GetType(AssemblyProvider.GetInstance(Configuration.ProviderName).GetDataAdapterType());

            ConstructorInfo constructor = dataAdapterType.GetConstructor(new Type[] { cmdType });
            adapter = (IDataAdapter)constructor.Invoke(new object[] { command });
            MethodInfo method = dataAdapterType.GetMethod("Fill", new Type[] {typeof(DataTable) });

            try
            {
                method.Invoke(adapter, new object[] { table });
            }
            catch (Exception err)
            {
                throw err;
            }
            return table;
        }

        internal DataTable GetDataTable(string sqlCommand, DBParameter param, IDbConnection connection, string tableName, CommandType commandType)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(param);
            return GetDataTable(sqlCommand, paramCollection , connection, tableName, commandType);
        }

        internal DataTable GetDataTable(string sqlCommand, IDbConnection connection, string tableName, CommandType commandType)
        {            
            return GetDataTable(sqlCommand, new DBParameterCollection(), connection, tableName, commandType);
        }

        internal DataTable GetDataTable(string sqlCommand, IDbConnection connection, CommandType commandType)
        {
            return GetDataTable(sqlCommand, new DBParameterCollection(), connection, string.Empty, commandType);
        }

        internal DataTable GetDataTable(string sqlCommand, IDbConnection connection)
        {
            return GetDataTable(sqlCommand, new DBParameterCollection(), connection, string.Empty, CommandType.Text);
        }


        private ConstructorInfo GetDataAdapterConstructor(string prov= null)
        {
            string typeName = AssemblyProvider.GetInstance(prov).GetDataAdapterType();
            Type cmdType = AssemblyProvider.GetInstance(prov).DBProviderAssembly.GetType(AssemblyProvider.GetInstance(prov).GetCommandType());
            Type dataAdapterType = AssemblyProvider.GetInstance(prov).DBProviderAssembly.GetType(AssemblyProvider.GetInstance(prov).GetDataAdapterType());
            ConstructorInfo constructor = dataAdapterType.GetConstructor(new Type[] { cmdType });
            return constructor;
        }

        private IDataAdapter GetDataAdapter(IDbCommand command, string provi= null)
        {            
            IDataAdapter adapter = null;
            ConstructorInfo constructor = GetDataAdapterConstructor(provi);
            adapter = (IDataAdapter)constructor.Invoke(new object[] { command });                        
            return adapter;
        }
    }
}
