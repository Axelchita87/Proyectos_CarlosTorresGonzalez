using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class GetCatCarTypCodDescriptionBL
    {
        public static string GetCatCarTypCodDescription(string code)
        {
            string codeDescription = string.Empty;
            GetCatCarTypCodDescriptionDAL objCode = new GetCatCarTypCodDescriptionDAL();
            try
            {
                try
                {
                    codeDescription = objCode.GetCatCarTypCodDescription(code, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    codeDescription = objCode.GetCatCarTypCodDescription(code, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return codeDescription;
        }
    }
}
