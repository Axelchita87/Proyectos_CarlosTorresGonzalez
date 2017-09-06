using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirLineFareBL
    {
        public static List<AirLineFare> GetAirLineFare(string StrToSearch)
        {

            List<AirLineFare> listAirLineFare = new List<AirLineFare>();
            AirLineFareDAL objAirLineFare = new AirLineFareDAL();
            try
            {
                try
                {
                    listAirLineFare = objAirLineFare.GetAirLineFare(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirLineFare = objAirLineFare.GetAirLineFare(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAirLineFare;
        }


        public static AirLineFare GetOneAirLineFare(string airline)
        {

            AirLineFare AirLineFare = new AirLineFare();
            AirLineFareDAL objAirLineFare = new AirLineFareDAL();
            try
            {
                try
                {
                    AirLineFare = objAirLineFare.GetOneAirLineFare(airline, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    AirLineFare = objAirLineFare.GetOneAirLineFare(airline, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return AirLineFare;
        }
    }
}
