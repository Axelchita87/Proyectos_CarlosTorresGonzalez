using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetQualityCotrolsBL
    {
        public static void SetQualityCotrols(string description, string iDCtrl, string ctrlType, string ctrlName,
                            string ctrlDescription, int ctrlLen, string ctrlCurrentCriteria,
                            string ctrlCatalogues, bool allowInsertValues)
        {
            SetQualityCotrolsDAL objPCCs = new SetQualityCotrolsDAL();
            try
            {
                objPCCs.SetQualityCotrols(description,iDCtrl,ctrlType,ctrlName,ctrlDescription,ctrlLen,
                    ctrlCurrentCriteria,ctrlCatalogues,allowInsertValues, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objPCCs.SetQualityCotrols(description,iDCtrl,ctrlType,ctrlName,ctrlDescription,ctrlLen,
                    ctrlCurrentCriteria,ctrlCatalogues,allowInsertValues, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }

    }
}
