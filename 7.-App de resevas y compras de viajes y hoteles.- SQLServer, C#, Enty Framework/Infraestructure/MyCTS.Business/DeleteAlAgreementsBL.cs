using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeleteAlAgreementsBL
    {
        public static void DeleteAlAgreements(string StrToSearch)
        {
            DeleteAlAgreementsDAL objDeleteAlAgreements = new DeleteAlAgreementsDAL();
            try
            {
                try
                {
                    objDeleteAlAgreements.DeleteAlAgreements(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteAlAgreements.DeleteAlAgreements(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
