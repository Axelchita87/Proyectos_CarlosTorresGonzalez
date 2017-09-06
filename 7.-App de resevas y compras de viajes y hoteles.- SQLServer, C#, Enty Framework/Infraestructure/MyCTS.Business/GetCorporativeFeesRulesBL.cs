using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetCorporativeFeesRulesBL
    {
        public static List<GetCorporativeFeesRules> GetCorporativeFeesRules(string location_dk, string attribute1, double quantity, string te1, string te2,
            string te3, string te4, string te5, string te6, string te7, string te8, string te9, string te10, string te11, string te12,
            string te13, string te14, string te15, string te16, string te17, string te18, string te19, string te20, string te21, string te23)
        {
            List<GetCorporativeFeesRules> listCorporativeFeesRules = new List<GetCorporativeFeesRules>();
            GetCorporativeFeesRulesDAL objCorporativeFeesRules = new GetCorporativeFeesRulesDAL();
            try
            {
                try
                {
                    listCorporativeFeesRules = objCorporativeFeesRules.GetCorporativeFeesRulesIndex(location_dk, attribute1, quantity, te1, te2, te3, te4, te5,
                                                te6, te7, te8, te9, te10, te11, te12, te13, te14, te15, te16, te17, te18, te19, te20,
                                                te21, te23, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    //new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listCorporativeFeesRules = objCorporativeFeesRules.GetCorporativeFeesRulesIndex(location_dk, attribute1, quantity, te1, te2, te3, te4, te5,
                                                te6, te7, te8, te9, te10, te11, te12, te13, te14, te15, te16, te17, te18, te19, te20,
                                                te21, te23, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listCorporativeFeesRules;
        }
    }
}
