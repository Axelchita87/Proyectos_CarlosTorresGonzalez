using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class CatSubTypePaxBL
    {
        public List<string> CatSubTypePax()
        {
            CatSubTypePaxDAL dal = new CatSubTypePaxDAL();
            List<string> passengerTypes = new List<string>();

            try
            {
                try
                {
                    passengerTypes = dal.CatSubTypePax(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                }
            }
            catch
            { }
            return passengerTypes;
        }
    }
}
