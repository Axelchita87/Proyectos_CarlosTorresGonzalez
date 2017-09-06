using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetPromoBL
    {
        public static Promo GetPromo(string airline, string typeCard, string bank)
        {
            Promo objPromo = new Promo();
            GetPromoDAL objGetPromo = new GetPromoDAL();
            try
            {
                try
                {
                    objPromo = objGetPromo.GetPromo(airline, typeCard, bank, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objPromo = objGetPromo.GetPromo(airline, typeCard, bank, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }

            return objPromo;
        }
    }
}
