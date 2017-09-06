using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class LogOnlinePayServicesBL
    {
        public static void InsertOnlinePayService(string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sAutorizacion, string sOperacion, string sTarjeta, decimal dMonto, string sTicket, string sRemark)
        {
            LogOnlinePayServicesDAL objLogOnlinePayServices = new LogOnlinePayServicesDAL();

            try
            {
                try
                {
                    objLogOnlinePayServices.InsertOnlinePayService(sFormTypeCodeFOP, iPaxNumber, sPNR, sAutorizacion, sOperacion, sTarjeta, dMonto, sTicket, sRemark, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objLogOnlinePayServices.InsertOnlinePayService(sFormTypeCodeFOP, iPaxNumber, sPNR, sAutorizacion, sOperacion, sTarjeta, dMonto, sTicket, sRemark, CommonENT.MYCTSDB_CONNECTION);
                }
            }
            catch
            { }
        }
    }
}
