using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class QCExistBL
    {
        public static List<QCExist> GetQCExist()
        {
            List<QCExist> QCExistList = new List<QCExist>();
            QCExistDAL objQCExist = new QCExistDAL();
            try
            {
                try
                {
                    QCExistList = objQCExist.GetQCExist(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    QCExistList = objQCExist.GetQCExist(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return QCExistList;

        }
    }
}
