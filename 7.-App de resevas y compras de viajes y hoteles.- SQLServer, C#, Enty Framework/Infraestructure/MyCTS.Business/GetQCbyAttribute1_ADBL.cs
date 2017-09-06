using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetQCbyAttribute1_ADBL
    {
        public static List<GetQCbyAttribute1_AD> GetAttribute(string attribute)
        {
            List<GetQCbyAttribute1_AD> attributeList = new List<GetQCbyAttribute1_AD>();
            GetQCbyAttribute1_ADDAL objAttribute1 = new GetQCbyAttribute1_ADDAL();
            try
            {
                try
                {
                    attributeList = objAttribute1.GetAttribute(attribute, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    attributeList = objAttribute1.GetAttribute(attribute, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return attributeList;
        }
    }
}
