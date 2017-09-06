using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class LogCxSHotelDAL
    {
        public void InserLogCxSHotel(string pnr, string transaccionId, int organizacionId, string autorization, string operation, string numeroTarjeta, string formaDePago, decimal monto, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogCxSHotelResources.SP_InsertRegistroCxSHoteles);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.PNR, DbType.String, pnr);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.TransaccionId, DbType.String, transaccionId);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.OrgId, DbType.Int32, organizacionId);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.Autorization, DbType.String, autorization);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.Operation, DbType.String, operation);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.NumeroTarjeta, DbType.String, numeroTarjeta);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.FormaDePago, DbType.String, formaDePago);
            db.AddInParameter(dbCommand, Resources.LogCxSHotelResources.Monto, DbType.Decimal, monto);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
