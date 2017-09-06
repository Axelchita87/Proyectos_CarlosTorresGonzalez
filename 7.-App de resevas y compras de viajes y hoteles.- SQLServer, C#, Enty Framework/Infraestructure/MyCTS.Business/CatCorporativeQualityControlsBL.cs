using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatCorporativeQualityControlsBL
    {
        public static List<CatCorporativeQualityControls> GetCorporativeQualityControls(string Attribute1)
        {
            List<CatCorporativeQualityControls> GetCorporativeQualityControlsList = new List<CatCorporativeQualityControls>();
            CatCorporativeQualityControlsDAL objCorporativeQualityControls = new CatCorporativeQualityControlsDAL();
            try
            {

                try
                {
                    GetCorporativeQualityControlsList = objCorporativeQualityControls.GetCorporativeQualityControls(Attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    GetCorporativeQualityControlsList = objCorporativeQualityControls.GetCorporativeQualityControls(Attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return GetCorporativeQualityControlsList;

        }
    }
}
