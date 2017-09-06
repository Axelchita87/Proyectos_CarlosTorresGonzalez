using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;


namespace MyCTS.DataAccess
{
    public class UpdateDetailsPNRHotelDAL
    {
        public void UpdateDetailHotel(string reclog,string chaincode,string codecancel, bool cancel, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbComand = db.GetStoredProcCommand(Resources.DetailsPNRHotelsResources.SP_UPDATE_DETAILSPNRHOTELS);
            db.AddInParameter(dbComand, Resources.DetailsPNRHotelsResources.PARAM_RECLOG, DbType.String, reclog);
            db.AddInParameter(dbComand, Resources.DetailsPNRHotelsResources.PARAM_CHAINCODE, DbType.String, chaincode);
            db.AddInParameter(dbComand, Resources.DetailsPNRHotelsResources.PARAM_CANCEL_NUMBER, DbType.String, codecancel);
            db.AddInParameter(dbComand, Resources.DetailsPNRHotelsResources.PARAM_CANCEL, DbType.Boolean, cancel);
            db.ExecuteNonQuery(dbComand);
        }
    }
}
