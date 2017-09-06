using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AllPccsBL
    {
        public static List<AllPccs> GetAllPccs(string strToSearch, int OrgId)
        {
            List<AllPccs> listAllPccs = new List<AllPccs>();
            AllPccsDAL objAllPccs = new AllPccsDAL();
            try
            {
                try
                {
                    listAllPccs = objAllPccs.GetAllPccs(strToSearch, OrgId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAllPccs = objAllPccs.GetAllPccs(strToSearch, OrgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAllPccs;
        }
    }
}
