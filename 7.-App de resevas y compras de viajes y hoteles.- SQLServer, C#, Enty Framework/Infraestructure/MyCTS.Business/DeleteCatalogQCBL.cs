using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class DeleteCatalogQCBL
    {
        public static void DeleteCatalogQC(string Attribute1, string Remark)
        {
            DeleteCatalogQCDAL objDeleteCatalogQC = new DeleteCatalogQCDAL();
            try
            {
                try
                {
                    objDeleteCatalogQC.DeleteCatalogQC(Attribute1, Remark, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteCatalogQC.DeleteCatalogQC(Attribute1, Remark, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
