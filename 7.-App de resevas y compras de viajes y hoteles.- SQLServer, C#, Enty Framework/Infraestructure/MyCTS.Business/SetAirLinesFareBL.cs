using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
   public class SetAirLinesFareBL
    {
       public static void SetAirLinesFare(string catAirLinFarId, string catAirLinFarName, bool ccAut, bool ccMan,
                                    bool cash, bool pMix, bool misc, Byte[] data, bool opManual)
        {
            SetAirLinesFareDAL objAirLinesFare = new SetAirLinesFareDAL();
            try
            {
                objAirLinesFare.SetAirLinesFare(catAirLinFarId,catAirLinFarName,ccAut,ccMan,cash,pMix,misc, data,opManual, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAirLinesFare.SetAirLinesFare(catAirLinFarId, catAirLinFarName, ccAut, ccMan, cash, pMix, misc, data, opManual, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch (Exception ext)
                {
                    throw ext;
                }
            }
        }
    }
}
