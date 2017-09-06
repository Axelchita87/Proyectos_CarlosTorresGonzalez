using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class OnlyAttribute1BL
    {
        public static string GetOnlyAttribute1(string attribute1)
        {
            string onlyAttributteList = string.Empty;
            OnlyAttribute1DAL objGetAttributte = new OnlyAttribute1DAL();
            try
            {
                try
                {
                    onlyAttributteList = objGetAttributte.GetOnlyAttribute1(attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    onlyAttributteList = objGetAttributte.GetOnlyAttribute1(attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return onlyAttributteList;
        } 
    }
}
