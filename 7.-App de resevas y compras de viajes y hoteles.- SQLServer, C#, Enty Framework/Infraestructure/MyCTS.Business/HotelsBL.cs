using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class HotelsBL
    {

        public static List<Hotels> GetHotels()
        {
            List<Hotels> listHotels = new List<Hotels>();
            HotelsDAL objHotel = new HotelsDAL();
            try
            {
                try
                {
                    listHotels = objHotel.GetHotels(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listHotels = objHotel.GetHotels(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }

            return listHotels;
        }
    }
}
