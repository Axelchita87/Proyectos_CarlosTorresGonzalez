using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirLinesClassBL
    {
        public static List<AirLinesClass> GetCatAirLinesClass()
        {
            List<AirLinesClass> listAirLinesClass = new List<AirLinesClass>();
            AirLinesClassDAL objAirLinesClass = new AirLinesClassDAL();
            try
            {
                try
                {
                    listAirLinesClass = objAirLinesClass.GetCatAirLinesClass(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirLinesClass = objAirLinesClass.GetCatAirLinesClass(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAirLinesClass;
        }

    }
}

