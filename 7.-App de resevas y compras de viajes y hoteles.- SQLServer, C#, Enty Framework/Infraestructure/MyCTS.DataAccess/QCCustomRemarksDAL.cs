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
    public class QCCustomRemarksDAL
    {
        public QCCustomRemarks GetQCCustomRemarks(string Attribute1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.QCCustomRemarksResources.SP_GetQCCustomRemarks);
            db.AddInParameter(dbCommand, Resources.QCCustomRemarksResources.PARAM_ATTRIBUTE1, DbType.String, Attribute1);

            QCCustomRemarks item = new QCCustomRemarks();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _rmrktype = dr.GetOrdinal(Resources.QCCustomRemarksResources.FIELD_RMRKTYPE);
                int _rmrkinitiallabel = dr.GetOrdinal(Resources.QCCustomRemarksResources.FIELD_RMRKINITIALLABEL);
                int _rmrkidentyfier = dr.GetOrdinal(Resources.QCCustomRemarksResources.FIELD_RMRKIDENTYFIER);
                int _rmrkpaxidentyfier = dr.GetOrdinal(Resources.QCCustomRemarksResources.FIELD_RMRKPAXIDENTYFIER);
                int _rmrkvalueidentyfier = dr.GetOrdinal(Resources.QCCustomRemarksResources.FIELD_RMRKVALUEIDENTYFIER);
                int _rmrkfinallabel = dr.GetOrdinal(Resources.QCCustomRemarksResources.FIELD_RMRKFINALLABEL);
                if (dr.Read())
                {
                    item.RmrkType = (dr[_rmrktype] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rmrktype);
                    item.RmrkInitialLabel = (dr[_rmrkinitiallabel] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rmrkinitiallabel);
                    item.RmrkIdentyfier = (dr[_rmrkidentyfier] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rmrkidentyfier);
                    item.RmrkPaxIdentyfier = (dr[_rmrkpaxidentyfier] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rmrkpaxidentyfier);
                    item.RmrkValueIdentyfier = (dr[_rmrkvalueidentyfier] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rmrkvalueidentyfier);
                    item.RmrkFinalLabel = (dr[_rmrkfinallabel] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rmrkfinallabel);
                }

            }
            return item;
        }
    }
}
