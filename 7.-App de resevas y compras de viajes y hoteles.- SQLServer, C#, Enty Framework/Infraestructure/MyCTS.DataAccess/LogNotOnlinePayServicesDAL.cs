using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    public class LogNotOnlinePayServicesDAL
    {
        public int GetAndInsertNotOnlinePayService(string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sTarjeta, decimal dMonto, string sTicket, string sRemark, string connectionName)
        {
            int iFolioInterno;
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogNotOnlinePayServices.SP_InsertNotOnlinePayServices);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fcFormTypeCodeFOP, DbType.String, sFormTypeCodeFOP);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fiPaxNumber, DbType.Int32, iPaxNumber);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fcPNR, DbType.String, sPNR);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fcTarjeta, DbType.String, sTarjeta);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fdMonto, DbType.Decimal, dMonto);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fcBoleto, DbType.String, sTicket);
            db.AddInParameter(dbCommand, Resources.LogNotOnlinePayServices.PARAM_fcRemark, DbType.String, sRemark);

            try
            {
                int.TryParse(db.ExecuteScalar(dbCommand).ToString(), out iFolioInterno);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iFolioInterno;
        }
    }
}
