using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetQCbyAttribute1BL
    {
        public static List<GetQCbyAttribute1> GetAttribute(string attribute)
        {
            List<GetQCbyAttribute1> attributeList = new List<GetQCbyAttribute1>();
            GetQCbyAttribute1DAL objAttribute1 = new GetQCbyAttribute1DAL();
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
