using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetIdRemarkLabelBL
    {
        public static GetIdRemarkLabel GetIdRemarkLabel(string idremarkLabel)
        {
            GetIdRemarkLabel item = new GetIdRemarkLabel();
            GetIdRemarkLabelDAL obj = new GetIdRemarkLabelDAL();
            try
            {
                item = obj.GetIdRemarkLabel(idremarkLabel, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                item = obj.GetIdRemarkLabel(idremarkLabel, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return item;
        }
    }
}
