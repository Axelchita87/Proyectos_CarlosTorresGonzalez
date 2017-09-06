using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetLocationDKNotAcceptedBL
    {
        public static List<SetLocationDKNotAccepted> SetLocationDKNotAccepted(int ruleNumber, string locationDK)
        {
            List<SetLocationDKNotAccepted> listLocationDKNotAccepted = new List<SetLocationDKNotAccepted>();
            SetLocationDKNotAcceptedDAL objInsertLocation = new SetLocationDKNotAcceptedDAL();
            try
            {
                try
                {
                    listLocationDKNotAccepted = objInsertLocation.InsertLocationDKNotAccepted(ruleNumber, locationDK, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listLocationDKNotAccepted = objInsertLocation.InsertLocationDKNotAccepted(ruleNumber, locationDK, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listLocationDKNotAccepted;
        }
    }
}
