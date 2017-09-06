using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    public class UpdateTicketsServiceFeeDAL
    {
        public void UpdateTicketsServiceFee(string sBoleto, string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sAutorization, string sOperation, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogOnlinePayServices.SP_UpdateTicketsLogOnlinePayServices);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcBoleto, DbType.String, sBoleto);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcFormTypeCodeFOP, DbType.String, sFormTypeCodeFOP);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fiPaxNumber, DbType.Int32, iPaxNumber);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcPNR, DbType.String, sPNR);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcAutorization, DbType.String, sAutorization);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcOperation, DbType.String, sOperation);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch { }
        }
    }
}
