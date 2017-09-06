using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateTicketsServiceFeeBL
    {
        public static void UpdateTicketsServiceFee(string sBoleto, string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sAutorization, string sOperation)
        {
            UpdateTicketsServiceFeeDAL objUpdateTicketsServiceFee = new UpdateTicketsServiceFeeDAL();

            try
            {
                try
                {
                    objUpdateTicketsServiceFee.UpdateTicketsServiceFee(sBoleto, sFormTypeCodeFOP, iPaxNumber, sPNR, sAutorization, sOperation, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    EventsManager.EventsManager.WriteWindowsLog(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdateTicketsServiceFee.UpdateTicketsServiceFee(sBoleto, sFormTypeCodeFOP, iPaxNumber, sPNR, sAutorization, sOperation, CommonENT.MYCTSDB_CONNECTION);
                }
            }
            catch
            { }
        }
    }
}
