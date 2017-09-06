using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetBannerImageBL
    {
        public static List<BannerImage> GetBannerImageList(string ControlIndex)
        {
            List<BannerImage> listBannerImage = new List<BannerImage>();
            GetBannerImageDAL objBannerImage = new GetBannerImageDAL();
            try
            {
                try
                {
                    listBannerImage = objBannerImage.GetBannerImages(ControlIndex, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listBannerImage = objBannerImage.GetBannerImages(ControlIndex, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listBannerImage;

        }
    }
}
