using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    public class UpdateTicketsLogOnlinePayServicesDAL
    {

        public void UpdateTicketsLogOnlinePayServices(string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sAutorizacion, string sOperacion, string sTicket, string sRemark, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogOnlinePayServices.SP_UpdateTicketsLogOnlinePayServices);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcFormTypeCodeFOP, DbType.String, sFormTypeCodeFOP);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fiPaxNumber, DbType.Int32, iPaxNumber);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcPNR, DbType.String, sPNR);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcAutorization, DbType.String, sAutorizacion);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcOperation, DbType.String, sOperacion);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcBoleto, DbType.String, sTicket);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcRemark, DbType.String, sRemark);

            try
            {
                db.ExecuteScalar(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
