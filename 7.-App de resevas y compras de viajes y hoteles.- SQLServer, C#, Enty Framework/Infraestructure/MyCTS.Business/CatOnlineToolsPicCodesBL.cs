using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class CatOnlineToolsPicCodesBL
    {
        public static List<CatOnlineToolsPicCodes> GetPicCodes()
        {
            List<CatOnlineToolsPicCodes> CatOnlinePiccodeList = new List<CatOnlineToolsPicCodes>();
            CatOnlineToolsPicCodesDAL objPicCode= new CatOnlineToolsPicCodesDAL();
            try
            {
                try
                {
                    CatOnlinePiccodeList = objPicCode.GetPicCodes(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatOnlinePiccodeList = objPicCode.GetPicCodes(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CatOnlinePiccodeList;

        }
    }
}
