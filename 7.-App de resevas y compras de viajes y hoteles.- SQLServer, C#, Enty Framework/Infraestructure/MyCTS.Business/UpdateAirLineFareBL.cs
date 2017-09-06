using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateAirLineFareBL
    {
        public static void UpdateAirLinesFare(string catAirLinFarId, string catAirLinFarName, bool ccAut, bool ccMan,
                            bool cash, bool pMix, bool misc)
        {
            UpdateAirLineFareDAL objAirLinesFare = new UpdateAirLineFareDAL();

            try
            {
                objAirLinesFare.UpdateAirLineFare(catAirLinFarId, catAirLinFarName, ccAut, ccMan, cash, pMix, misc, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAirLinesFare.UpdateAirLineFare(catAirLinFarId, catAirLinFarName, ccAut, ccMan, cash, pMix, misc, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }

    }
}
