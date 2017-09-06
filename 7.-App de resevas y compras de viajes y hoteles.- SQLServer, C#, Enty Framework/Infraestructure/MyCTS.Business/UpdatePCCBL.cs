using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdatePCCBL
    {
        public static void UpdatePCC(string catPccId, string catPccName, string status, string standardClass,
                            string specificClass, string confirmation, string businessClass1,
                            string businessClass2, string businessClass3, string businessClass4)
        {
            UpdatePCCDAL objPCCs = new UpdatePCCDAL();
            try
            {
                objPCCs.UpdatePCCs(catPccId, catPccName, status, standardClass, specificClass, confirmation,
                    businessClass1, businessClass2, businessClass3, businessClass4, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objPCCs.UpdatePCCs(catPccId, catPccName, status, standardClass, specificClass, confirmation,
                    businessClass1, businessClass2, businessClass3, businessClass4, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}
