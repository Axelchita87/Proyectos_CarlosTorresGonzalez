using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateDetailPNRHotelsBL
    {

        public static void UpdateDetailPNRHotels(string reclog,string chaincode, bool cancel, string codecancel)
        {
            UpdateDetailsPNRHotelDAL objDetailHotel = new UpdateDetailsPNRHotelDAL();
            //DetailsPNRHotels item = new DetailsPNRHotels();
            try
            {
                try
                {
                        objDetailHotel.UpdateDetailHotel(reclog,chaincode,codecancel, cancel, CommonENT.MYCTSDB_CONNECTION);
                }

                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    //string err = e.Message + e.Source + e.InnerException;
                        objDetailHotel.UpdateDetailHotel(reclog, chaincode, codecancel, cancel,  CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }

        }



    }
}
