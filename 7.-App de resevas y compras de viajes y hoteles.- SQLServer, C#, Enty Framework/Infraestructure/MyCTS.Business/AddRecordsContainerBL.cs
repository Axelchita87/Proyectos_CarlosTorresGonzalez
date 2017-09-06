using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AddRecordsContainerBL
    {
        public static void AddRecordsContainer(string recLoc, string Agent, bool EmissionStatus)
        {
            AddRecordsContainerDAL objAddRecordsContainer = new AddRecordsContainerDAL();
            try
            {
                try
                {
                    objAddRecordsContainer.AddRecordsContainer(recLoc, Agent, EmissionStatus, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAddRecordsContainer.AddRecordsContainer(recLoc, Agent, EmissionStatus, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
