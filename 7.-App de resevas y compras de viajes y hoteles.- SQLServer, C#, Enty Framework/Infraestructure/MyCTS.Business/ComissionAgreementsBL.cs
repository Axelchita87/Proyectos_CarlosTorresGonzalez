using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ComissionAgreementsBL
    {
        public static List<ComissionAgreements> GetComissionAgreements(string StrToSearch, string airlineID, bool internationalFlight, string classType)
        {
            List<ComissionAgreements> GetComissionAgreementsList = new List<ComissionAgreements>();
            ComissionAgreementsDAL objComissionAgreements = new ComissionAgreementsDAL();
            try
            {
                try
                {
                    GetComissionAgreementsList = objComissionAgreements.GetComissionAgreements(StrToSearch, airlineID, internationalFlight, classType, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    GetComissionAgreementsList = objComissionAgreements.GetComissionAgreements(StrToSearch, airlineID, internationalFlight, classType, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return GetComissionAgreementsList;

        }
    }
}
