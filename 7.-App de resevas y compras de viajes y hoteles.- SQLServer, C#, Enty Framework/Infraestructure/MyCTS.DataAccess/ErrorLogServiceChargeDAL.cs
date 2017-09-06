using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class ErrorLogServiceChargeDAL
    {
        public void InsertErrorLogServiceCharge(string statusTransaccion, string mensajeAmistoso, string NumeroAutorizacion, string numeroOperacion, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand("InsertErrorLogServiceCharge");
            db.AddInParameter(dbcommand, "@StatusTransaccion", DbType.String, statusTransaccion);
            db.AddInParameter(dbcommand, "@MensajeAmistoso", DbType.String, mensajeAmistoso);
            db.AddInParameter(dbcommand, "@NumeroAutorizacion", DbType.String, NumeroAutorizacion);
            db.AddInParameter(dbcommand, "@NumeroOperacion", DbType.String, numeroOperacion);
            db.ExecuteReader(dbcommand);
        }
    }
}
