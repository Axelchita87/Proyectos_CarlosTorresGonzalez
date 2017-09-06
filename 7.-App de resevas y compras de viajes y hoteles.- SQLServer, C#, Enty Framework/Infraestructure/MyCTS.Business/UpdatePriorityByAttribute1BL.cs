using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdatePriorityByAttribute1BL
    {
        public static void UpdatePriorities(int newPriority, string attribute1)
        {
            UpdatePriorityByAttribute1DAL objUpdatePriorities = new UpdatePriorityByAttribute1DAL();
            try
            {
                try
                {
                    objUpdatePriorities.UpdatePriorities(newPriority, attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdatePriorities.UpdatePriorities(newPriority, attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
