using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace ADMIN2.DAL
{
    internal class CommandBuilder
    {
        private DBParamBuilder _paramBuilder = new DBParamBuilder();
        
        #region Internal Methods

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, string Prov=null)
        {
            
            return GetCommand(commandText, connection, CommandType.Text, Prov);
        }


        internal IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType, string ProviName=null)
        {
            IDbCommand command = GetCommand(ProviName);
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = commandType;
            return command;
        }        

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameter parameter)
        {
            return GetCommand(commandText, connection, parameter, CommandType.Text);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameter parameter, CommandType commandType)
        {
            IDataParameter param = _paramBuilder.GetParameter(parameter);
            IDbCommand command = GetCommand(commandText, connection, commandType);
            command.Parameters.Add(param);
            return command;
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameterCollection parameterCollection)
        {
            return GetCommand(commandText, connection, parameterCollection, CommandType.Text);
        }

        internal IDbCommand GetCommand(string commandText, IDbConnection connection, DBParameterCollection parameterCollection, CommandType commandType ,string provi=null)
        {
            List<IDataParameter> paramArray = _paramBuilder.GetParameterCollection(parameterCollection);
            IDbCommand command = GetCommand(commandText, connection, commandType, provi);

            foreach (IDataParameter param in paramArray)            
                command.Parameters.Add(param);
     return command;
        }


        #endregion

        #region Private Methods"

        private IDbCommand GetCommand(string provi)
        {
            string typeName= string.Empty;
            IDbCommand command = null;
            if (provi != null)
            {
                typeName = AssemblyProvider.GetInstance(provi).GetCommandType();
                command = (IDbCommand)AssemblyProvider.GetInstance(provi).DBProviderAssembly.CreateInstance(typeName);
            }
            else
            {
                typeName = AssemblyProvider.GetInstance(Configuration.ProviderName).GetCommandType();
                command = (IDbCommand)AssemblyProvider.GetInstance(Configuration.ProviderName).DBProviderAssembly.CreateInstance(typeName);
            }          
            return command;
        }

        #endregion
    }
}
