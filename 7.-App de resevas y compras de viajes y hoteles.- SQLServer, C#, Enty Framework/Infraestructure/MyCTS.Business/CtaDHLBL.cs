using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class CtaDHLBL
    {
        public static List<CtaDHL> GetCtaDHL()
        {
            List<CtaDHL> CtaDHLList = new List<CtaDHL>();
            CtaDHLDAL objCtaDHL = new CtaDHLDAL();
            try
            {
                try
                {
                    CtaDHLList = objCtaDHL.GetCtaDHL(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CtaDHLList = objCtaDHL.GetCtaDHL(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CtaDHLList;

        }
    }
}
