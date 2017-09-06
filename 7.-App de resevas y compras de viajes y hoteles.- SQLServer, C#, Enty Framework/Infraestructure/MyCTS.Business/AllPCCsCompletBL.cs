using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AllPCCsCompletBL
    {
        public static List<AllPCCsComplet> GetAllPCCsComplet(int OrgId)
        {
            List<AllPCCsComplet> listAllPCCsComplet = new List<AllPCCsComplet>();
            AllPCCsCompletDAL objAllPCCsComplet = new AllPCCsCompletDAL();
            try
            {
                try
                {
                    listAllPCCsComplet = objAllPCCsComplet.GetAllPCCsComplet(OrgId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAllPCCsComplet = objAllPCCsComplet.GetAllPCCsComplet(OrgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAllPCCsComplet;
        }
    }
}

