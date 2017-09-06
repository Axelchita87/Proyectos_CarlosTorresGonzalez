using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class LogNotOnlinePayServicesBL
    {
        public static int GetAndInsertNotOnlinePayService(string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sTarjeta, decimal dMonto, string sTicket, string sRemark)
        {
            LogNotOnlinePayServicesDAL objLogNotOnlinePayServices = new LogNotOnlinePayServicesDAL();
            int iFolioInterno = 0;

            try
            {
                try
                {
                    iFolioInterno = objLogNotOnlinePayServices.GetAndInsertNotOnlinePayService(sFormTypeCodeFOP, iPaxNumber, sPNR, sTarjeta, dMonto, sTicket, sRemark, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    iFolioInterno = objLogNotOnlinePayServices.GetAndInsertNotOnlinePayService(sFormTypeCodeFOP, iPaxNumber, sPNR, sTarjeta, dMonto, sTicket, sRemark, CommonENT.MYCTSDB_CONNECTION);
                }
            }
            catch
            { }

            return iFolioInterno;
        }
    }
}
