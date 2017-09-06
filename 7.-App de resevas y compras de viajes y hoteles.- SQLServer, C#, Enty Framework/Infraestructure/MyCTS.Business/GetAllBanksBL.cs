using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAllBanksBL
    {
        public static List<Bank> GetAllBanks()
        {
            List<Bank> banksList=new List<Bank>();
            GetAllBanksDAL objGetBanks = new GetAllBanksDAL();

            try 
            {
                try 
                {
                    banksList = objGetBanks.GetAllBanks(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    banksList = objGetBanks.GetAllBanks(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }



            return banksList;
        } 
    }
}
