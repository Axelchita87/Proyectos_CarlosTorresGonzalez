using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeletePccsBL
    {
        public static void DeletePccs(string StrToSearch)
        {
            DeletePccsDAL objDeletePccs = new DeletePccsDAL();
            try
            {
                try
                {
                    objDeletePccs.DeletePccs(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeletePccs.DeletePccs(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
