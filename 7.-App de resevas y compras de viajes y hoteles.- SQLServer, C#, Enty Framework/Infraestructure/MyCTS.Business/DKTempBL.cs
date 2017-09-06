using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DKTempBL
    {
        public static List<DKTemp> GetDKTemp(string Attribute1, bool ProcessType)
        {
            List<DKTemp> DKTempList = new List<DKTemp>();
            DKTempDAL objDKTemp = new DKTempDAL();
            try
            {
                try
                {
                    DKTempList = objDKTemp.GetDKTemp(Attribute1, ProcessType, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    DKTempList = objDKTemp.GetDKTemp(Attribute1, ProcessType, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }

            return DKTempList;
        }
    }
}
