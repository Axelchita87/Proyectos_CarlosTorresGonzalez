using MyCTS.DataAccess;
using MyCTS.Entities;
using System;

namespace MyCTS.Business
{ 
    public class GetCityNameBL
    {
        public static string GetCityName(string code)
        {
            string equipCode = string.Empty;
            GetCityNameDAL objCatCar = new GetCityNameDAL();
            try
            {
                try
                {
                    equipCode = objCatCar.GetCityName(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    equipCode = objCatCar.GetCityName(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return equipCode;
        }
    }
}
