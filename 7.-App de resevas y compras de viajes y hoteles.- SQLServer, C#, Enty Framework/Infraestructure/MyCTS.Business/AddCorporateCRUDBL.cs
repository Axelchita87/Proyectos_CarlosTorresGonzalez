using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class AddCorporateCRUDBL
    {
        public static void AddCorporateCRUD(AddCorporateCRUD addCorporateCRUD)
        {
            AddCorporateCRUDDAL objAddCorporateCRUD = new AddCorporateCRUDDAL();
            try
            {
                try
                {
                    objAddCorporateCRUD.AddCorporateCRUD(addCorporateCRUD, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAddCorporateCRUD.AddCorporateCRUD(addCorporateCRUD, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
