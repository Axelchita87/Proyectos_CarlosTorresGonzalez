using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetChainCodeBL
    {
        public static List<ListItem> GetChainCode(string recLog,string chainCode)
        {
            List<ListItem> chainCodeList = new List<ListItem>();
            GetChaincodeDAL objChainCode = new GetChaincodeDAL();
            try
            {
                try
                {
                    chainCodeList = objChainCode.GetChaincode(recLog, chainCode, CommonENT.MYCTSDB_CONNECTION);
                }
                catch(Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    chainCodeList = objChainCode.GetChaincode(recLog, chainCode, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return chainCodeList;
        }
    }
}
