using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class DeleteAlAgreementsDAL
    {
        public void DeleteAlAgreements(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteAlAgreementsResources.SP_DeleteAirLineAgreements);
            db.AddInParameter(dbcomand, Resources.DeleteAlAgreementsResources.PARAM_QUERY, DbType.String, StrToSearch);
            db.ExecuteNonQuery(dbcomand);
        }

    }
}
