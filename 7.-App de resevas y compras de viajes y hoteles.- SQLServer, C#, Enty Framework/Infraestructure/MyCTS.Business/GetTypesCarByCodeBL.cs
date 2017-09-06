using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{ 
    public class GetTypesCarByCodeBL
    {
        public static string GetTypesCarByCode(string code)
        {
            string equipCode = string.Empty;
            GetTypesCarByCodeDAL objCatCar = new GetTypesCarByCodeDAL();
            try
            {
                try
                {
                    equipCode = objCatCar.GetTypesCarByCode(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    equipCode = objCatCar.GetTypesCarByCode(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return equipCode;
        }
    }
}
