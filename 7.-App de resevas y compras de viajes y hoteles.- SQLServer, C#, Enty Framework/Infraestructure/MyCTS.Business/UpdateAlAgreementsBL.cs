using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateAlAgreementsBL
    {
        public static void UpdateAlAgreements(string IDAlCode, string InternationalComission, string DomesticComission,
                                                string TourCode, string ISO)
        {
            UpdateAlAgreementsDAL objALAgreementes = new UpdateAlAgreementsDAL();
            try
            {
                objALAgreementes.UpdateAlAgreements(IDAlCode, InternationalComission, DomesticComission,
                    TourCode, ISO, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objALAgreementes.UpdateAlAgreements(IDAlCode, InternationalComission, DomesticComission,
                    TourCode, ISO, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}
