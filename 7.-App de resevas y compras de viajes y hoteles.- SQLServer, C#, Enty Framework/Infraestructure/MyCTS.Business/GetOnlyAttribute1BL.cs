using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetOnlyAttribute1BL
    {
        public static List<GetOnlyAttribute1> GetAttribute1(string locationDK)
        {
            List<GetOnlyAttribute1> attributeList = new List<GetOnlyAttribute1>();
            GetOnlyAttribute1DAL objAttribute1 = new GetOnlyAttribute1DAL();
            try
            {
                try
                {
                    attributeList = objAttribute1.GetAttribute(locationDK, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    attributeList = objAttribute1.GetAttribute(locationDK, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return attributeList;
        }
    }
}

