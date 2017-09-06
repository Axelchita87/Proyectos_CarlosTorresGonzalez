using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class CommandsActionsDAL
    {

        public List<CommandsActions> GetCommandsActions(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CommandsrestrictedResources.SP_GetCommandsRestricted);

            List<CommandsActions> commandsActionsList = new List<CommandsActions>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _id = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_ID);
                int _command = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_COMMAND);
                int _modulename = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_MODULENAME);
                int _message = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_MESSAGE);
                int _commandtype = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_COMMANDTYPE);
                int _modulesrc = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_MODULESRC);
                int _allow = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_ALLOW);
                int _commandsallowed = dr.GetOrdinal("CommandsAllowed");
                int _commandsrestricted = dr.GetOrdinal("CommandsRestricted");

                while (dr.Read())
                {
                    CommandsActions item = new CommandsActions();
                    item.ID = dr.GetInt32(_id);
                    item.Command = dr.GetString(_command);
                    item.ModulesName = (dr[_modulename] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_modulename);
                    item.Message = (dr[_message] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_message);
                    item.CommandType = dr.GetString(_commandtype);
                    item.ModuleSrc = (dr[_modulesrc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_modulesrc);
                    item.Allow = dr.GetBoolean(_allow);
                    if (dr[_commandsallowed] == DBNull.Value)
                    {
                        item.CommandsAllowed = new List<string>();
                    }
                    else
                    {
                        string[] result = dr.GetString(_commandsallowed).Split(new char[] { ',' });
                        List<string> listResult = new List<string>(result.Length);
                        listResult.AddRange(result);
                        item.CommandsAllowed = listResult;
                    }

                    if (dr[_commandsrestricted] == DBNull.Value)
                    {
                        item.CommandsRestricted = new List<string>();
                    }
                    else
                    {
                        string[] result = dr.GetString(_commandsrestricted).Split(new char[] { ',' });
                        List<string> listResult = new List<string>(result.Length);
                        listResult.AddRange(result);
                        item.CommandsRestricted = listResult;
                    }
                    commandsActionsList.Add(item);
                }
            }
            return commandsActionsList;
        }

    }
}
