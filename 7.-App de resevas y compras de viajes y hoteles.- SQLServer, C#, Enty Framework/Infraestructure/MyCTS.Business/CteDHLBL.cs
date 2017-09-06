using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class CteDHLBL
    {
        public static List<CteDHL> GetCteDHL()
        {
            List<CteDHL> CteDHLList = new List<CteDHL>();
            CteDHLDAL objCteDHL = new CteDHLDAL();
            try
            {
                try
                {
                    CteDHLList = objCteDHL.GetCteDHL(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CteDHLList = objCteDHL.GetCteDHL(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CteDHLList;

        }
    }
}
