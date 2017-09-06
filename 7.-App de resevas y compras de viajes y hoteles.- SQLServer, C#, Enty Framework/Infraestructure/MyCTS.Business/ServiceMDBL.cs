using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class ServiceMDBL
    {
        public static List<ServicesMD> GetServiceMD()
        {
            List<ServicesMD> servicesList = new List<ServicesMD>();
            ServiceMDDAL objGetServices = new ServiceMDDAL();
            try
            {
                try
                {
                    servicesList = objGetServices.GetServiceMD(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    servicesList = objGetServices.GetServiceMD(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return servicesList;
        } 
    }
}
