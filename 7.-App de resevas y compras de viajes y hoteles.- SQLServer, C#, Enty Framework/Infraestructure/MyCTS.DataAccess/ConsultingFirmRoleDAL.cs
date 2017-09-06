using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class ConsultingFirmRoleDAL
    {

        public List<ConsultingFirmRole> GetConsultingFirmRole(string Firm, string Pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ConsultingFirmRoleResources.SP_GetConsultingFirmRole);
            db.AddInParameter(dbCommand, Resources.ConsultingFirmRoleResources.PARAM_QUERY, DbType.String, Firm);
            db.AddInParameter(dbCommand, Resources.ConsultingFirmRoleResources.PARAM_QUERY1, DbType.String, Pcc);

            List<ConsultingFirmRole> FirmRoleList = new List<ConsultingFirmRole>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _username = dr.GetOrdinal(Resources.ConsultingFirmRoleResources.PARAM_USERNAME);
                int _description = dr.GetOrdinal(Resources.ConsultingFirmRoleResources.PARAM_DESCRIPTION);
                int _rolename = dr.GetOrdinal(Resources.ConsultingFirmRoleResources.PARAM_ROLENAME);

                while (dr.Read())
                {
                    ConsultingFirmRole item = new ConsultingFirmRole();
                    item.UserName = (dr[_username] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_username);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    item.RoleName = (dr[_rolename] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rolename);
                    FirmRoleList.Add(item);
                }
            }
            return FirmRoleList;
        }
    }
}
