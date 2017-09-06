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
    public class GetLogNewFormatProfilesDAL
    {
        public List<GetLogNewFormatProfiles> GetLogNewFormatProfiles(string pcc, string level1Name, string level2Name, int level, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogNewFormatProfilesResources.SP_GetLogNewFormatProfiles);
            db.AddInParameter(dbCommand, Resources.LogNewFormatProfilesResources.PARAM_PCC, DbType.String, pcc);
            db.AddInParameter(dbCommand, Resources.LogNewFormatProfilesResources.PARAM_STARLEVEL1, DbType.String, level1Name);
            db.AddInParameter(dbCommand, Resources.LogNewFormatProfilesResources.PARAM_STARLEVEL2, DbType.String, level2Name);
            db.AddInParameter(dbCommand, Resources.LogNewFormatProfilesResources.PARAM_LEVEL, DbType.Int32, level);

            List<GetLogNewFormatProfiles> logList = new List<GetLogNewFormatProfiles>();
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _name = dr.GetOrdinal(Resources.LogNewFormatProfilesResources.PARAM_GET_USER_NAME);
                    int _date = dr.GetOrdinal(Resources.LogNewFormatProfilesResources.PARAM_GET_MODIFIED_DATE);

                    while (dr.Read())
                    {
                        GetLogNewFormatProfiles item = new GetLogNewFormatProfiles();
                        item.UserName = (dr[_name] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_name);
                        item.ModifiedDate = (dr[_date] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_date);
                        logList.Add(item);
                    }
                }
            }
            catch { }

            return logList;
        }
    }
}
