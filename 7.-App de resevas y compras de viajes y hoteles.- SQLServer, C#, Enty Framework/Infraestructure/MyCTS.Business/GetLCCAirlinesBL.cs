using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetLCCAirlinesBL
    {
        public List<string> GetLCCAirlines()
        {
            GetLCCAirlinesDAL dal = new GetLCCAirlinesDAL();
            List<string> airlines = new List<string>();

            try
            {
                try
                {
                    airlines = dal.GetLCCAirlines(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                }
            }
            catch
            { }
            return airlines;
        }
    }
}
