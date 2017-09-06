using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class MyCTSVersionBL
    {
        public static List<MyCTSVersion> SetMyCTSVersion(string Firm, string PCC, string MyCTSVersion)
        {
            List<MyCTSVersion> SetMyCTSVersionList = new List<MyCTSVersion>();
            MyCTSVersionDAL objSetMyCTSVersion = new MyCTSVersionDAL();
            try
            {

                try
                {
                    SetMyCTSVersionList = objSetMyCTSVersion.SetMyCTSVersion(Firm,PCC,MyCTSVersion, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    SetMyCTSVersionList = objSetMyCTSVersion.SetMyCTSVersion(Firm, PCC, MyCTSVersion, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION); 
                }

            }
            catch
            { }
            return SetMyCTSVersionList;

        }
    }
}
