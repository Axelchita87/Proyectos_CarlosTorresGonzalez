using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class GetCatCarEquCodNameBL
    {
        public static string GetCatCarEquCodName(string code)
        {
            string equipCode = string.Empty;
            GetCatCarEquCodNameDAL objCatCar = new GetCatCarEquCodNameDAL();
            try
            {
                try
                {
                    equipCode = objCatCar.GetCatCarEquCodName(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    equipCode = objCatCar.GetCatCarEquCodName(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return equipCode;
        }
    }
}
