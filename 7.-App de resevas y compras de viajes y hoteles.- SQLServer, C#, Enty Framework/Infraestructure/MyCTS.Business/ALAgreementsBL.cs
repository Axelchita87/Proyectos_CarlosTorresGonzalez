using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ALAgreementsBL
    {
        public static List<ALAgreements> ALAgreements()
        {

            List<ALAgreements> listALAgreements = new List<ALAgreements>();
            ALAgreementsDAL objALAgreements = new ALAgreementsDAL();
            try
            {
                try
                {
                    listALAgreements = objALAgreements.ALAgreements(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listALAgreements = objALAgreements.ALAgreements(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return listALAgreements;

        }
    }
}
