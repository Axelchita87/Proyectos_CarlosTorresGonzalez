using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetCatCarVenCodNameBL
    {
        public static string GetCatCarVenCodName(string code)
        {
            string vendCodeName = string.Empty;
            GetCatCarVenCodNameDAL objVendCodeName = new GetCatCarVenCodNameDAL();
            try
            {
                try
                {
                    vendCodeName = objVendCodeName.GetCatCarVenCodName(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    vendCodeName = objVendCodeName.GetCatCarVenCodName(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return vendCodeName;
        }
    }
}
