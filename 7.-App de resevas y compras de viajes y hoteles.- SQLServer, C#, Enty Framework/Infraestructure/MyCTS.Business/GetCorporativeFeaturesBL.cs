using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class GetCorporativeFeaturesBL
    {
        public static List<GetCorporativeFeatures> GetCorporativeFeatures(string fieldValue)
        {
            List<GetCorporativeFeatures> listCorporativeFeatures = new List<GetCorporativeFeatures>();
            GetCorporativeFeaturesDAL objCorporativeFeatures = new GetCorporativeFeaturesDAL();
            try
            {
                try
                {
                    listCorporativeFeatures = objCorporativeFeatures.GetCorporativeFeaturesIndex(fieldValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listCorporativeFeatures = objCorporativeFeatures.GetCorporativeFeaturesIndex(fieldValue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listCorporativeFeatures;
        }
    }
}
