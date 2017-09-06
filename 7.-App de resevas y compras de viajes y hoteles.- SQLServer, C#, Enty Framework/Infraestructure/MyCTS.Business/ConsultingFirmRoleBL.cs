using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class ConsultingFirmRoleBL
    {
        public static List<ConsultingFirmRole> GetConsultingFirmRole(string Firm, string Pcc)
        {
            List<ConsultingFirmRole> ConsultingFirmRoleList = new List<ConsultingFirmRole>();
            ConsultingFirmRoleDAL objConsultingFirmRole = new ConsultingFirmRoleDAL();
            try
            {
                try
                {
                    ConsultingFirmRoleList = objConsultingFirmRole.GetConsultingFirmRole(Firm, Pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ConsultingFirmRoleList = objConsultingFirmRole.GetConsultingFirmRole(Firm, Pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }

            return ConsultingFirmRoleList;
        }
    }
}

