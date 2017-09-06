using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class QCCustomRemarksBL
    {
        public static QCCustomRemarks GetQCustomRemarks(string Attribute1)
        {
            QCCustomRemarks CustomRemarks = new QCCustomRemarks();
            QCCustomRemarksDAL objQCCustomRemarks = new QCCustomRemarksDAL();
            try
            {
                try
                {
                    CustomRemarks = objQCCustomRemarks.GetQCCustomRemarks(Attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CustomRemarks = objQCCustomRemarks.GetQCCustomRemarks(Attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CustomRemarks;

        }
    }
}
