using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateImagesBL
    {
        public static int UpdateImgTicketPrinter(Byte[] data)
        {
            int rowsAfected = 0;
            UpdateImagesDAL objUpdateImg = new UpdateImagesDAL();
            try
            {
                rowsAfected = objUpdateImg.UpdateImgTicketPrinter(data, CommonENT.MYCTSDB_CONNECTION);
            }
            catch { }
            return rowsAfected;
        }

        public static int UpdateImgAirlineCode(Byte[] data, string codeAirline)
        {
            int rowsAfected = 0;
            UpdateImagesDAL objUpdateImg = new UpdateImagesDAL();
            try
            {
                rowsAfected = objUpdateImg.UpdateImgAirline(data, codeAirline, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                rowsAfected = objUpdateImg.UpdateImgAirline(data, codeAirline, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return rowsAfected;
        }

        public static int InsertBannerImage(Byte[] data, string name, string extension, string url,
            string activate)
        {
            int rowsAfected = 0;
            UpdateImagesDAL objUpdateImg = new UpdateImagesDAL();
            try
            {
                rowsAfected = objUpdateImg.InsertBannerImage(data, name, extension, url, activate, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                rowsAfected = objUpdateImg.InsertBannerImage(data, name, extension, url, activate, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return rowsAfected;
        }
    }
}
