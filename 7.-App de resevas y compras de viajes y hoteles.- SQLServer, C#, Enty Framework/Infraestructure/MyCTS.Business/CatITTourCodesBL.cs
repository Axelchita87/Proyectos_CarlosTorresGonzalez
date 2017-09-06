using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatITTourCodesBL
    {
        public static List<CatITTourCodes> GetITTourCodes()
        {
            List<CatITTourCodes> ITTourCodesList = new List<CatITTourCodes>();
            CatITTourCodesDAL objITTourCodes = new CatITTourCodesDAL();
            try
            {
                try
                {
                    ITTourCodesList = objITTourCodes.GetITTourCodes(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ITTourCodesList = objITTourCodes.GetITTourCodes(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ITTourCodesList;
        }
    }
}
