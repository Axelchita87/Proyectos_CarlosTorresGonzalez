using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetQualityCotrolsBL
    {
        public static List<GetQualityCotrols> GetQualityCotrols(string idCtrl)
        {
            List<GetQualityCotrols> GetQualityCotrolsList = new List<GetQualityCotrols>();
            GetQualityCotrolsDAL objQC = new GetQualityCotrolsDAL();
            try
            {
                try
                {
                    GetQualityCotrolsList = objQC.GetQualityCotrols(idCtrl, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    GetQualityCotrolsList = objQC.GetQualityCotrols(idCtrl, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return GetQualityCotrolsList;

        }

    }
}
