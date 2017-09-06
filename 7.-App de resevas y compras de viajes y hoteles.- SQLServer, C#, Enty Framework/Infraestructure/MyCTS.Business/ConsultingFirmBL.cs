using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ConsultingFirmBL
    {
        public static List<ConsultingFirm> GetConsultingFirm(string FirmtoSearch)
        {
            List<ConsultingFirm> ConsultingFirmList = new List<ConsultingFirm>();
            ConsultingFirmDAL objConsultingFirm = new ConsultingFirmDAL();
            try
            {
                try
                {
                    ConsultingFirmList = objConsultingFirm.GetConsultingFirm(FirmtoSearch, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ConsultingFirmList = objConsultingFirm.GetConsultingFirm(FirmtoSearch,CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }

            return ConsultingFirmList;
        }
    }
}
