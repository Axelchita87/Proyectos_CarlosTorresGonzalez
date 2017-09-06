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
    public class GetStarLevel2ByEmailDAL
    {
        public List<Star2ndLevelInfo> GetStar2LevelInfo(string eMail, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetStar2ProfileByEmail.SP_GetStar2ProfileByEmail);
            db.AddInParameter(dbCommand, Resources.GetStar2ProfileByEmail.PARAM_EMAIL, DbType.String, eMail);
            
            var Star2ndLevelInfoList = new List<Star2ndLevelInfo>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    int _pccid = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_PCCID);
                    int _level1 = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_LEVEL1);
                    int _level2 = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_LEVEL2);
                    //int _line = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_LINE);
                    //int _type = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_TYPE);
                    //int _text = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_TEXT);
                    //int _date = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_DATE);
                    //int _purged = dr.GetOrdinal(Resources.Star2ndLevelInfoResources.PARAM_PURGED);
                    while (dr.Read())
                    {
                        Star2ndLevelInfo item = new Star2ndLevelInfo();
                        item.Pccid = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                        item.Level1 = (dr[_level1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level1);
                        item.Level2 = (dr[_level2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level2);
                        //item.Line = (dr[_line] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_line);
                        //item.Type = (dr[_type] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_type);
                        //item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                        //item.Date = (dr[_date] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_date);
                        //item.Purged = dr.GetBoolean(_purged);
                        Star2ndLevelInfoList.Add(item);
                    }
                }
            }

            return Star2ndLevelInfoList;
        }
    }
}



