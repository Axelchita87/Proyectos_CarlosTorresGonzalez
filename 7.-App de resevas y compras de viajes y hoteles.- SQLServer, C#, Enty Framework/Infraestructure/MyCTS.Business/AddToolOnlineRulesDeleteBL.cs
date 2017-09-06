using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class AddToolOnlineRulesDeleteBL
    {
        public static void AddCorporateDelete(AddToolOnlineRulesDelete addCorporateDelete)
        {
            AddToolOnlineRulesDeleteDAL objAddCorporateDelete = new AddToolOnlineRulesDeleteDAL();
            try
            {
                try
                {
                    objAddCorporateDelete.AddCorporateDelete(addCorporateDelete, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAddCorporateDelete.AddCorporateDelete(addCorporateDelete, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
