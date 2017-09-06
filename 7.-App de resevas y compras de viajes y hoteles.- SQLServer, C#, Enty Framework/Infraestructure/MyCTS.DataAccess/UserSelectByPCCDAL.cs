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
    public class UserSelectByPCCDAL
    {
        public List<UserSelectByPCC> GetUsersSelectByPCC(string Firm, string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UserSelectByPCCResources.SP_UserSelectByPCC);
            db.AddInParameter(dbCommand, Resources.UserSelectByPCCResources.PARAM_QUERY, DbType.String, PCC);
            db.AddInParameter(dbCommand, Resources.UserSelectByPCCResources.PARAM_QUERY2, DbType.String, Firm);


            List<UserSelectByPCC> UserSelectByPCCList = new List<UserSelectByPCC>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _familyname = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_FAMILYNAME);
                int _agent = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_AGENT);
                int _username = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_USERNAME);
                int _usermail = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_USERMAIL);
                int _ta = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_TA);
                int _queue = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_QUEUE);
                int _userid = dr.GetOrdinal(Resources.UserSelectByPCCResources.PARAM_USERID);

                while (dr.Read())
                {
                    UserSelectByPCC item = new UserSelectByPCC();

                    item.FamilyName = (dr[_familyname] == null) ? Types.StringNullValue : dr.GetString(_familyname);
                    item.Agent = (dr[_agent] == null) ? Types.StringNullValue : dr.GetString(_agent);
                    item.UserName = (dr[_username] == null) ? Types.StringNullValue : dr.GetString(_username);
                    item.UserMail = (dr[_usermail] == null) ? Types.StringNullValue : dr.GetString(_usermail);
                    item.TA = (dr[_ta] == null) ? Types.StringNullValue : dr.GetString(_ta);
                    item.Queue = (dr[_queue] == null) ? Types.StringNullValue : dr.GetString(_queue);
                    item.UserId = dr.GetGuid(_userid).ToString();

                    UserSelectByPCCList.Add(item);
                }
            }

            return UserSelectByPCCList;
        }
    }
}
