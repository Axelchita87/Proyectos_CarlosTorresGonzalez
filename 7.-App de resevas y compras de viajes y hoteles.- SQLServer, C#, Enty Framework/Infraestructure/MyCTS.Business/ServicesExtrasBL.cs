using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class ServicesExtrasBL
    {
        public static List<ServicesExtras> ServicesExtras()
        {
            List<ServicesExtras> objServicio = new List<ServicesExtras>();
            ServicesExtrasDAL objGetServicio = new ServicesExtrasDAL();

            try
            {
                objServicio = objGetServicio.ServicesExtras(CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                objServicio = objGetServicio.ServicesExtras(CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return objServicio;
        }
    }
}
