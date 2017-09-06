using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAirLineAgreementsBL
    {
        public static List<GetAirLineAgreements> GetAirLineAgreements(string AlCodeToSearch)
        {

            List<GetAirLineAgreements> listALAgreements = new List<GetAirLineAgreements>();
            GetAirLineAgreementsDAL objALAgreements = new GetAirLineAgreementsDAL();
            try
            {
                try
                {
                    listALAgreements = objALAgreements.GetAirLineAgreements(AlCodeToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listALAgreements = objALAgreements.GetAirLineAgreements(AlCodeToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return listALAgreements;

        }
    }
}
