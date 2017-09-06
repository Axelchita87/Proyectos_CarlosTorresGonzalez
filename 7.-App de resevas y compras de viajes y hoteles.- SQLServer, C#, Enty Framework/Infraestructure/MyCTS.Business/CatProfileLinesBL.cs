using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatProfileLinesBL
    {
        public static List<ListItem> GetProfileLines()
        {
            List<ListItem> ProfileLines_List = new List<ListItem>();
            CatProfileLinesDAL objProfileLines = new CatProfileLinesDAL();
            try
            {
                try
                {
                    ProfileLines_List = objProfileLines.GetProfileLines(CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ProfileLines_List = objProfileLines.GetProfileLines(CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ProfileLines_List;

        }
    }
}
