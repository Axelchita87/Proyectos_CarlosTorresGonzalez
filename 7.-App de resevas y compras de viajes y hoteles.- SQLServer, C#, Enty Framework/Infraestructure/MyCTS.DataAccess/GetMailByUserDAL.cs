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
    public class GetMailByUserDAL
    {
        public List<GetMailByUser> GetUserAndMail(string agent, string connectionName)
        { 
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetMailByUserResources.SP_GETMAILBYUSER);
            db.AddInParameter(dbCommand, Resources.GetMailByUserResources.PARAM_QUERY1, DbType.String, agent);

            List<GetMailByUser> getMailAndUserList = new List<GetMailByUser>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _userMail = dr.GetOrdinal(Resources.GetMailByUserResources.PARAM_USERMAIL);
                int _familyName = dr.GetOrdinal(Resources.GetMailByUserResources.PARAM_FAMILYNAME);

                while (dr.Read())
                {
                    GetMailByUser item = new GetMailByUser();
                    item.UserMail = dr.GetString(_userMail);
                    item.FamilyName = dr.GetString(_familyName);
                    getMailAndUserList.Add(item);
                }
            }
            return getMailAndUserList;
        }
    }
}
