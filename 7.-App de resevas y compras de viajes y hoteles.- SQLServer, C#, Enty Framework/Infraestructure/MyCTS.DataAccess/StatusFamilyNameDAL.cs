using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class StatusFamilyNameDAL
    {
        public StatusFamilyName StautsFamilyName(string firm, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.StatusFamilyResources.SP_GETSTATUSFAMILYNAME);
            db.AddInParameter(dbCommand, Resources.StatusFamilyResources.PARAM_QUERY, DbType.String, firm);

            StatusFamilyName user = new StatusFamilyName();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _statusfirm = dr.GetOrdinal(Resources.StatusFamilyResources.PARAM_STATUSFIRM);
                int _familyname = dr.GetOrdinal(Resources.StatusFamilyResources.PARAM_FAMILYNAME);
                int _pcc = dr.GetOrdinal(Resources.StatusFamilyResources.PARAM_PCC);
                try
                {
                    if (dr.Read())
                    {
                        user.StatusFirm = (dr[_statusfirm] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_statusfirm);
                        user.FamilyName = (dr[_familyname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_familyname);
                        user.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                    }
                }
                catch { }
            }
            return user;
        }

        public StatusFamilyName StautsFamilyName(string firm, string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.StatusFamilyResources.SP_GETSTATUSFAMILYNAME2);
            db.AddInParameter(dbCommand, Resources.StatusFamilyResources.PARAM_QUERY, DbType.String, firm);
            db.AddInParameter(dbCommand, Resources.StatusFamilyResources.PARAM_QUERY2, DbType.String, pcc);

            StatusFamilyName user = new StatusFamilyName();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _statusfirm = dr.GetOrdinal(Resources.StatusFamilyResources.PARAM_STATUSFIRM);
                int _familyname = dr.GetOrdinal(Resources.StatusFamilyResources.PARAM_FAMILYNAME);
                int _pcc = dr.GetOrdinal(Resources.StatusFamilyResources.PARAM_PCC);
                try
                {
                    if (dr.Read())
                    {
                        user.StatusFirm = (dr[_statusfirm] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_statusfirm);
                        user.FamilyName = (dr[_familyname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_familyname);
                        user.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                    }
                }
                catch { }
            }
            return user;
        }
    }
}
