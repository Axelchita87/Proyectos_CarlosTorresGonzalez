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
    public class CommandsRestrictedDAL
    {

        //public List<CommandsRestricted> GetCommandsRestricted()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand(Resources.CommandsrestrictedResources.SP_GetCommandsRestricted);

        //    List<CommandsRestricted> commandsRestrictedList = new List<CommandsRestricted>();

        //    using (IDataReader dr = db.ExecuteReader(dbCommand))
        //    {
        //        int _id = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_ID);
        //        int _command = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_COMMAND);
        //        int _modulename = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_MODULENAME);
        //        int _message = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_MESSAGE);
        //        int _commandtype = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_COMMANDTYPE);
        //        int _modulesrc = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_MODULESRC);
        //        int _allow = dr.GetOrdinal(Resources.CommandsrestrictedResources.PARAM_ALLOW);

        //        while (dr.Read())
        //        {
        //            CommandsRestricted item = new CommandsRestricted();
        //            item.ID = dr.GetInt32(_id);
        //            item.Command = dr.GetString(_command);
        //            item.ModulesName = (dr[_modulename] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_modulename);
        //            item.Message = (dr[_message] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_message);
        //            item.CommandType = dr.GetString(_commandtype);
        //            item.ModuleSrc = (dr[_modulesrc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_modulesrc);
        //            item.Allow = dr.GetBoolean(_allow);
        //            commandsRestrictedList.Add(item);
        //        }
        //    }

        //    return commandsRestrictedList;
        //}

    }
}
