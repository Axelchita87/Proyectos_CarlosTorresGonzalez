using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetAirLineAgreementsBL
    {
        public static void SetAirLineAgreements(string IDAlCode, string InternationalComission, string DomesticComission,
                                                string TourCode, string ISO)
        {
            SetAirLineAgreementsDAL objALAgreementes = new SetAirLineAgreementsDAL();
            try
            {
                objALAgreementes.SetAirLineAgreements(IDAlCode, InternationalComission, DomesticComission, 
                    TourCode, ISO, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objALAgreementes.SetAirLineAgreements(IDAlCode, InternationalComission, DomesticComission,
                    TourCode, ISO, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }

    }
}
