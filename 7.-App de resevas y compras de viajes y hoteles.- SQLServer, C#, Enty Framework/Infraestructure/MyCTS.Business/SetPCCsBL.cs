using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetPCCsBL
    {
        public static void SetPCCs(string catPccId, string catPccName, string status, string standardClass,
                            string specificClass, string confirmation, string businessClass1,
                            string businessClass2, string businessClass3, string businessClass4, int OrgId)
        {
            SetPCCsDAL objPCCs = new SetPCCsDAL();
            try
            {
                objPCCs.SetPCCs(catPccId, catPccName, status, standardClass, specificClass, confirmation,
                    businessClass1, businessClass2, businessClass3, businessClass4, OrgId, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objPCCs.SetPCCs(catPccId, catPccName, status, standardClass, specificClass, confirmation,
                    businessClass1, businessClass2, businessClass3, businessClass4, OrgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}