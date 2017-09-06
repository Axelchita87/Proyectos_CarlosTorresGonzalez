using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeleteAirLinesFareBL
    {
        public static void DeleteAirLinesFare(string catAirLinFarId)
        {
            DeleteAirLinesFareDAL objDeleteAirLines = new DeleteAirLinesFareDAL();
            try
            {
                try
                {
                    objDeleteAirLines.DeleteAirLinesFare(catAirLinFarId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteAirLines.DeleteAirLinesFare(catAirLinFarId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
