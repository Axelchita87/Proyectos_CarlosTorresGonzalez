using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetQCIDCtrlBL
    {
        public static List<GetQCIDCtrl> GetQCIDCtrl(string idCtrl)
        {
            List<GetQCIDCtrl> listQCIDCtrl = new List<GetQCIDCtrl>();
            GetQCIDCtrlDAL objIDCtrl = new GetQCIDCtrlDAL();
            try
            {
                try
                {
                    listQCIDCtrl = objIDCtrl.GetQCIDCtrl(idCtrl, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listQCIDCtrl = objIDCtrl.GetQCIDCtrl(idCtrl, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listQCIDCtrl;
        }
    }
}
