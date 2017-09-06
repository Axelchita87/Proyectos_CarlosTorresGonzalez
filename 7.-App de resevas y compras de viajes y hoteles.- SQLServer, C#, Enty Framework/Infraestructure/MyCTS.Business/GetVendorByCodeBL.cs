using MyCTS.DataAccess;
using MyCTS.Entities;
using System;

namespace MyCTS.Business
{ 
    public class GetVendorByCodeBL
    {
        public static string GetVendorByCode(string code)
        {
            string equipCode = string.Empty;
            GetVendorByCodeDAL objCatCar = new GetVendorByCodeDAL();
            try
            {
                try
                {
                    equipCode = objCatCar.GetVendorByCode(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    equipCode = objCatCar.GetVendorByCode(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return equipCode;
        }
    }
}
