using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class ErrorLogServiceChargeBL
    {
        public static void InsertErrorLogServiceCharge(string statusTransaccion, string mensajeAmistoso, string NumeroAutorizacion, string numeroOperacion)
        {
            ErrorLogServiceChargeDAL objInsert = new ErrorLogServiceChargeDAL();

            try
            {
                objInsert.InsertErrorLogServiceCharge(statusTransaccion, mensajeAmistoso, NumeroAutorizacion, numeroOperacion, CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                objInsert.InsertErrorLogServiceCharge(statusTransaccion, mensajeAmistoso, NumeroAutorizacion, numeroOperacion, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
        }
    }
}
