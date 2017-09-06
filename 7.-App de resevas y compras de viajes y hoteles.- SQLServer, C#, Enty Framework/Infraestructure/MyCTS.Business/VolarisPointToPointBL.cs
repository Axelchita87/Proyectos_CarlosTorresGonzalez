using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class VolarisPointToPointBL
    {
        public static VolarisPointToPoint VolarisPointToPoint(string departure, string arrival)
        {
            VolarisPointToPointDAL objPCCs = new VolarisPointToPointDAL();
            VolarisPointToPoint point = new VolarisPointToPoint();
            try
            {
               point= objPCCs.GetPointToPointFlightsV2(departure,arrival, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                   new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   point= objPCCs.GetPointToPointFlightsV2(departure, arrival, CommonENT.MYCTSDB_CONNECTION);
                }
                catch { }
            }
            return point;
        }
    }
}
