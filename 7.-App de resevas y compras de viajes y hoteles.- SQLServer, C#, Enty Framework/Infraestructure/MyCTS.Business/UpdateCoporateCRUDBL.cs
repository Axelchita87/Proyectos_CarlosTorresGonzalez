using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class UpdateCoporateCRUDBL
    {
        public static void UpdateCorporateCRUD(UpdateCorporateCRUD updateCorporateCRUD)
        {
            UpdateCorporateCRUDDAL objUpdateCorporateCRUD = new UpdateCorporateCRUDDAL();
            try
            {
                try
                {
                    objUpdateCorporateCRUD.UpdateCorporateCRUD(updateCorporateCRUD, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdateCorporateCRUD.UpdateCorporateCRUD(updateCorporateCRUD, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
