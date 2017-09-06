using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class QCControlsClientsBL
    {
        public static List<QCControlsClients> GetQCControls(string Attribute1, string Firm, string PCC, string Agent)
        {
            List<QCControlsClients> QCControlsList = new List<QCControlsClients>();
            QCControlsClientsDAL objQCControls = new QCControlsClientsDAL();
            try
            {
                try
                {
                    QCControlsList = objQCControls.GetQCControls(Attribute1, Firm, PCC, Agent, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    QCControlsList = objQCControls.GetQCControls(Attribute1, Firm, PCC, Agent, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return QCControlsList;
        }
    }
}
