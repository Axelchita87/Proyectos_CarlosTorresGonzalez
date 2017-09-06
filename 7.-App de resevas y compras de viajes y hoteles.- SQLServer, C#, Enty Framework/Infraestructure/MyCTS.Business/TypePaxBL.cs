using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class TypePaxBL
    {
        public static List<TypePax> GetTypePax()
        {
            List<TypePax> listTypePax = new List<TypePax>();
            TypePaxDAL objTypePax = new TypePaxDAL();
            try
            {
                try
                {
                    listTypePax = objTypePax.GetTypePax(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listTypePax = objTypePax.GetTypePax(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            {

            }
            return listTypePax;
        }
    }
}
