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
    public class UsersSelectByPCCDAL
    {
        public List<UsersSelectByPCC> GetUsersSelectByPCC(string PCC,string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UsersSelectByPCCResources.SP_UsersSelectByPCC);
            db.AddInParameter(dbCommand, Resources.UsersSelectByPCCResources.PARAM_QUERY, DbType.String, PCC);

            List<UsersSelectByPCC> UsersSelectByPCCList = new List<UsersSelectByPCC>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _familyname = dr.GetOrdinal(Resources.UsersSelectByPCCResources.PARAM_FAMILYNAME);
                int _agent = dr.GetOrdinal(Resources.UsersSelectByPCCResources.PARAM_AGENT);
                int _firm = dr.GetOrdinal(Resources.UsersSelectByPCCResources.PARAM_FIRM);
                int _username = dr.GetOrdinal(Resources.UsersSelectByPCCResources.PARAM_USERNAME);

                while (dr.Read())
                {
                    UsersSelectByPCC item = new UsersSelectByPCC();

                    item.FamilyName = (dr[_familyname] == null) ? Types.StringNullValue : dr.GetString(_familyname);
                    item.Agent = (dr[_agent] == null) ? Types.StringNullValue : dr.GetString(_agent);
                    item.Firm = (dr[_firm] == null) ? Types.StringNullValue : dr.GetString(_firm);
                    item.UserName = (dr[_username] == null) ? Types.StringNullValue : dr.GetString(_username);
                    UsersSelectByPCCList.Add(item);
                }
            }

            return UsersSelectByPCCList;
        }

    }
}
