using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class LogCxSHotelBL
    {
        public void InserLogCxSHotel(string pnr, string transaccionId, int organizacionId, string autorization, string operation, string numeroTarjeta, string formaDePago, decimal monto)
        {
            LogCxSHotelDAL logCxSHotelDAL = new LogCxSHotelDAL();
            try
            {
                try
                {
                    logCxSHotelDAL.InserLogCxSHotel(pnr, transaccionId, organizacionId, autorization, operation, numeroTarjeta, formaDePago, monto, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    logCxSHotelDAL.InserLogCxSHotel(pnr, transaccionId, organizacionId, autorization, operation, numeroTarjeta, formaDePago, monto, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { 
            }
        }
    }
}
        