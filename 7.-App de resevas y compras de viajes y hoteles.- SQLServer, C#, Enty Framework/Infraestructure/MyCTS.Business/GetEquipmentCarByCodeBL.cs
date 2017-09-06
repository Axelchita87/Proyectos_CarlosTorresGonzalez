using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business 
{
    public class GetEquipmentCarByCodeBL
    {
        public static string GetEquipmentCarByCode(string code)
        {
            string equipCode = string.Empty;
            GetEquipmentCarByCodeDAL objCatCar = new GetEquipmentCarByCodeDAL();
            try
            {
                try
                {
                    equipCode = objCatCar.GetEquipmentCarByCode(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    equipCode = objCatCar.GetEquipmentCarByCode(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return equipCode;
        }
    }
}
