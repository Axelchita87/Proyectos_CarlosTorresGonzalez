using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateQualityControlsBL
    {
        public static void UpdateQualityControls(string description, string iDCtrl, string ctrlType, string ctrlName,
                           string ctrlDescription, int ctrlLen, string ctrlCurrentCriteria,
                           string ctrlCatalogues, bool allowInsertValues)
        {
            UpdateQualityControlsDAL objPCCs = new UpdateQualityControlsDAL();
            try
            {
                objPCCs.UpdateQualityControls(description, iDCtrl, ctrlType, ctrlName, ctrlDescription, ctrlLen,
                    ctrlCurrentCriteria, ctrlCatalogues, allowInsertValues, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objPCCs.UpdateQualityControls(description, iDCtrl, ctrlType, ctrlName, ctrlDescription, ctrlLen,
                    ctrlCurrentCriteria, ctrlCatalogues, allowInsertValues, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}
