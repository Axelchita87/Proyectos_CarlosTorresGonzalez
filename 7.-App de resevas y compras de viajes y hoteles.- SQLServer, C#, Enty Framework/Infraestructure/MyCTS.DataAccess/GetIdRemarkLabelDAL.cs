using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class GetIdRemarkLabelDAL
    {
        public GetIdRemarkLabel GetIdRemarkLabel(string idremarkLabel, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetIdRemarkLabelResources.SP_GetIdRemarkLabel);
            db.AddInParameter(dbCommand, Resources.GetIdRemarkLabelResources.PARAM_QUERY, DbType.String, idremarkLabel);

            GetIdRemarkLabel item = new GetIdRemarkLabel();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idremarklabel = dr.GetOrdinal(Resources.GetIdRemarkLabelResources.PARAM_IDREMARKLABEL);

                while (dr.Read())
                {
                    item.IDRemarkLabel = dr.GetString(_idremarklabel);
                }
            }
            return item;
        }
    }
}
