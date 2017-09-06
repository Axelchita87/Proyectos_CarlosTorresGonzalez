using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CiaDHLBL
    {
        public static List<CiaDHL> GetCiaDHL()
        {
            List<CiaDHL> CiaDHLList = new List<CiaDHL>();
            CiaDHLDAL objCiaDHL = new CiaDHLDAL();
            try
            {
                try
                {
                    CiaDHLList = objCiaDHL.GetCiaDHL(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CiaDHLList = objCiaDHL.GetCiaDHL(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CiaDHLList;

        }
    }
}
