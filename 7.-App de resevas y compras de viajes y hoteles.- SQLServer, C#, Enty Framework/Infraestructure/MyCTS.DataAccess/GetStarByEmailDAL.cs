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
    public class GetStarByEmailDAL
    {
        public List<Star2ndLevelMail> GetStar2LevelMail(string eMail, string connectionName)
        {
                   Database db = DatabaseFactory.CreateDatabase(connectionName);
                   DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetStar2LevelMail.SP_SetSearchAllEmail);
                   db.AddInParameter(dbCommand, Resources.GetStar2LevelMail.PARAM_EMAIL, DbType.String, eMail);

                   var Star2ndLevelList = new List<Star2ndLevelMail>();

                   using (IDataReader dr = db.ExecuteReader(dbCommand))
                   {
                      if (dr.Read())
                      {
                          int _eMail = dr.GetOrdinal(Resources.GetStar2LevelMail.PARAM_EMAIL);

                          Star2ndLevelMail item = new Star2ndLevelMail();

                          item.eMail = (dr[_eMail] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_eMail);

                          Star2ndLevelList.Add(item);
                      } 
                  }
            return Star2ndLevelList;
            }
        }
    }


    
