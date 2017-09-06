using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatTransactionBL
    {
        public static void AddTransactions(string agent, string recLoc,
            string command,DateTime dateCreated, string areaGuid)
        {
            CatTransactionDAL objTransaction = new CatTransactionDAL();
            try
            {
                try
                {
                    objTransaction.AddTransactions(agent, recLoc, command,dateCreated, areaGuid, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objTransaction.AddTransactions(agent, recLoc, command,dateCreated, areaGuid, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch { }
        }

        public static void AddCommandsTransaction(string agent, string recLoc, string command, DateTime dateCreated, string areaGuid)
        {
            CatTransactionDAL objTransaction = new CatTransactionDAL();
            try
            {
                try
                {
                    objTransaction.AddCommandsTransaction(agent, recLoc, command,dateCreated, areaGuid, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objTransaction.AddCommandsTransaction(agent, recLoc, command,dateCreated, areaGuid, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch { }
        }

        public static void AddCommandsTransaction(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return;

            CatTransactionDAL objTransaction = new CatTransactionDAL();
            try
            {
                try
                {
                    objTransaction.AddCommandsTransaction(sql, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objTransaction.AddCommandsTransaction(sql, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch { }
        }

    }
}
