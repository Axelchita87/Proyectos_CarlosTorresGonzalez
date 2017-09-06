using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SubTypePaxBL
    {
        public static List<SubTypePax> GetSubTypePax(string fieldValue)
        {
            List<SubTypePax> listSubTypePax = new List<SubTypePax>();
            SubTypePaxDAL objSubTypePax = new SubTypePaxDAL();
            try
            {
                try
                {
                    listSubTypePax = objSubTypePax.GetSubTypePax(fieldValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listSubTypePax = objSubTypePax.GetSubTypePax(fieldValue, CommonENT.MYCTSDB_CONNECTION);
                }
            }
            catch
            { }
            return listSubTypePax;

        }
    }
}
