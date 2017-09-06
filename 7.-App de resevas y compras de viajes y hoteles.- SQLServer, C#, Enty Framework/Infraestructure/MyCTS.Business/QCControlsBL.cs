using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class QCControlsBL
    {
        public static List<QCControls> GetQCControls(string Attribute1, string Firm, string PCC)
        {
            List<QCControls> QCControlsList = new List<QCControls>();
            QCControlsDAL objQCControls = new QCControlsDAL();
            try
            {
                try
                {
                    QCControlsList = objQCControls.GetQCControls(Attribute1, Firm, PCC, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    QCControlsList = objQCControls.GetQCControls(Attribute1, Firm, PCC, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return QCControlsList;

        }
    }
}
