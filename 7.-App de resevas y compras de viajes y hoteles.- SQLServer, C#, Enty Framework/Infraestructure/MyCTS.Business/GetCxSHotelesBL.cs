using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetCxSHotelesBL
    {
        public static CxSHoteles GetCxSHoteles(string pnr)
        {
            CxSHoteles datos = new CxSHoteles();
            GetCxSHotelesDAL getCxSHoteles = new GetCxSHotelesDAL();
            try
            {
                try
                {
                    datos = getCxSHoteles.GetCxSHoteles(pnr, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    datos = getCxSHoteles.GetCxSHoteles(pnr, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }

            return datos;
        }
    }
}
