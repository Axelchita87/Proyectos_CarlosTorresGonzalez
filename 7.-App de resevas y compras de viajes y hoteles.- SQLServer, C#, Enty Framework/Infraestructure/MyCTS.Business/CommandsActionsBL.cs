using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CommandsActionsBL
    {

        public static List<CommandsActions> GetCommandsActions()
        {
            List<CommandsActions> listCommandsActions = new List<CommandsActions>();
            CommandsActionsDAL objCommandsRestricted = new CommandsActionsDAL();
            try
            {
                try
                {
                    listCommandsActions = objCommandsRestricted.GetCommandsActions(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listCommandsActions = objCommandsRestricted.GetCommandsActions(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }

            return listCommandsActions;
        }

    }


}
