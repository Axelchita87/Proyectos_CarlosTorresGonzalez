using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class DeleteCatalogQCDAL
    {
        public void DeleteCatalogQC(string Attribute1, string Remark, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.DeleteCatalogQCResources.SP_DeleteCatalogQC);
            db.AddInParameter(dbcomand, Resources.DeleteCatalogQCResources.PARAM_QUERY, DbType.String, Attribute1);
            db.AddInParameter(dbcomand, Resources.DeleteCatalogQCResources.PARAM_QUERY1, DbType.String, Remark);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}

