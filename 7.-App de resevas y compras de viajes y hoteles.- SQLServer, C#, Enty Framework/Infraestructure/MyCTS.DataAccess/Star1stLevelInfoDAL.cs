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
    public class Star1stLevelInfoDAL
    {
        public List<Star1stLevelInfo> GetStar1stLevelInfo(string Pccid, string Level1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.Star1stLevelInfoResources.SP_GetStar1stLevelInfo);
            db.AddInParameter(dbCommand, Resources.Star1stLevelInfoResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbCommand, Resources.Star1stLevelInfoResources.PARAM_QUERY2, DbType.String, Level1);

            List<Star1stLevelInfo> Star1stLevelInfoList = new List<Star1stLevelInfo>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _pccid = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_PCCID);
                int _level1 = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_LEVEL1);
                //int _line = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_LINE);
                int _type = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_TYPE);
                int _text = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_TEXT);
                int _date = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_DATE);
                int _purged = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_PURGED);
                while (dr.Read())
                {
                    Star1stLevelInfo item = new Star1stLevelInfo();
                    item.Pccid = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                    item.Level1 = (dr[_level1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level1);
                    //item.Line = (dr[_line] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_line);
                    item.Type = (dr[_type] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_type);
                    item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                    item.Date = (dr[_date] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_date);
                    item.Purged = dr.GetBoolean(_purged);
                    Star1stLevelInfoList.Add(item);
                }
            }

            return Star1stLevelInfoList;
        }
    }
}
